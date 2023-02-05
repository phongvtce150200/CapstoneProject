using System.Net.Mail;
using System.Net;
using System;

namespace ClinicManageAPI.Helper
{
    public class SendMail
    {
        public static bool SendEmail(string to, string subject, string body, string attachFile)
        {
            try
            {
                MailMessage msg = new MailMessage(SendMailConfig.emailSender, to, subject, body);
                using (var client = new SmtpClient(SendMailConfig.hostEmail, SendMailConfig.portEmail))
                {
                    client.EnableSsl = true;
                    if (!string.IsNullOrEmpty(attachFile))
                    {
                        Attachment attachment = new Attachment(attachFile);
                        msg.Attachments.Add(attachment);
                    }
                    NetworkCredential credential = new NetworkCredential(SendMailConfig.emailSender, SendMailConfig.passwordSender);
                    client.UseDefaultCredentials = false;
                    client.Credentials = credential;
                    msg.IsBodyHtml = true;
                    client.Send(msg);
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
