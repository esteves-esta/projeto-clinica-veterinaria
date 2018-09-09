using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetoVeterinario030918.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Erro404()
        {
            Response.StatusCode = 404; 
            ViewBag.Message = "Página não encontrada.";

            return View();
        }
    }
}