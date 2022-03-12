using System.Collections.Generic;
using PrivateNotes.Models;
using System;
using System.Linq;

namespace PrivateNotes.Services
{
    public class NoteService : INoteService
    {
        private readonly ApplicationContext _context;


        private IUserService _userService;

        public NoteService(ApplicationContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public int Count()
        {

            int userId = _userService.GetUserId();

            int countOfNotes = _context.Notes.Where(p => p.UserId == userId).Count();

            return countOfNotes;

        }

        public List<Note> Get()
        {
            int userId = _userService.GetUserId();
            List<Note> notes = _context.Notes.Where(p => p.UserId == userId).ToList();
            return notes;
        }

        public void Create(string textOfNotes)
        {
            int userId = _userService.GetUserId();
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
