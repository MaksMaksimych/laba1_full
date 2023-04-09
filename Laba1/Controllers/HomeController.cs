using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laba1.Models;



namespace Laba1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View(new GuestResponse());
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse x, string click)
        {
            if (click == "calculate" && ModelState.IsValid)
            {
                switch (x.Operation)
                {
                    case "+":
                        x.Result = (decimal)(x.Operand1 + x.Operand2);
                        break;
                    case "-":
                        x.Result = (decimal)(x.Operand1 - x.Operand2);
                        break;
                    case "*":
                        x.Result = (decimal)(x.Operand1 * x.Operand2);
                        break;
                    case "/":
                        x.Result = (decimal)(x.Operand1 / x.Operand2);
                        break;
                }
                HttpCookie cookie = new HttpCookie("OperationInfo");
                cookie.Value = x.Operand1.ToString() + x.Operation.ToString() + x.Operand2.ToString() + " = " + x.Result.ToString();
                Response.Cookies.Add(cookie);
                return View("Thanks", x);
            }
            else
            {
                if (click == "clear")
                {
                    x.Operand1 = 0;
                    x.Operand2 = 0;
                    //return View("RsvpForm", x);
                }
            }
            

            ViewBag.ResultSecond = 10;
            return View(x);
        }

        public ViewResult Equation()
        {
            if (Request.Cookies["OperationInfo"] != null)
            {
                string Result = Request.Cookies["OperationInfo"].Value;
                string ResultInfo = Result.Substring(0, Result.LastIndexOf('=')) + "равно" + Result.Substring(Result.LastIndexOf('=') + 1);
                ViewBag.Equat = ResultInfo;
            }
            return View();
            
            
        }
    }

    
}
