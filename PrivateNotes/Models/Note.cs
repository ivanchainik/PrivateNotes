using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrivateNotes.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Time {get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
