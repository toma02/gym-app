using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DataAccessLayer;
using EntityLayer;
using System.Transactions;
using System.Data;
using DataAccessLayer.Repositories;
namespace IntegrationTests
{
    public class ExerciseRepository_Tests : DataAccessLayer.Repositories.Repository<Exercis>
    {
        public ExerciseRepository_Tests() : base (new DatabaseModel())
        {

        }

        [Fact]
        public void CreateExercise_CreatesExerciseAndStoresInDataBase_ReturnsTrue()
        {
            var exerciseName = "Integracijski Test Vjezba";
            var exerciseDescription = "Opis";
            var exerciseLink = "";
            var exerciseDifficulty = 1;
            var exerciseEquipment = new Equipment { id = 1, name = "Machine" };
            var exerciseBodyPart = new BodyPart { id = 1, name = "Chest" };

            var result = ExerciseRepository.CreateExercise(exerciseName, exerciseDescription, exerciseLink, exerciseDifficulty, exerciseEquipment, exerciseBodyPart);

            Assert.Equal(1, result);

            DeleteExercise(exerciseName);
        }

        [Fact]
        public void GetExerciseById_ReadsExerciseFromDataBaseAndReturnsIt_ReturnsExercise()
        {
            var id = 15;
            var exerciseRepo = new ExerciseRepository();

            var result = exerciseRepo.GetExcerciseByID(id);

            Assert.Equal(id, result.id);
        }
        private void DeleteExercise(string name)
        {
            var exercise = Entities.FirstOrDefault(p => p.name == name);
            if (exercise != null)
            {
                Entities.Remove(exercise);
                SaveChanges();
            }
        }

        public override int Update(Exercis entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
