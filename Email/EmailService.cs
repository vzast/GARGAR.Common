using Email.Models;
using Email.Settings;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Email
{
    public class EmailService
    {
        private readonly EmailSettings _emailSettings;
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration Configuration)
        {
            _configuration = Configuration;
            _emailSettings = Configuration.GetSection("Email:Settings").Get<EmailSettings>();
        }

        /// <summary>
        /// Sends mail to Email specified in model
        /// </summary>
        /// <param name="model">The first number to add.</param>
        public async Task SendAsync(EmailModel model)
        {
            using (var msg = new MailMessage())
            {
                msg.From = new MailAddress(_emailSettings!.SenderEmail!);
                msg.To.Add(model.Email);
                msg.Subject = model.Subject;
                msg.IsBodyHtml = true;
                msg.Body = model.Body;
                try
                {
                    using (var smtp = new SmtpClient(_emailSettings.Smtp, int.Parse(_emailSettings!.SmtpPort!)))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.EnableSsl = true;
                        smtp.Credentials = new NetworkCredential(_emailSettings.SenderEmail, _emailSettings.SenderPassword);
                        await smtp.SendMailAsync(msg);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Sends same body-subject mails to Emails specified in models Email list
        /// </summary>
        /// <param name="model">The first number to add.</param>
        public async Task SendAsync(MultipleEmailModel model)
        {
            using (var msg = new MailMessage())
            {
                msg.From = new MailAddress(_emailSettings!.SenderEmail!);
                foreach (var item in model.Email)
                {
                    msg.To.Add(item);
                }
                msg.Subject = model.Subject;
                msg.IsBodyHtml = true;
                msg.Body = model.Body;
                try
                {
                    using (var smtp = new SmtpClient(_emailSettings.Smtp, int.Parse(_emailSettings!.SmtpPort!)))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.EnableSsl = true;
                        smtp.Credentials = new NetworkCredential(_emailSettings.SenderEmail, _emailSettings.SenderPassword);
                        await smtp.SendMailAsync(msg);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}