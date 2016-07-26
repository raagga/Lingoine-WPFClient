using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lingoine.Models
{
    public class User
    {
        public string Username { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SkypeId { get; set; }
        public bool IsPremium { get; set; }
        public bool Gender { get; set; }
        public bool IsOnline { get; set; }
        public bool IsBusy { get; set; }

    }
}

