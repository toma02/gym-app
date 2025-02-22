namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Training_Exercises
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int training_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int exercise_id { get; set; }

        public int? duration { get; set; }

        public int? repetition { get; set; }

        public int? sets { get; set; }

        public virtual Exercis Exercis { get; set; }

        public virtual Training Training { get; set; }
    }
}
