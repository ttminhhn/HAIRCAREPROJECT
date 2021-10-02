using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
namespace HAIRCARE.INFRASTURUCTURE.Helpers
{
    public class EmailHelper : IMailSender
    {
        private readonly MailConfigure mailConfiguration;

        public EmailHelper(IConfiguration appConfiguration)
        {
            mailConfiguration = new MailConfigure
            {
                From = appConfiguration["MailConfigure:From"],
                FromName = appConfiguration["MailConfigure:FromName"],
                SmtpUserName = appConfiguration["MailConfigure:SmtpUserName"],
                SmtpPassword = appConfiguration["MailConfigure:SmtpPassword"],
                SmtpHost = appConfiguration["MailConfigure:SmtpHost"],
                EmailCC = appConfiguration["MailConfigure:EmailCC"],
                Port = int.Parse(appConfiguration["MailConfigure:Port"])
            };
            //mailConfiguration = new SendEmailRequest
            //{
            //    Source = $"{appConfiguration["MailConfigure:FromName"]} <{appConfiguration["MailConfigure:From"]}>"
            //};
        }

        public async Task Send(string codeActive, string email, string password, int type, string verifylink)
        {
            var subject = string.Empty;
            try
            {
                // Send Email AWS SES
                //using (var client = new AmazonSimpleEmailServiceClient(RegionEndpoint.APSoutheast1))
                //{
                //    switch (type)
                //    {
                //        case 1:
                //            subject = "Warning zone";
                //            break;
                //        default:
                //            break;
                //    }
                //    var htmlBody = GetMailContent(
                //               codeActive: codeActive,
                //               email: email,
                //               password: password,
                //               type: type);
                //    var sendRequest = new SendEmailRequest
                //    {
                //        Source = mailConfiguration.Source,
                //        Destination = new Destination
                //        {
                //            ToAddresses = new List<string> { email }
                //        },
                //        Message = new Message
                //        {

                //            Subject = new Content(subject),
                //            Body = new Body
                //            {
                //                Html = new Content
                //                {
                //                    Charset = "UTF-8",
                //                    Data = htmlBody
                //                }
                //            }
                //        }
                //    };
                //    var response = await client.SendEmailAsync(sendRequest);
                //    if(response.HttpStatusCode == HttpStatusCode.OK)
                //    {

                //    }
                //};
                var mail = new MailMessage();
                mail.IsBodyHtml = true;
                mail.From = new MailAddress(mailConfiguration.From, mailConfiguration.FromName);
                mail.To.Add(email);
                mail.CC.Add(mailConfiguration.EmailCC);
                switch (type)
                {
                    case 1:
                        mail.Subject = "[HAIRCAIR PROJECT] TẠO TÀI KHOẢN THÀNH CÔNG!";
                        break;

                    case 2:
                        mail.Subject = "[HAIRCAIR PROJECT] QUÊN MẬT KHẨU!";
                        break;

                    default:
                        break;
                }
                mail.Body = GetMailContent(
                           codeActive: codeActive,
                           email: email,
                           password: password,
                           type: type,
                           verifylink: verifylink
                       );
                SmtpClient smtpServer = new SmtpClient
                {
                    Host = mailConfiguration.SmtpHost,
                    Credentials = new NetworkCredential(mailConfiguration.SmtpUserName, mailConfiguration.SmtpPassword),
                    EnableSsl = true,
                    Port = mailConfiguration.Port,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                try
                {
                    await smtpServer.SendMailAsync(mail);
                }
                catch (Exception ex)
                {
#if DEBUG
                    Debug.WriteLine(ex.Message);
                    if (ex.InnerException != null)
                    {
                        Debug.WriteLine(ex.InnerException);
                    }
#endif 
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        private string GetMailContent(string codeActive, string email, string password, int type, string verifylink)
        {
            StringBuilder message = new StringBuilder();
            switch (type)
            {
                case 1:
                    message.Append("<p>Tài khoản đăng nhập hệ thống HAIRCARE</p>");
                    message.Append("Tài khoản：<b> " + email + "</b>");
                    message.Append("<br/>");
                    message.Append("Mật khẩu：<b>" + password + "</b><br/>");
                    message.Append("<p>Trân trọng thông báo,</p>");
                    message.Append("<p>HAIRCARE Team</ p>");
                    message.Append("<br/>");
                    break;

                case 2:
                    message.Append("<p>Tài khoản đăng nhập website HAIRCARE</p>");
                    message.Append("<p>Mã xác thực thay đổi mật khẩu</p> <br/>");
                    message.Append("<p>Hãy sử dụng mã xác thực này để thay đổi mật khẩu cho tài khoản " + email + "</p>");
                    message.Append("<p>Mã xác thực:<a href='" + verifylink + "'>" + verifylink + "</a></p> <br/>");
                    message.Append("<p>Mã xác thực có hiệu lực trong vòng 5 phút.</p> <br/>");
                    message.Append("<p>Trân trọng thông báo,</p>");
                    message.Append("<p>HAIRCARE Team</ p>");
                    message.Append("<br/>");
                    break;

                default:
                    break;
            }
            return message.ToString();
        }
    }
}
public interface IMailSender
{
    Task Send(string codeActive, string email, string password, int type, string verifylink);
}
public class MailConfigure
{
    public string From { get; set; }
    public string FromName { get; set; }
    public string SmtpHost { get; set; }
    public string SmtpUserName { get; set; }
    public string SmtpPassword { get; set; }
    public string EmailCC { get; set; }
    public int Port { get; set; }
}

