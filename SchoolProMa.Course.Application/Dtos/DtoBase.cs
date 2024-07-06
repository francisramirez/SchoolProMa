using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProMa.Course.Application.Dtos
{
    public abstract class DtoBase
    {
       
        public int ChangeUser { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
