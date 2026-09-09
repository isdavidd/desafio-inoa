using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio_Inoa.Services.Interfaces
{
    public interface IEmailService 
    {
        Task SendEmails(string subject, string content);
    }
}
