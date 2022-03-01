using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAppSavePrivateNotes.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using WebAppSavePrivateNotes.Services;

namespace WebAppSavePrivateNotes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly INoteManagerService _noteManagerService;

        public HomeController(INoteManagerService noteManagerService)
        {
            _noteManagerService = noteManagerService;
        }

        public IActionResult MainPage()
        {
            string emailUser = User.Identity.Name;
            ViewBag.Count = _noteManagerService.CountOfNotes(emailUser);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
