using Microsoft.AspNetCore.Mvc;
using KiloPrijsCalculator.Models;
using System.Collections.Generic;

namespace KiloPrijsCalculator.Controllers
{
    public class ProductController : Controller
    {
        private static List<Calculation> _calculations = new List<Calculation>();

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Calculations = _calculations;
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(Product product)
        {
            if (ModelState.IsValid)
            {
                var kiloPrijs = product.KiloPrijs;
                _calculations.Add(new Calculation
                {
                    Label = product.Label,
                    KiloPrijs = kiloPrijs,
                    EnteredPrice = product.Price,
                    EnteredWeight = product.Weight
                });
                return RedirectToAction("Index");
            }
            ViewBag.Calculations = _calculations;
            return View("Index", product);
        }

        [HttpPost]
        public IActionResult ClearCalculations()
        {
            _calculations.Clear();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteCalculation(int index)
        {
            if (index >= 0 && index < _calculations.Count)
            {
                _calculations.RemoveAt(index);
            }
            return RedirectToAction("Index");
        }
    }
}
