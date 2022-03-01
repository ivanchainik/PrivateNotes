using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppSavePrivateNotes.Services;

namespace WebAppSavePrivateNotes.Controllers
{
    [Authorize]
    public class NotesController : Controller
    {
        private readonly INoteManagerService _noteManagerService;
        public NotesController(INoteManagerService noteManagerService)
        {
            _noteManagerService = noteManagerService;
        }

        [HttpGet]
        public IActionResult AddNotes()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNotes(string text)
        {
            string email = User.Identity.Name;
            _noteManagerService.PostNoteInDb(text, email);
            return RedirectToAction("MainPage", "Home");
        }

        [HttpGet]
        public IActionResult GetNotes()
        {
            string emailUser = User.Identity.Name;
            return View(_noteManagerService.GetNotesInDb(emailUser));
        }
    }
}
