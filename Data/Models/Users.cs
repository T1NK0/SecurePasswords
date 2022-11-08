using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string UserPassword { get; set; }
        public string SaltKey { get; set; }
    }
}
