using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishBack.Domain
{
    public class Login
    {
        public int Id { get; set; }
        
        public User User { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LogoutTime { get; set; }
        public Session Session { get; set; }
        public string Ip { get; set; }
    }
}
