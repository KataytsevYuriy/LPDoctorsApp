using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;

namespace LPDoctorsApp.Services
{
    public class EmailSender
    {
        public async Task SendEmailAsync(string subject, string message)
        {
            string email = "yuriy.kataytsev@gmail.com";
            string smtp = "smtp.ukr.net"; int port = 465; bool useSsl = true;string login = "yuriy_k17@ukr.net"; string pass = "Rfntyjr";
            var emailMessage = new MimeMessage();
            string emailSenders=login;
            emailMessage.From.Add(new MailboxAddress("New visit", emailSenders));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("Plain")
            {
                Text = message
            };
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(smtp, port, useSsl);
                await client.AuthenticateAsync(login, pass);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
