using DataAccessLayer;
using DataAccessLayer.Repositories;
using EntityLayer.Extra_entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public static class Training_ExercisesRepository
    {
        public static IEnumerable<Training_Exercises> GetAllExercises()
        {
            var training_ExercisesDAO = new Training_ExercisesDAO();
            return training_ExercisesDAO.GetAll();
        }
        public static IEnumerable<Exercis> GetExcersisesByDate(string date)
        {
            var username = UserRepository.GetCurrentUser();
            var training_Exercises = new Training_ExercisesDAO();
            if (training_Exercises.GetExcersisesByDate(username, date) != null)
            {
                return training_Exercises.GetExcersisesByDate(username, date).ToList();
            }
            return null;
        }

        public static int CreateTrainingExercise(int duration, int sets, int reps, Exercis exercise, Training training)
        {
            var training_Exercises = new Training_Exercises
            {
                duration = duration,
                sets = sets,
                repetition = reps,
                exercise_id = exercise.id,
                training_id = training.id
            };

            var training_ExercisesDAO = new Training_ExercisesDAO();
            return training_ExercisesDAO.CreateTrainingExercise(training_Exercises);
        }

        public static List<Training_Exercises> BulkCreateTrainingExercises(List<Training_Exercises> trainingExercisesList)
        {
            var training_ExercisesDAO = new Training_ExercisesDAO();
            return training_ExercisesDAO.BulkAddTrainingExercise(trainingExercisesList);
        }

        public static List<Training_Exercises> GenerateExercises(int selectePlanVolume, string selectedPlanType)
        {
            int AMOUNT_OF_EXERCISES = 5;
            Random random = new Random();
            var randomExercises = ExerciseRepository.GetRandomExercises(AMOUNT_OF_EXERCISES);
            var trainingExercises = new List<Training_Exercises>();

            if (selectedPlanType == "Gain Muscle")
            {
                int MIN_REPS = 4;
                int MAX_REPS = 12;

                foreach (Exercis exercise in randomExercises)
                {
                    trainingExercises.Add(new Training_Exercises
                    {
                        exercise_id = exercise.id,
                        repetition = random.Next(MIN_REPS, MAX_REPS + 1),
                        sets = selectePlanVolume,

                    });
                }
            }
            else if (selectedPlanType == "Lose weight")
            {
                int MIN_REPS = 12;
                int MAX_REPS = 20;

                foreach (Exercis exercise in randomExercises)
                {
                    trainingExercises.Add(new Training_Exercises
                    {
                        exercise_id = exercise.id,
                        repetition = random.Next(MIN_REPS, MAX_REPS + 1),
                        sets = selectePlanVolume,

                    });
                }
            }
            else if (selectedPlanType == "Cardiovasulcar Health")
            {
                int VOLUME_DURATION_MODIFIER = 30;
                randomExercises = ExerciseRepository.GetRandomExercises(1, "Cardiovascular");
                foreach (Exercis exercise in randomExercises)
                {
                    trainingExercises.Add(new Training_Exercises
                    {
                        exercise_id = exercise.id,
                        duration = selectePlanVolume * VOLUME_DURATION_MODIFIER
                    });
                }

            }
            return trainingExercises;
        }

        public static List<Training_Exercises> GenerateTrainingExercises(List<Training> listOfTrainings, TrainingDay selectedTrainingDaysPerWeek, List<List<Training_Exercises>> listOfTrainingExercisesInWeek)
        {
            List<Training_Exercises> listOfTrainingExercises = new List<Training_Exercises> ();
            int weekIndex;
            for (int i = 0; i < listOfTrainings.Count; i++)
            {
                weekIndex = i % selectedTrainingDaysPerWeek.Amount;
                var listOfExercisesInWeekday = listOfTrainingExercisesInWeek[weekIndex];

                for (int j = 0; j < listOfExercisesInWeekday.Count; j++)
                {
                    listOfTrainingExercises.Add(
                        new Training_Exercises
                        {
                            training_id = listOfTrainings[i].id,
                            exercise_id = listOfExercisesInWeekday[j].exercise_id,
                            repetition = listOfExercisesInWeekday[j].repetition,
                            sets = listOfExercisesInWeekday[j].sets
                        }
                        );
                }
            }
            return listOfTrainingExercises;
        }
    }
}
