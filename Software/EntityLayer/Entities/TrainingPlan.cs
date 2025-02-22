namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class TrainingPlan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrainingPlan()
        {
            Trainings = new HashSet<Training>();
        }

        public int id { get; set; }

        public int duration { get; set; }

        public int plan_type_id { get; set; }

        public int plan_volume_id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [StringLength(200)]
        public string description { get; set; }

        public int? user_id { get; set; }

        public virtual PlanType PlanType { get; set; }

        public virtual PlanVolume PlanVolume { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Training> Trainings { get; set; }
    }
}
