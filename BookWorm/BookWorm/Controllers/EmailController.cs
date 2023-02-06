using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace BookWorm.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form(string rcvemail, string sub, string msg)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string senderEmail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail"].ToString();
                    string senderPassword = System.Configuration.ConfigurationManager.AppSettings["SenderPassword"].ToString();
                    var recvemail = new MailAddress(rcvemail,"Receiver");
                    var subject = sub;
                    var body = msg;


                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true;
                    client.Timeout = 100000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                    MailMessage mailMessage = new MailMessage(senderEmail, rcvemail, sub, msg);
                    mailMessage.IsBodyHtml = true;
                    mailMessage.BodyEncoding = UTF8Encoding.UTF8;

                    client.Send(mailMessage);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "errrooorrr";
                    return View();
                }


            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "errrooorrr";
                return View();
            }
            
        }

        public JsonResult SendMailToUser()
        {
            bool result = false;
            result = SendEmail("abiha.tahsin@gmail.com", "subjeccttt", "<p>Hi abiha!</p>");
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public bool SendEmail(string rcvemail, string sub, string msg)
        {
            try
            {
                string senderEmail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail"].ToString();
                string senderPassword = System.Configuration.ConfigurationManager.AppSettings["SenderPassword"].ToString();

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail,senderPassword);

                MailMessage mailMessage = new MailMessage(senderEmail,rcvemail,sub,msg);
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = UTF8Encoding.UTF8;

                client.Send(mailMessage);

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}