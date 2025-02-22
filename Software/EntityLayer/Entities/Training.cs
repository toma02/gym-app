namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Training
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Training()
        {
            Training_Exercises = new HashSet<Training_Exercises>();
        }

        public int id { get; set; }

        public int training_plan_id { get; set; }

        public int day_id { get; set; }

        public virtual Day Day { get; set; }

        public virtual TrainingPlan TrainingPlan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Training_Exercises> Training_Exercises { get; set; }
    }
}
