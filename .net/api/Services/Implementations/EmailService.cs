using api.Services.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace api.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void SendResetPasswordEmail(string toEmail, string token)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config["EmailSettings:From"]));
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = "Recupero contraseña";

            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $"<p>El token para resetear tu contraseña es: {token}</p><p>Por favor, ingresa a la aplicación y utilizalo para la restauración</p>"
            };

            using var smtp = new SmtpClient();
            smtp.Connect(
                _config["EmailSettings:SmtpHost"],
                int.Parse(_config["EmailSettings:SmtpPort"]),
                SecureSocketOptions.StartTls
            );
            smtp.Authenticate(_config["EmailSettings:SmtpUser"], _config["EmailSettings:SmtpPass"]);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
