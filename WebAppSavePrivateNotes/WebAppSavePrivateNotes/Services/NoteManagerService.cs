using System.Collections.Generic;
using WebAppSavePrivateNotes.Models;
using System;
using System.Linq;

namespace WebAppSavePrivateNotes.Services
{
    public class NoteManagerService : INoteManagerService
    {
        private readonly ApplicationContext _context;

        private IUserManagerService _userManagerService;

        public NoteManagerService(ApplicationContext context, IUserManagerService userManagerService)
        {
            _context = context;
            _userManagerService = userManagerService;
        }

        public int CountOfNotes(string emailUser)
        {
            int userId = _userManagerService.GetUserId(emailUser);

            int countOfNotes = _context.Notes.Where(p => p.UserId == userId).Count();

            return countOfNotes;
        }

        public List<Note> GetNotesInDb(string emailUser)
        {
            int userId = _userManagerService.GetUserId(emailUser);
            List<Note> notes = _context.Notes.Where(p => p.UserId == userId).ToList();
            return notes;
        }

        public void PostNoteInDb(string textOfNotes, string emailUser)
        {
            int userId = _userManagerService.GetUserId(emailUser);
            if (userId != -1)
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
        }
    }
}
