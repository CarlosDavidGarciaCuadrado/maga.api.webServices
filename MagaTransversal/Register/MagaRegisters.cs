using maga.accessData.contracts.repositories;
using maga.accessData.repositories;
using maga.aplicacion;
using maga.aplication;
using maga.aplication.contract;
using maga.aplication.contract.Security;
using maga.aplication.Security;
using maga.commons.util;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace magaTransversal.Registros
{
    public static class MagaRegisters
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            AddRegisterServices(services);
            AddRegisterRepositories(services);

            return services;
        }


        private static void AddRegisterServices(IServiceCollection services)
        {
            services.AddTransient<IFamilyService, FamilyService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IAccessorData, AccessorData>();
            services.AddTransient<IAccessToken, AccessToken>();
            services.AddTransient<ILogin, Login>();
            services.AddTransient<IMediaFileService, MediaFileService>();
            services.AddTransient<ISendEmail, SendEmail>();
        }

        private static void AddRegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IFamilyRepository, FamilyRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPhotoRepository, PhotoRepository>();
            services.AddTransient<IVideoRepository, VideoRepository>();
            services.AddTransient<IVerifyCodeRepository, VerifyCodeRepository>();
            services.AddTransient<IGenericParemeterRepository, GenericParameterRepository>();
        }
    }
}
