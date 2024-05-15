using JobFinderPractic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using JobFinder.DataAccess.Reposiotries.Concretes;
using JobFinder.Domain.Entities.Concretes;
using Microsoft.AspNetCore.Identity;

namespace JobFinderPractic.Controllers;

public class AccountController : Controller {

    // Fields

    private AppUserRepository _userRepository;
    private UserManager<AppUser> _userManager;

    // Constructor

    public AccountController(UserManager<AppUser> userManager, AppUserRepository appUserRepository) { 
        _userRepository = appUserRepository;
        _userManager = userManager;
    }

    // Login
    [HttpGet]
    public IActionResult Login() {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel viewModel) {
        var user = new AppUser() { Email = viewModel.Email};
        var result = _userManager.CreateAsync(user, viewModel.Password);
        if (result.IsCompleted) {
            var allusers = await _userRepository.GetAllAsync();
            bool isContain = false;
            allusers.ForEach((u) => {
                if (u.Email == viewModel.Email && u.PasswordHash == user.PasswordHash) {
                    isContain = true;
                }
            });
            if (isContain) return RedirectToAction("Index", "Home");
        }
        return View();
    }

    // Register
    [HttpGet]
    public IActionResult Register() {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel viewModel) {

        var user = new AppUser() { Email = viewModel.Email, FullName = viewModel.FullName, Role = viewModel.Role };
        var result = _userManager.CreateAsync(user, viewModel.Password);
        if(result.IsCompleted) {
            await _userRepository.AddAsync(user);

        }
        return RedirectToAction("Login", "Account");
    }

    // LogOut
    [HttpGet]
    [Authorize]
    public IActionResult LogOut() {
        return RedirectToAction("Index", "Home");
    }

    // Access Denied
    [HttpGet]
    public IActionResult AccessDenied() {
        return View();
    }
}
