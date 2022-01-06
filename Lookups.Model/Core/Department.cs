using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lookups.Model.Core
{
    [Table("Lk.Department")]
    public class Department
    {
        public int ID { get; set; }
        [StringLength(150)]
        [Required]
        [RegularExpression(@"^[\u0600-\u06FF0-9\s\\\\/\-_()\.\,\&]+$", ErrorMessage = "Department Ar must be in Arabic")]
        public String DepartmentAr { get; set; }

        [StringLength(150)]
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9\s\\\\/\-_()\.\,\&]+$", ErrorMessage = "Department En must be in English")]
        public String DepartmentEn { get; set; }

        [StringLength(500)]
        [RegularExpression(@"^[a-zA-Z0-9\s\\\\/\-_()\.\,\&]+$", ErrorMessage = "Invalid Details")]
        public String Details { get; set; }
    }
}
