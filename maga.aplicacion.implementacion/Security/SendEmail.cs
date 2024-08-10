using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;
using maga.commons.util;
using maga.aplication.contract.Security;
using maga.accessData.contracts.repositories;
using maga.accessData.contracts.entities;

namespace maga.aplication.Security
{
    public class SendEmail: ISendEmail
    {
        private readonly IConfiguration _configuration;
        private readonly IVerifyCodeRepository _verifyCodeRepository;
        private readonly IGenericParemeterRepository _genericParemeterRepository;
        private readonly uint codeExpTime = Constant.CODE_EXPIRATION_DATE;
        private double minutes;
        private string? _host;
        private uint? _port;
        private string? _user;
        private string? _password;
        private string? _body;
        private string? _code;

        public SendEmail(IConfiguration configuration, IVerifyCodeRepository verifyCodeRepository, IGenericParemeterRepository genericParemeterRepository)
        {
            _configuration = configuration;
            _verifyCodeRepository = verifyCodeRepository;
            _genericParemeterRepository = genericParemeterRepository;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                string user = _configuration["Smtp:User"] ?? "";
                var fromAddress = CreateMailAddress(user, "APP_MAGA");
                var toAddress = CreateMailAddress(toEmail);
                var smtp = CreateSmtpClient();
                await smtp.SendMailAsync(CreateMailMessage(fromAddress, toAddress, subject, body));
            }
            catch (Exception ex)
            {
                throw GenericExceptionHelper.GenerateException("Ocurrió un error al enviar el correo electrónico: " + ex.Message);
            }
        }

        private MailAddress CreateMailAddress(string email, string? displayName = null)
        {
            return new MailAddress(email, displayName);
        }

        private SmtpClient CreateSmtpClient()
        {
            return new SmtpClient
            {
                Host = _host ?? "",
                Port = Convert.ToInt32(_port),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_user, _password)
            };
        }

        private MailMessage CreateMailMessage(MailAddress fromAddress, MailAddress toAddress, string subject, string body)
        {
            return new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
        }

        public async Task<string> VerifyEmail(string email)
        {
            GenericParameterEntity? parameterGeneric = await _genericParemeterRepository.GetParamByCodeAndLabel(Constant.CODE_GENERIC_PARAM, Constant.EXPIRATION_CODE_GENERIC_PARAM);
            minutes = Convert.ToInt64(parameterGeneric != null ? parameterGeneric.valueInt : codeExpTime);
            await getParameters();
            await _verifyCodeRepository.DeleteAsync(email);
            try
            {
                await SendEmailAsync(email, "código de verificación test", _body ?? "");
            }
            catch (Exception ex)
            {
                throw GenericExceptionHelper.GenerateException("ocurrió un error al enviar el código: " + ex.Message);
            }
            VerifyCodeEntity entity = new VerifyCodeEntity()
            {
                code = _code ?? "",
                email = email,
                expirationDate = DateTime.Now.AddMinutes(minutes)
            };
            await _verifyCodeRepository.Add(entity);
            return "código enviado exitosamente.";
        }

        private string GenerateVerificationCode()
        {
            Random random = new Random();
            int code = random.Next(100000, 999999);
            return code.ToString();
        }

        private async Task getParameters()
        {
            List<GenericParameterEntity> parameters = await _genericParemeterRepository.GetAllParameters(Constant.CODE_SEND_EMAIL_VERIFY);
            if (parameters != null && parameters.Count > 0) 
            {
                _code = GenerateVerificationCode();
                string? templateBody = parameters.Find(parameter => parameter.label == Constant.BODY_SEND_EMAIL_VERIFY)?.valueString;
                if (templateBody != null)
                {
                    templateBody = templateBody.Replace("{_code}", _code);
                    templateBody = templateBody.Replace("{minutes}", minutes.ToString());
                }

                _body = templateBody ?? "";
                _host = parameters.Find(parameter => parameter.label == Constant.HOST_SEND_EMAIL_VERIFY)?.valueString ?? _configuration["Smtp:Server"];
                _port = parameters.Find(parameter => parameter.label == Constant.PORT_SEND_EMAIL_VERIFY)?.valueInt ?? Convert.ToUInt32(_configuration["Smtp:Port"]);
                _user = parameters.Find(parameter => parameter.label == Constant.USER_SEND_EMAIL_VERIFY)?.valueString ?? _configuration["Smtp:User"];
                _password = parameters.Find(parameter => parameter.label == Constant.PASSWORD_APLICATION_SEND_EMAIL_VERIFY)?.valueString ?? _configuration["Smtp:Pass"];
            }
        }
    }
}
