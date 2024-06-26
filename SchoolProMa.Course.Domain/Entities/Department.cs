using SchoolProMa.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProMa.Course.Domain.Entities
{
    public class Department : AuditEntity<int>
    {

        [Column("DepartmentID")]
        public override int Id { get; set; }
    }
}
