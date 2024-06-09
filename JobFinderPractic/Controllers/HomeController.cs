using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using JobFinder.Domain.Entities.Concretes;
using JobFinder.DataAccess.Reposiotries.Abstracts;

namespace JobFinderPractic.Controllers;

public class HomeController : Controller {

    // Fields

    private readonly UserManager<AppUser> _userManager;
    private readonly IJobRepository _jobRepository;

    // Constructor

    public HomeController(IJobRepository jobRepository, UserManager<AppUser> userManager) {
        _userManager = userManager;
        _jobRepository = jobRepository;
    }

    // Methods

    // Index => JobFinder-in Home Sehifesidir.
    [HttpGet]
    public async Task<IActionResult> Index() {

        var jobs = await _jobRepository.GetAllAsync();

        return View(jobs);
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
}
