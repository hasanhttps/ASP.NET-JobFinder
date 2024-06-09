using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using JobFinder.Domain.Entities.Concretes;
using JobFinderPractic.Areas.Employer.Models;
using JobFinder.DataAccess.Reposiotries.Abstracts;
using JobFinder.DataAccsess.Reposiotries.Abstracts;

namespace JobFinderPractic.Areas.Employer.Controllers;

[Area("Employer")]
[Authorize(Roles = "Employer")]
public class HomeController : Controller {

    // Fields

    private readonly IJobRepository _jobRepository;
    private readonly UserManager<AppUser> _userManager;
    private readonly ICategoryRepository _categoryRepository;

    // Constructor

    public HomeController(UserManager<AppUser> userManager, IJobRepository jobRepository, ICategoryRepository categoryRepository) {
        _userManager = userManager;
        _jobRepository = jobRepository;
        _categoryRepository = categoryRepository;
    }

    // Post a Job
    [HttpGet]
    public async Task<IActionResult> PostJob() {
        var categories = await _categoryRepository.GetAllAsync();
        if (categories != null) return View(new PostJobVM { Categories = categories});
        else return View(new PostJobVM { Categories = new List<Categories>() });
    }

    [HttpPost]
    public async Task<IActionResult> PostJob(PostJobVM viewModel) {

        var user = await _userManager.GetUserAsync(User);

        await _jobRepository.AddAsync(new Jobs {
            Name = viewModel.Name,
            Desc = viewModel.Desc,
            Region = viewModel.Region,
            MinAge = viewModel.MinAge,
            MaxAge = viewModel.MaxAge,
            Gender = viewModel.Gender,
            Schedule = viewModel.Schedule,
            Location = viewModel.Location,
            MinSalary = viewModel.MinSalary,
            MaxSalary = viewModel.MaxSalary,
            Education = viewModel.Education,
            StateType = viewModel.StateType,
            CategoryId = viewModel.CategoryId,
            Experience = viewModel.Experience,
            VacantionUrl = viewModel.VacantionUrl,
            EntryProcess = viewModel.EntryProcess,
            ProfileDemand = viewModel.ProfileDemand,
            VacantionCode = viewModel.VacantionCode,
            ExpireDateTime = viewModel.ExpireDateTime,
            AcceptNotCompleteCv = viewModel.AcceptNotCompleteCv,
            AcceptAppealFromRetired = viewModel.AcceptAppealFromRetired,
            UserId = user!.Id
        });
        if (viewModel.Categories == null) viewModel.Categories = await _categoryRepository.GetAllAsync();
        return View(viewModel);
    }
}
