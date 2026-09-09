using Desafio_Inoa.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio_Inoa.Services
{
    public class EmailService : IEmailService
    {
        public Task SendEmail(string email, string subject, string content)
        {
            throw new NotImplementedException();
        }
    }
}
