using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishBack.Domain
{
    public class ClientLogin
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Client ClientInfo { get; set; }

        public override string ToString()
        {
            return String.Format("Id: {0} - Username: {1} - Password: {2} - ClientInfo: {3} - ", Id, Username, Password, ClientInfo);
        }
    }
}
