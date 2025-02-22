using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class ExcerciseRepository_Tests
    {
        [Fact]
        public void GetExcerciseByID_GivenExcerciseIdIsValid_ReturnsValidExcercise()
        {
            // Arrange
            int excerciseId = 15;
            ExerciseRepository exerciseRepository = new ExerciseRepository();

            // Act
            var excercise = exerciseRepository.GetExcerciseByID(excerciseId);

            // Assert
            Assert.Equal("Bench press", excercise.name);
            Assert.Equal("Bench press", excercise.description);
            Assert.Equal("https://www.youtube.com/watch?v=rT7DgCr-3pg", excercise.video_link);
            Assert.Equal(1, excercise.difficulty);
            Assert.Equal("Chest", excercise.BodyPart.name);
            Assert.Equal("Barbell", excercise.Equipment.name);
        }

        [Fact]
        public void GetExcerciseByID_GivenExcerciseIdIsNull_ReturnsNull() 
        {
            // Arrange
            var excerciseId = 0;
            ExerciseRepository exerciseRepository = new ExerciseRepository();

            // Act
            var excercise = exerciseRepository.GetExcerciseByID(excerciseId);

            // Assert
            Assert.Null(excercise);
        }

        [Fact]
        public void GetExcerciseByID_GivenExcerciseIdInvalid_ReturnsNull()
        {
            // Arrange
            var excerciseId = -1;
            ExerciseRepository exerciseRepository = new ExerciseRepository();

            // Act
            var excercise = exerciseRepository.GetExcerciseByID(excerciseId);

            // Assert
            Assert.Null(excercise);
        }

        [Fact]
        public void GetExcerciseByID_GivenExcerciseIdDoesntExists_ReturnsNull()
        {
            // Arrange
            var excerciseId = 130;
            ExerciseRepository exerciseRepository = new ExerciseRepository();

            // Act
            var excercise = exerciseRepository.GetExcerciseByID(excerciseId);

            // Assert
            Assert.Null(excercise);
        }

        [Fact]
        public void GetExcerciseByIDMOCK_GivenExcerciseIdIsValid_ReturnsValidExcercise()
        {
            // Arrange
            int excerciseId = 1;
            ExerciseRepository exerciseRepository = new ExerciseRepository();

            // Act
            var excercise = exerciseRepository.GetExcerciseByIDMOCK(excerciseId);

            // Assert
            Assert.Equal("Neka vježbica", excercise.name);
            Assert.Equal("Lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum", excercise.description);
            Assert.Equal("https://www.youtube.com/watch?v=Bzo0F-YmH1Q", excercise.video_link);
            Assert.Equal(1, excercise.difficulty);
            Assert.Equal("Chest", excercise.BodyPart.name);
            Assert.Equal("Machine", excercise.Equipment.name);
        }

        [Fact]
        public void GetExcerciseByIDMOCK_GivenExcerciseIdInvalid_ReturnsNull()
        {
            // Arrange
            int excerciseId = -1;
            ExerciseRepository exerciseRepository = new ExerciseRepository();

            // Act
            var excercise = exerciseRepository.GetExcerciseByIDMOCK(excerciseId);

            // Assert
            Assert.Null(excercise);
        }

        [Fact]
        public void GetExcerciseByIDMOCK_GivenExcerciseIdDoesntExists_ReturnsNull()
        {
            // Arrange
            int excerciseId = 130;
            ExerciseRepository exerciseRepository = new ExerciseRepository();

            // Act
            var excercise = exerciseRepository.GetExcerciseByIDMOCK(excerciseId);

            // Assert
            Assert.Null(excercise);
        }

        [Fact]
        public void GetAllFilteredExcercisesMOCK_ReturnsListOfFilteredExcercises()
        {
            // Arrange
            ExerciseRepository exerciseRepository = new ExerciseRepository();

            // Act
            var excercise = exerciseRepository.GetAllFilteredExcercisesMOCK();

            // Assert
            Assert.Equal(1, excercise[0].id);
            Assert.Equal("Neka vježbica", excercise[0].name);
            Assert.Equal("Lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum", excercise[0].description);
            Assert.Equal("https://www.youtube.com/watch?v=Bzo0F-YmH1Q", excercise[0].video_link);
            Assert.Equal(1, excercise[0].difficulty);
            Assert.Equal("Chest", excercise[0].BodyPart.name);
            Assert.Equal("Machine", excercise[0].Equipment.name);

            Assert.Equal(2, excercise[1].id);
            Assert.Equal("Neka vježbica za vježbanje", excercise[1].name);
            Assert.Equal("Vjezbanje vjezbica vjezbica vjezbica vjezbica vjezbam vjezbam", excercise[1].description);
            Assert.Equal("https://www.youtube.com/watch?v=Bzo0F-YmH1Q", excercise[1].video_link);
            Assert.Equal(1, excercise[1].difficulty);
            Assert.Equal("Chest", excercise[1].BodyPart.name);
            Assert.Equal("Barbell", excercise[1].Equipment.name);
        }

        [Fact]
        public void GetAllExcercises_ReturnsListOfExcercises()
        {
            // Act
            var excercise = ExerciseRepository.GetAllExcercises();

            // Assert
            Assert.True(excercise.Count > 0);
            Assert.Equal(15, excercise[0].id);
            Assert.Equal(16, excercise[1].id);
            Assert.Equal(17, excercise[2].id);
        }

        [Fact]
        public void GetAllFilteredExcercises_GivenNothingIsSeleted_ReturnsEmptyList()
        {
            // Arrange
            ExerciseRepository exerciseRepository = new ExerciseRepository();

            // Act
            var excercises = exerciseRepository.GetAllFilteredExcercises(null, null);

            // Assert
            Assert.Empty(excercises);
        }

        [Fact]
        public void GetAllFilteredExcercises_GivenOnlyBodyPartIsSelected_ReturnsEmptyList()
        {
            // Arrange
            ExerciseRepository exerciseRepository = new ExerciseRepository();
            BodyPartRepository bodyPartRepository = new BodyPartRepository();

            // Act
            var bodyParts = bodyPartRepository.GetBodyParts();
            var excercises = exerciseRepository.GetAllFilteredExcercises(bodyParts[0], null);

            // Assert
            Assert.Empty(excercises);
        }

        [Fact]
        public void GetAllFilteredExcercises_GivenOnlyEquipmentIsSelected_ReturnsEmptyList()
        {
            // Arrange
            ExerciseRepository exerciseRepository = new ExerciseRepository();
            EquipmentRepository equipmentRepository = new EquipmentRepository();

            // Act
            var equipment = equipmentRepository.GetEquipment2();
            var excercises = exerciseRepository.GetAllFilteredExcercises(null, equipment[0]);

            // Assert
            Assert.Empty(excercises);
        }

        [Fact]
        public void GetAllFilteredExcercises_GivenBodyPartAndEquipmentAreSelectedThatMatchSomeExcercises_ReturnsListOfExcercises()
        {
            // Arrange
            ExerciseRepository exerciseRepository = new ExerciseRepository();
            BodyPartRepository bodyPartRepository = new BodyPartRepository();
            EquipmentRepository equipmentRepository = new EquipmentRepository();

            // Act
            var equipment = equipmentRepository.GetEquipment2();
            var bodyParts = bodyPartRepository.GetBodyParts();
            var excercises = exerciseRepository.GetAllFilteredExcercises(bodyParts[0], equipment[1]);

            // Assert
            Assert.True(excercises.Count > 0);
            Assert.Equal(15, excercises[0].id);
            Assert.Equal("Bench press", excercises[0].name);
            Assert.Equal("Bench press", excercises[0].description);
            Assert.Equal("https://www.youtube.com/watch?v=rT7DgCr-3pg", excercises[0].video_link);
            Assert.Equal(1, excercises[0].difficulty);
            Assert.Equal("Chest", excercises[0].BodyPart.name);
            Assert.Equal("Barbell", excercises[0].Equipment.name);
        }

        [Fact]
        public void GetAllFilteredExcercises_GivenBodyPartAndEquipmentAreSelectedThatMatchNoExcercises_ReturnsEmptyList()
        {
            // Arrange
            ExerciseRepository exerciseRepository = new ExerciseRepository();
            BodyPartRepository bodyPartRepository = new BodyPartRepository();
            EquipmentRepository equipmentRepository = new EquipmentRepository();

            // Act
            var equipment = equipmentRepository.GetEquipment2();
            var bodyParts = bodyPartRepository.GetBodyParts();
            var excercises = exerciseRepository.GetAllFilteredExcercises(bodyParts[9], equipment[9]);

            // Assert
            Assert.Empty(excercises);
        }
    }
}
