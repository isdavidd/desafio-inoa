using Desafio_Inoa.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using Desafio_Inoa.Configs;

namespace Desafio_Inoa.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmails(string subject, string content)
        {
            Configuration configs = Configuration.GetInstance();

            List<string> emailList = new List<string>(configs.EmailList);

            var smtpClient = new SmtpClient(configs.Host, int.Parse(configs.Port))
            {
                Credentials = new System.Net.NetworkCredential(configs.User, configs.Password),
                EnableSsl = true,
            };

            foreach (var email in emailList)
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(configs.User),
                    Subject = subject,
                    Body = content
                };
                mailMessage.To.Add(email);
                await smtpClient.SendMailAsync(mailMessage);
            }

        }
    }
}
