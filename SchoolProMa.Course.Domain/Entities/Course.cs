

using SchoolProMa.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProMa.Course.Domain.Entities
{
    public class Course : AuditEntity<int>
    {
        [Column("CourseID")]
        public override int Id { get; set; }
    }
}
