using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAnalysisWeb.Data;
using Rozetka;

namespace ProductsAnalysisWeb.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Home()
        {

            return View();
        }
        public IActionResult Shop()
        {
            List<Mobile> mobilesList = new List<Mobile>();
            if (Start.CheckXmlExists())
            {
                mobilesList = Start.FromeXML();
            }
            else mobilesList = Start.StartApplication();
            return View(mobilesList);
        }
        public IActionResult Analytics()
        {
            ViewBag.Title = "Analytics";
            List<Mobile> mobilesList = new List<Mobile>();
            if (Start.CheckXmlExists())
            {
             mobilesList = Start.FromeXML();
            }
            else mobilesList = Start.StartApplication();

            return View(mobilesList);
        }
    }
}