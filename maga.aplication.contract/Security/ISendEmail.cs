using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maga.aplication.contract.Security
{
    public interface ISendEmail
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
        Task<string> VerifyEmail(string email);
    }
}
