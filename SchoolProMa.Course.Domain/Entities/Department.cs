using SchoolProMa.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProMa.Course.Domain.Entities
{
    public class Department : AuditEntity<int>
    {

        [Column("DepartmentID")]
        public override int Id { get; set; }

        public string? Name { get; set; }

        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }

        public int? Administrator { get; set; }
    }
}
