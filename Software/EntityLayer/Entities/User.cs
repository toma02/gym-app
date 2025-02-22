namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Days = new HashSet<Day>();
            Exercises = new HashSet<Exercis>();
            TrainingPlans = new HashSet<TrainingPlan>();
            UserWeights = new HashSet<UserWeight>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string first_name { get; set; }

        [Required]
        [StringLength(20)]
        public string last_name { get; set; }

        [Required]
        [StringLength(20)]
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        public int? age { get; set; }

        public double? height { get; set; }

        public int? gender_id { get; set; }

        public int? activity_level_id { get; set; }

        public double? weight { get; set; }

        public virtual ActivityLevel ActivityLevel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Day> Days { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Exercis> Exercises { get; set; }

        public virtual Gender Gender { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrainingPlan> TrainingPlans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserWeight> UserWeights { get; set; }
    }
}
