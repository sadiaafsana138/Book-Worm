using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookWorm.Controllers
{
    public class MemberManagementController : Controller
    {
        // GET: MemberManagement
        public ActionResult Index()
        {
            return View();
        }
    }
}