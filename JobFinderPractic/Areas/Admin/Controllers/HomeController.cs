using Microsoft.AspNetCore.Mvc;

namespace JobFinderPractic.Areas.Admin.Controllers;

[Area("Admin")]
public class HomeController : Controller
{
    // Admin Girish Sehifesi => Home
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    // AllUser
    [HttpGet]
    public IActionResult AllUser()
    {
        return View();
    }

    // AllJobs
    [HttpGet]
    public IActionResult AllJobs()
    {
        return View();
    }
}
