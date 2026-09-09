using Desafio_Inoa.Configs;
using Desafio_Inoa.Services;

string email1 = Configuration.GetInstance().EmailList[0];

EmailService emailService = new EmailService();

await emailService.SendEmails("Teste", "Teste");
