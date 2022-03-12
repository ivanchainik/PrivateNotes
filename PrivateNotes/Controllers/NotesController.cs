using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrivateNotes.Services;

namespace PrivateNotes.Controllers
{
    [Authorize]
    public class NotesController : Controller
    {
        private readonly INoteService _noteManagerService;
        public NotesController(INoteService noteManagerService)
        {
            _noteManagerService = noteManagerService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(string text)
        {
            try
            {
                _noteManagerService.Create(text);
                return RedirectToAction("MainPage", "Home");
            }
            catch
            {
                Response.StatusCode = 404;
                return View();
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            return View(_noteManagerService.Get());
        }
    }
}
