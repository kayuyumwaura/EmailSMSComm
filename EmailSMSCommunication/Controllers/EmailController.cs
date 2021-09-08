using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace EmailSMSCommunication.Controllers
{
    [RoutePrefix("ApiController/EmailController")]
    public class EmailController : ApiController
    {
        [HttpPost]
        [Route("send-email")]
        public async Task SendEmail([FromBody]JObject objData)
        {
            var message = new MailMessage();
            message.To.Add(new MailAddress(objData["toName"].ToString() + "<" + objData["toemail"].ToString() + ">"));
            message.From = new MailAddress("Kayuyu Mwaura <mwaurakayuyu@gmail.com>");
            message.Bcc.Add(new MailAddress("Kayuyu Mwaura <mwaurakayuyu@gmail.com>"));
            message.Subject = objData["Subject"].ToString();
            message.Body = createEmailBody(objData["toName"].ToString(), objData["message"].ToString());
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                await smtp.SendMailAsync(message);
                await Task.FromResult(0);
            }
        }

        private string createEmailBody(string  userName, string message)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("/htmlTemplate.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{UserName}", userName);
            body = body.Replace("{message}", message);
            return body;
        }
    }
}
