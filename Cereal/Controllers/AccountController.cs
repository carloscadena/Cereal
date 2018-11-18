﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Cereal.Data;
using Cereal.Models;
using Cereal.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cereal.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private ApplicationDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                CheckUserRoleExists();


                ApplicationUser user = new ApplicationUser()
                {
                    FirstName = rvm.FirstName,
                    LastName = rvm.LastName,
                    UserName = rvm.Email,
                    Email = rvm.Email
                };

                var result = await _userManager.CreateAsync(user, rvm.Password);

                if (result.Succeeded)
                {                   
                    // Custom claim for full name of user
                    Claim fullNameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");

                    // Claim for email
                    Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

                    List<Claim> myClaims = new List<Claim>()
                    {
                        fullNameClaim,
                        emailClaim
                    };

                    //adding admin roles
                    if (rvm.Email == "amanda@codefellow.com" || rvm.Email == "ajelebeuf@gmail.com" || rvm.Email == "carloscadena@live.com")
                    {
                        await _userManager.AddToRoleAsync(user, UserRoles.Admin);
                    }

                    await _userManager.AddToRoleAsync(user, UserRoles.Member);

                    await _userManager.AddClaimsAsync(user, myClaims);

                    await _signInManager.SignInAsync(user, isPersistent: false);
                }
                
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            // Default email: carl@carl.com
            // pw: @Carlos1
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "You are wrong");
                }
            }
            return View(lvm);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// checks for user role at registration
        /// </summary>
        public void CheckUserRoleExists()
        {
            if (!_context.Roles.Any())
            {
                List<IdentityRole> Roles = new List<IdentityRole>
                {
                    new IdentityRole{Name = UserRoles.Admin,
                    NormalizedName=UserRoles.Admin.ToString(), ConcurrencyStamp = Guid.NewGuid().ToString()},
                    new IdentityRole{Name = UserRoles.Member,
                    NormalizedName=UserRoles.Member.ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() },
                };

                foreach(var role in Roles)
                {
                    _context.Roles.Add(role);
                    _context.SaveChanges();
                }
            }
        }
    }
}