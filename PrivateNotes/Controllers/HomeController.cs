using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PrivateNotes.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using PrivateNotes.Services;

namespace PrivateNotes.Controllers
{
    public class HomeController : Controller
    {
        private readonly INoteService _noteManagerService;

        public HomeController(INoteService noteManagerService)
        {
            _noteManagerService = noteManagerService;
        }

        public IActionResult MainPage()
        {
            ViewBag.Count = _noteManagerService.Count();
            return View();
        }
    }
}
