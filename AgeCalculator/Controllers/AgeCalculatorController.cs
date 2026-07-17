using AgeCalculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgeCalculator.Controllers
{
    public class AgeCalculatorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new AgeCalculation
            {
                AgeAtDate = DateTime.Today
            });
        }

        [HttpPost]
        public IActionResult Index(AgeCalculation model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Validation
            if (model.DateOfBirth > model.AgeAtDate)
            {
                ModelState.AddModelError("", "Date of Birth cannot be greater than Age At Date.");
                return View(model);
            }

            DateTime dob = model.DateOfBirth!.Value;
            DateTime ageDate = model.AgeAtDate!.Value;

            // Exact Years / Months / Days
            int years = ageDate.Year - dob.Year;
            int months = ageDate.Month - dob.Month;
            int days = ageDate.Day - dob.Day;

            if (days < 0)
            {
                months--;
                DateTime previousMonth = ageDate.AddMonths(-1);
                days += DateTime.DaysInMonth(previousMonth.Year, previousMonth.Month);
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            model.Years = years;
            model.Months = months;
            model.Days = days;

            // Total Difference
            TimeSpan span = ageDate - dob;

            model.TotalDays = span.Days;
            model.TotalWeeks = span.Days / 7;
            model.TotalHours = (long)span.TotalHours;
            model.TotalMinutes = (long)span.TotalMinutes;
            model.TotalSeconds = (long)span.TotalSeconds;

            model.TotalYears = years;
            model.TotalMonths = years * 12 + months;

            // Next Birthday
            DateTime nextBirthday;

            try
            {
                nextBirthday = new DateTime(ageDate.Year, dob.Month, dob.Day);
            }
            catch
            {
                nextBirthday = new DateTime(ageDate.Year, 2, 28);
            }

            if (nextBirthday < ageDate)
            {
                nextBirthday = nextBirthday.AddYears(1);
            }

            model.NextBirthday = nextBirthday;
            model.DaysLeft = (nextBirthday - ageDate).Days;

            return View(model);
        }
    }
}