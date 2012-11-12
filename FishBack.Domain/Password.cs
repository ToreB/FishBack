using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishBack.Domain
{
    public class Password
    {
        public int Id { get; set; }
        //public User User { get; set; }

        public string PasswordClearText { get; set; }
        public string PasswordHash { get; set; }
        public DateTime Date { get; set; }
    }
}
