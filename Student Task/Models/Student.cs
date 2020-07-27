using Student_Task.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Student_Task.Models
{

    [Table("Student")]
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            StudentTeachers = new HashSet<StudentTeacher>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [MinLength(3, ErrorMessage = "The Name must be at least 3 charachters")]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        public int GovernorateId { get; set; }

        public int? NeighborhoodId { get; set; }

        public int FieldId { get; set; }

        public virtual Field Field { get; set; }

        public virtual Governorate Governorate { get; set; }

        public virtual Neighborhood Neighborhood { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentTeacher> StudentTeachers { get; set; }
    }
}
