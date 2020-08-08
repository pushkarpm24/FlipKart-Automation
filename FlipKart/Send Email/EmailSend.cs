using System.Net;
using System.Net.Mail;

namespace FlipKart.Send_Email
{
    public class EmailSend
    {
        public static void SendMail()
        {
            /*  MailMessage mail = new MailMessage();
              string fromEmail = "moreypushkar24@outlook.com";
              string password = "realhero2430";
              string ToEmail = "moreypushkar24@outlook.com";
              mail.From = new MailAddress(fromEmail);
              mail.To.Add(ToEmail);
              mail.Subject = "Test Mail....";
              mail.Body = "Mail With Attachment";
              mail.Priority = MailPriority.High;
              mail.IsBodyHtml = true;
              mail.Attachments.Add(new Attachment(@"C:\Users\HP\source\repos\FlipKart\FlipKart\ExtentReport/index.html"));
              SmtpClient smtp = new SmtpClient("smtp.live.com", 587);
              smtp.UseDefaultCredentials = false;
              smtp.Credentials = new NetworkCredential(fromEmail, password);
              smtp.EnableSsl = true;
              smtp.Send(mail); */

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
            mail.From = new MailAddress("moreypushkar24@outlook.com");
            mail.To.Add("moreypushkar24@outlook.com");
            mail.Subject = "Test Mail....";
            mail.Body = "Mail With Attachment";

            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment("C:\\Users\\HP\\source\\repos\\FlipKart\\FlipKart\\ExtentReport\\index.html");
            mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("moreypushkar24@outlook.com", "realhero2430");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
    }
}
