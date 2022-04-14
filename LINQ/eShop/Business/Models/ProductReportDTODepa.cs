using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class ProductReportDTODepa
    {
        public List<Subdepartment> Subdepas { get; internal set; }
        public string Depa { get; internal set; }
    }
}
