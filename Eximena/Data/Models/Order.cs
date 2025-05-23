using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Eximena.Data.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string NameOrder { get; set; }
        public string Master { get; set; }
        public string Status { get; set; }
        public int PersonnelId { get; set; }
        public Personnel Personnel { get; set; }
    }
}
