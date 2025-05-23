using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Eximena.Data.Models
{
    public class Personnel
    {
        public int PersonnelId { get; set; }
        public string FirstName { get; set; }
        public string RoleName { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
