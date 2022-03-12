using System.Collections.Generic;
using PrivateNotes.Models;

namespace PrivateNotes.Services
{
    public interface INoteService
    {
        public void Create(string textOfNotes);

        public List<Note> Get();

        public int Count();
    }
}
