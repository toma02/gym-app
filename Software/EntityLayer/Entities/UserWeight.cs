namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class UserWeight
    {
        public int id { get; set; }

        public double weight { get; set; }

        [Required]
        [StringLength(50)]
        public string date { get; set; }

        public int user_id { get; set; }

        public virtual User User { get; set; }
    }
}
