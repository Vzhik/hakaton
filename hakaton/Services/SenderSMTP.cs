using System.Net;
using System.Net.Mail;

namespace hakaton.Services
{
    public static class SenderSMTP
    {
        public static void SendMessage(string email, string subject, string body)
        {
            SmtpClient client = new SmtpClient("smtp.yandex.ru", 25)
            {
                Credentials = new NetworkCredential("JsInquisitorTest@yandex.ru", "password!@")
            };
            MailMessage message = new MailMessage {From = new MailAddress("JsInquisitorTest@yandex.ru")};
            message.To.Add(email);
            message.Subject = subject;
            message.Body = body;
            try
            {
                client.Send(message);
            }
            catch (SmtpException)
            {

            }
        }
    }
}
