using System.Collections.Generic;
using WebAppSavePrivateNotes.Models;

namespace WebAppSavePrivateNotes.Services
{
    public interface INoteManagerService
    {
        public void PostNoteInDb(string textOfNotes, string emailUser);

        public List<Note> GetNotesInDb(string emailUser);

        public int CountOfNotes(string emailUser);
    }
}
