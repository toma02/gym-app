using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DataAccessLayer
{
    public partial class DatabaseModel : DbContext
    {
        public DatabaseModel()
            : base("name=DatabaseModel")
        {
        }

        public virtual DbSet<ActivityLevel> ActivityLevels { get; set; }
        public virtual DbSet<BodyPart> BodyParts { get; set; }
        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<Exercis> Exercises { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Grocery> Groceries { get; set; }
        public virtual DbSet<PlanType> PlanTypes { get; set; }
        public virtual DbSet<PlanVolume> PlanVolumes { get; set; }
        public virtual DbSet<TrainingPlan> TrainingPlans { get; set; }
        public virtual DbSet<Training> Trainings { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserWeight> UserWeights { get; set; }
        public virtual DbSet<Days_Groceries> Days_Groceries { get; set; }
        public virtual DbSet<Training_Exercises> Training_Exercises { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityLevel>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.ActivityLevel)
                .HasForeignKey(e => e.activity_level_id);

            modelBuilder.Entity<BodyPart>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<BodyPart>()
                .HasMany(e => e.Exercises)
                .WithRequired(e => e.BodyPart)
                .HasForeignKey(e => e.bodypart_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Day>()
                .Property(e => e.date)
                .IsUnicode(false);

            modelBuilder.Entity<Day>()
                .HasMany(e => e.Days_Groceries)
                .WithRequired(e => e.Day)
                .HasForeignKey(e => e.day_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Day>()
                .HasMany(e => e.Trainings)
                .WithRequired(e => e.Day)
                .HasForeignKey(e => e.day_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Equipment>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Equipment>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Equipment>()
                .HasMany(e => e.Exercises)
                .WithRequired(e => e.Equipment)
                .HasForeignKey(e => e.equipment_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Exercis>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Exercis>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Exercis>()
                .Property(e => e.video_link)
                .IsUnicode(false);

            modelBuilder.Entity<Exercis>()
                .HasMany(e => e.Training_Exercises)
                .WithRequired(e => e.Exercis)
                .HasForeignKey(e => e.exercise_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Gender>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Gender>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Gender)
                .HasForeignKey(e => e.gender_id);

            modelBuilder.Entity<Grocery>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Grocery>()
                .HasMany(e => e.Days_Groceries)
                .WithRequired(e => e.Grocery)
                .HasForeignKey(e => e.grocery_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlanType>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<PlanType>()
                .HasMany(e => e.TrainingPlans)
                .WithRequired(e => e.PlanType)
                .HasForeignKey(e => e.plan_type_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlanVolume>()
                .HasMany(e => e.TrainingPlans)
                .WithRequired(e => e.PlanVolume)
                .HasForeignKey(e => e.plan_volume_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TrainingPlan>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<TrainingPlan>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<TrainingPlan>()
                .HasMany(e => e.Trainings)
                .WithRequired(e => e.TrainingPlan)
                .HasForeignKey(e => e.training_plan_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Training>()
                .HasMany(e => e.Training_Exercises)
                .WithRequired(e => e.Training)
                .HasForeignKey(e => e.training_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Days)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Exercises)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TrainingPlans)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserWeights)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserWeight>()
                .Property(e => e.date)
                .IsUnicode(false);
        }
    }
}
