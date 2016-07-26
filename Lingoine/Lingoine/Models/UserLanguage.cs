using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lingoine.Models
{
    public class UserLanguage
    {
        public string UserEmail { get; set; }
        public int LanguageId { get; set; }
        public int ProficiencyLevel { get; set; }
        public float Rating { get; set; }
    }
}

