using Microsoft.AspNetCore.Mvc;

namespace JobFinderPractic.Controllers;

public class HomeController : Controller {
    // Index => JobFinder-in Home Sehifesidir.
    [HttpGet]
    public IActionResult Index() {
        return View();
    }

    // About
    [HttpGet]
    public IActionResult About() {
        return View();
    }

    // Contact
    [HttpGet]
    public IActionResult Contact() {
        return View();
    }

    // Find a Jobs
    [HttpGet]
    public IActionResult FindJobs() {
        return View();
    }
}
