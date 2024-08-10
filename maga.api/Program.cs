using maga.accesoData;
using maga.accesoData.contrato;
using magaTransversal.Registros;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
string Origins = "_AllowOrigins";

// Add services to the container.
builder.Services.AddScoped<IMagaContext, MagaContext>();
builder.Services.AddDbContext<MagaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ApiConnection")));

MagaRegisters.AddRegistration(builder.Services);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: Origins,
        builder =>
        {
            builder.WithOrigins().AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(PlatformServices.Default.Application.ApplicationVersion, new OpenApiInfo
    {
        Title = $"{PlatformServices.Default.Application.ApplicationName} - Maga",
        Version = PlatformServices.Default.Application.ApplicationVersion,
        Description = "Servicio API para manejo de fotos familiares."
    });

    List<string> xmlFiles = Directory.GetFiles(PlatformServices.Default.Application.ApplicationBasePath, "*.xml", SearchOption.TopDirectoryOnly).ToList();
    xmlFiles.ForEach(xmlFile => c.IncludeXmlComments(xmlFile));
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"] ?? ""))
    };
});

var app = builder.Build();

// Probar la conexión a la base de datos
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MagaContext>();
    try
    {
        Console.WriteLine("Conexión exitosa a la base de datos");
        context.Database.Migrate();
        context.Database.CanConnect();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al conectar con la base de datos: {ex.Message}");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DocumentTitle = $"{PlatformServices.Default.Application.ApplicationName} {PlatformServices.Default.Application.ApplicationVersion}";
        c.SwaggerEndpoint($"../swagger/{PlatformServices.Default.Application.ApplicationVersion}/swagger.json", $"{PlatformServices.Default.Application.ApplicationName} - Maga");
        c.DisplayRequestDuration();
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors(Origins);

app.MapControllers();

app.Run();
