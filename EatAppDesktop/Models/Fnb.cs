using EatAppDesktop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatAppDesktop.Models
{
   public class Fnb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FnbType FnbType { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
