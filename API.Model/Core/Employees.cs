using Lookups.Model.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace API.Model.Core
{
    [Table("01_Employees")]
    public class Employees
    {
        public Guid ID { get; set; }

        [StringLength(100)]
        [Required]
        [RegularExpression(@"^[\u0600-\u06FFa-zA-Z0-9\s_.\/-^(\p{L}\p{M}*)+$]+$", ErrorMessage = "Invalid First Name")]
        public String FirstName { get; set; }
        [StringLength(100)]
        [RegularExpression(@"^[\u0600-\u06FFa-zA-Z0-9\s_.\/-^(\p{L}\p{M}*)+$]+$", ErrorMessage = "Invalid Second Name")]
        public String SecondName { get; set; }
        [StringLength(100)]
        [Required]
        [RegularExpression(@"^[\u0600-\u06FFa-zA-Z0-9\s_.\/-^(\p{L}\p{M}*)+$]+$", ErrorMessage = "Invalid Last Name")]
        public String LastName { get; set; }
        [StringLength(100)]
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid Email")]
        public String Email { get; set; }

        [StringLength(20)]
        [RegularExpression(@"^[0-9\s+]+$", ErrorMessage = "Invalid Mobile")]
        public String Mobile { get; set; }


        [ForeignKey("department")]
        public int Department_ID { get; set; }
        public virtual Department Department { get; set; }


        [ForeignKey("gender")]
        public int Gender_ID { get; set; }
        public virtual Gender gender { get; set; }


        //[NotMapped]
        //public List<Gender> genderList { get; set; }
        //[NotMapped]
        //public List<Department> departmentList { get; set; }
    }
}
