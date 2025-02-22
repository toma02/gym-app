namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Exercises")]
    public partial class Exercis
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Exercis()
        {
            Training_Exercises = new HashSet<Training_Exercises>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [StringLength(200)]
        public string description { get; set; }

        [StringLength(100)]
        public string video_link { get; set; }

        public int? difficulty { get; set; }

        public int bodypart_id { get; set; }

        public int equipment_id { get; set; }

        public int? user_id { get; set; }

        public virtual BodyPart BodyPart { get; set; }

        public virtual Equipment Equipment { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Training_Exercises> Training_Exercises { get; set; }
    }
}
