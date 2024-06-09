using JobFinderPractic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using JobFinder.Domain.Entities.Concretes;

namespace JobFinderPractic.Controllers;

public class AccountController : Controller {

    // Fields

    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    // Constructor

    public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager) { 
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
    }

    // Login
    [HttpGet]
    public async Task<IActionResult> Login(string? ReturnUrl = null) {
        ViewBag.ReturnUrl = ReturnUrl;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel viewModel, string? ReturnUrl = null) {

        if (!ModelState.IsValid)
            return View(viewModel);

        var user = await _userManager.FindByEmailAsync(viewModel.Email);

        if (user is null) {
            ModelState.AddModelError("All", "User not found");
            return View(viewModel);
        }

        var result = await _userManager.CheckPasswordAsync(user, viewModel.Password);

        if (!result) {
            ModelState.AddModelError("All", "Password is wrong");
            return View(viewModel);
        }
        else {
            await _signInManager.SignInAsync(user, true);
            if (user.Role == "Admin") return RedirectToAction("Index", "Home", new { Area = "Admin" });
            else return RedirectToAction("Index", "Home");
        }
    }

    // Register
    [HttpGet]
    public async Task<IActionResult> Register() {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel viewModel) {

        var user = new AppUser() { UserName = viewModel.Email, Email = viewModel.Email, FullName = viewModel.FullName, Role = viewModel.Role };
        var result = await _userManager.CreateAsync(user, viewModel.Password);

        if(result.Succeeded) {

            var role = await _roleManager.RoleExistsAsync(viewModel.Role);

            if (!role)
                await _roleManager.CreateAsync(new IdentityRole { Name = viewModel.Role });

            await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(user.UserName), viewModel.Role);

            return RedirectToAction("Login", "Account");
        } 


        return View();
    }

    // LogOut
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> LogOut() {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    // Access Denied
    [HttpGet]
    public IActionResult AccessDenied() {
        return View();
    }
}