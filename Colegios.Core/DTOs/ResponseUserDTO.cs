using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegios.Core.DTOs
{
    public class ResponseUserDTO
    {
        public int? IdUser { get; set; }
        public string Names { get; set; }
        public string LastNames { get; set; }
        public DateTime birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }
        public bool Status { get; set; }
        public string UserName { get; set; }
    }
}
