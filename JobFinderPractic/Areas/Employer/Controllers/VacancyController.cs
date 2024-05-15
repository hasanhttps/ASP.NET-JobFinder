using Microsoft.AspNetCore.Mvc;

namespace JobFinderPractic.Areas.Employer.Controllers;

[Area("Employer")]
public class VacancyController : Controller
{
    // Yeni vakansiya elave edilmesi
    [HttpGet]
    public IActionResult AddJob()
    {
        return View();
    }

    // Menim Butun vakansiyalarim
    [HttpGet]
    public IActionResult MyAllJob()
    {
        return View();
    }
}
