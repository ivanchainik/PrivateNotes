using System.Collections.Generic;
using PrivateNotes.Models;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace PrivateNotes.Services
{
    public class NoteService : INoteService
    {
        private readonly ApplicationContext _context;

        private readonly IHttpContextAccessor _httpContextAccesor;

        private IUserService _userManagerService;

        public NoteService(ApplicationContext context, IUserService userManagerService, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManagerService = userManagerService;
            _httpContextAccesor = httpContextAccessor;
        }

        public int Count()
        {
            string emailUser = _httpContextAccesor.HttpContext.User.Identity.Name;

            int userId = _userManagerService.GetUserId(emailUser);

            int countOfNotes = _context.Notes.Where(p => p.UserId == userId).Count();

            return countOfNotes;

        }

        public List<Note> Get()
        {
            string emailUser = _httpContextAccesor.HttpContext.User.Identity.Name;
            int userId = _userManagerService.GetUserId(emailUser);
            List<Note> notes = _context.Notes.Where(p => p.UserId == userId).ToList();
            return notes;
        }

        public void Create(string textOfNotes)
        {
            string emailUser = _httpContextAccesor.HttpContext.User.Identity.Name;
            int userId = _userManagerService.GetUserId(emailUser);
            if (userId != 0)
            {
                DateTime time = DateTime.Now;
                Note note = new Note()
                {
                    Text = textOfNotes,
                    Time = time,
                    UserId = userId
                };
                _context.Notes.Add(note);
                _context.SaveChanges();
            }
            else
                throw new NullReferenceException();
        }
    }
}
