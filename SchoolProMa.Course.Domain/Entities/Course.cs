

using SchoolProMa.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProMa.Course.Domain.Entities
{
    public class Course : AuditEntity<int>
    {
        [Column("CourseID")]
        public override int Id { get; set; }

        public string? Title { get; set; }

        public int Credits { get; set; }

        public int DepartmentID { get; set; }

    }
}
