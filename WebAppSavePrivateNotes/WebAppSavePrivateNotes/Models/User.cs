using System.Collections.Generic;

namespace WebAppSavePrivateNotes.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Note> Notes { get; set; }
        public User()
        {
            Notes = new List<Note>();
        }
    }
}
