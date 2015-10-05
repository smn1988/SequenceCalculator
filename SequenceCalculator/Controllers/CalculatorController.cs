using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SequenceCalculator.Models;
using System.Collections.Generic;

namespace SequenceCalculator.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: Calculator
        public ActionResult Index()
        {

            return View(new CalculatorModel());
        }

        [HttpPost]
        public ActionResult Calculate(CalculatorModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            //validate bayad beshe
            model.oddNumbers = new List<int>();
            model.evenNumbers = new List<int>();
            model.special = new List<string>();
            model.fibonacci = new List<int>();

            GetOddAndEvenNumbers(model);
            GetSpecialNumbers(model);
            GetFibonacciNumbers(model);

            return View(model);
        }

        private void GetSpecialNumbers(CalculatorModel model)
        {
            for (int i = 1; i <= Convert.ToInt32(model.number); i++)
            {
                if ((i % 3 == 0) && (i % 5 == 0))
                {
                    model.special.Add("Z");
                    continue;
                }
                else if ((i % 3 == 0))
                {
                    model.special.Add("C");
                    continue;
                }
                else if (i % 5 == 0)
                {
                    model.special.Add("E");
                    continue;
                }
                model.special.Add(i.ToString());
            }
        }

        private void GetOddAndEvenNumbers(CalculatorModel model)
        {

            for (int i = 1; i <= Convert.ToInt32(model.number); i++)
            {
                if (i % 2 == 0)
                {
                    model.evenNumbers.Add(i);
                }
                else
                {
                    model.oddNumbers.Add(i);
                }

            }
        }

        public void GetFibonacciNumbers(CalculatorModel model)
        {
            List<int> listOfNumbers = new List<int>();
            for (int i = 1; i <= Convert.ToInt32(model.number); i++)
            {
                model.fibonacci.Add(GetFibonacci(i));
            }
        }

        private static int GetFibonacci(int n)
        {
            int a = 0, b = 1;
            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }

        [HttpGet]
        public ActionResult Calculate(string input)
        {

            return View("Index");
        }
    }
}