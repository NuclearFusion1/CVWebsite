using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net.Mail;
using System.Web.Mvc;
using CVWebsite.Models;

namespace CVWebsite.Controllers
{
    public class ContactController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactModel contactModel)
        {
            if (ModelState.IsValid)
            {
                MailMessage mailMessage = new MailMessage()
                {
                    From = new MailAddress(ConfigurationManager.AppSettings["AdminEmail"], contactModel.name),
                    Subject = contactModel.subject,
                    Body = contactModel.message,
                    Sender = new MailAddress(contactModel.email),
                    IsBodyHtml = true
                };
                mailMessage.To.Add(new MailAddress(ConfigurationManager.AppSettings["DestinationEmail"]));
                mailMessage.ReplyToList.Add(new MailAddress(contactModel.email));
                try
                {
                    using(SmtpClient client = new SmtpClient())
                    {
                        client.Send(mailMessage);
                    }
                    return Json(new { Success = true, Message = "OK" });
                }
                catch (SmtpException e)
                {
                    return Json(new { Success = false, Message = "An error occurred sending email" });
                }            
            }
            return Json(new { Success = false, Message = "Could not validate form, please try again" });
        }
    }
}