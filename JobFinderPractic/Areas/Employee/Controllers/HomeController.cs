using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using JobFinder.Domain.Entities.Concretes;
using JobFinder.DataAccess.Reposiotries.Abstracts;

namespace JobFinderPractic.Areas.Employee.Controllers;

[Area("Employee")]
[Authorize(Roles = "Employee")]
public class HomeController : Controller {

    // Fields

    private readonly UserManager<AppUser> _userManager;
    private readonly IJobRepository _jobRepository;

    // Constructor

    public HomeController(UserManager<AppUser> userManager, IJobRepository jobRepository)
    {
        _userManager = userManager;
        _jobRepository = jobRepository;
    }

    // Find a Jobs
    [HttpGet]
    public IActionResult FindJobs() {
        return View();
    }
}
