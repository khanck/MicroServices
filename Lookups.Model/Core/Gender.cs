using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lookups.Model.Core
{
    [Table("Lk.Gender")]
    public class Gender
    {
        public int ID { get; set; }

        [StringLength(100)]
        [Required]
        [RegularExpression(@"^[\u0600-\u06FF0-9\s\\\\/\-_()\.\,\&]+$", ErrorMessage = "Gender Ar must be in Arabic")]
        public String GenderAr { get; set; }

        [StringLength(100)]
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9\s\\\\/\-_()\.\,\&]+$", ErrorMessage = "Gender En must be in English")]
        public String GenderEn { get; set; }
    }
}
