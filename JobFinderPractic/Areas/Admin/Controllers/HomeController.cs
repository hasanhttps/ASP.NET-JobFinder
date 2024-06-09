using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using JobFinder.DataAccess.Reposiotries.Abstracts;

namespace JobFinderPractic.Areas.Admin.Controllers;

[Area( "Admin")]
[Authorize(Roles = "Admin")]
public class HomeController : Controller {

    // Fields

    private readonly IJobRepository _jobReository;

    // Constructor

    public HomeController(IJobRepository jobReository) {
        _jobReository = jobReository;
    }

    // Admin Girish Sehifesi => Home
    [HttpGet]
    public IActionResult Index() {
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
