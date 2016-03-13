using System.Web.Mvc;
using WebShopMVC.Models;
using System.Web;
using System.Linq;

namespace WebShopMVC.Controllers
{
    public class MyController : Controller
    {
        // GET: My
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }
        [HttpPost]
        public ViewResult RsvpForm(GuestResponce questResponce)
        {
            return View("Ok", questResponce);
        }
    }
}