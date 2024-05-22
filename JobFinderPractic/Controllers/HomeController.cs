using JobFinderPractic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using JobFinder.Domain.Entities.Concretes;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.Design.Serialization;

namespace JobFinderPractic.Controllers;

public class HomeController : Controller {

    // Fields

    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    // Constructor

    public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ILogger<HomeController> logger) {
        _userManager = userManager;
        _signInManager = signInManager;
        _logger = logger;
    }

    // Methods

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
    [Authorize]
    public IActionResult FindJobs() {
        return View();
    }

    // Post a Job
    [HttpGet]
    [Authorize]
    public IActionResult PostJob() {
        return View();
    }

    [HttpPost]
    public IActionResult PostJob(PostJobViewModel viewModel) { 
        return View(viewModel);
    }
}
