namespace EdExTutorService.App.Controllers
{
    using System.Net.Mail;
    using System.Web.Mvc;
    using EdExTutorService.App.Models.BindingModels;
    using EdExTutorService.App.Utils;
    using System.Threading.Tasks;
    using System.Net;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }

        public ActionResult Contact()
        {
            if(TempData["successful_email"] != null)
            {
                ViewBag.Message = TempData["successful_email"];
                TempData["successful_email"] = null;
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendEmail(EmailBindingModel email)
        {
            if(this.ModelState.IsValid && email != null)
            {
                MailAddress sender = new MailAddress(email.Email, email.Name);
                MailAddress receiver = new MailAddress(ConstantsAndMessages.EmailAddress);

                MailMessage message = new MailMessage();
                message.Subject = ConstantsAndMessages.MessageSubject;
                message.Body = string.Format("From: {0} {1}\n To: {2}\n {3}",
                    email.Email, email.Name, ConstantsAndMessages.EmailAddress, email.Message);

                using (var client = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = ConstantsAndMessages.EmailUsername,  
                        Password = ConstantsAndMessages.EmailPassword
                    };
                    client.Credentials = credential;
                    client.Host = ConstantsAndMessages.EmailHost;
                    client.Port = ConstantsAndMessages.EmailHostPort;
                    client.EnableSsl = true;
                    client.Send(message);
                    return RedirectToAction("Sent");
                }
            }

            return RedirectToAction("Contact");
        }

        public ActionResult Sent()
        {
            ViewBag.Message = "Your message has been sent successfully.";

            return View();
        }
    }
}