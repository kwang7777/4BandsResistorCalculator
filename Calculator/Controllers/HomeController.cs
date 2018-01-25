using ResistorCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResistorCalculator.Services;

namespace ResistorCalculator.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            ViewBag.Title = "4-Band Resistor Color Code Calculator";
            return View();
        }
        public ActionResult Submit(IOhmResistorCalculatorService calculator)
        {
            ViewBag.Title = "4-Band Resistor Color Code Calculator";
            string firstBandColor = Request["firstBandColor"];
            string secondBandColor = Request["secondBandColor"];
            string thirdBandColor = Request["thirdBandColor"];
            string fourthBandColor = Request["fourthBandColor"];

            if (!string.IsNullOrEmpty(firstBandColor)
                && !string.IsNullOrEmpty(secondBandColor)
                && !string.IsNullOrEmpty(thirdBandColor))
            {

                ViewBag.flag = 1;
                List<string> calculateResults = calculator.CalculateOhmValue(firstBandColor.ToUpper(), secondBandColor.ToUpper(), thirdBandColor.ToUpper(), string.IsNullOrEmpty(fourthBandColor) ? "NONE" : fourthBandColor.ToUpper());
                ViewBag.lowerLimit = calculateResults[0];
                ViewBag.upperLimit = calculateResults[1];
            }
            else
            {
                ViewBag.flag = 0;
            }

            ViewBag.firstBandColor = firstBandColor;
            ViewBag.secondBandColor = secondBandColor;
            ViewBag.thirdBandColor = thirdBandColor;
            ViewBag.fourthBandColor = fourthBandColor;

            return View("Index");
        }
    }
}