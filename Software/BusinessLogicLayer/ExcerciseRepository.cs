using DataAccessLayer.Repositories;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BusinessLogicLayer
{
    public class ExerciseRepository
    {
        readonly ExercisesDAO excerciseDAO = new ExercisesDAO();

        public Exercis GetExcerciseByID(int excerciseID)
        {
            if(excerciseID > 0)
            {
                var excercise = excerciseDAO.GetExcerciseByID(excerciseID).ToList();
                return (excercise.Count > 0) ? excercise[0] : null;
            }
            return null;
        }

        public Exercis GetExcerciseByIDMOCK(int excerciseID)
        {
            if(excerciseID > 0)
            {
                List<Exercis> exercises = GetAllFilteredExcercisesMOCK();
                foreach (Exercis ex in exercises)
                {
                    if (ex.id == excerciseID)
                        return ex;
                }
            }
            return null;
        }

        public List<Exercis> GetAllFilteredExcercisesMOCK()
        {
            BodyPartDAO bodyPartDAO = new BodyPartDAO();
            _ = new List<BodyPart>();
            List<BodyPart> bodyParts = bodyPartDAO.GetAll().ToList();

            EquipmentDAO equipmentDAO = new EquipmentDAO();
            _ = new List<Equipment>();
            List<Equipment> equipments = equipmentDAO.GetAll().ToList();

            UsersDAO usersDAO = new UsersDAO();
            _ = new List<User>();
            List<User> users = usersDAO.GetAll().ToList();


            List<Exercis> excercises = new List<Exercis>();
            excercises.Add(new Exercis{ 
                id = 1,
                name = "Neka vježbica",
                BodyPart = bodyParts[0], 
                Equipment = equipments[0], 
                description = "Lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum",
                difficulty = 1,
                video_link = "https://www.youtube.com/watch?v=Bzo0F-YmH1Q",
                User = users[0]
            });
            excercises.Add(new Exercis
            {
                id = 2,
                name = "Neka vježbica za vježbanje",
                BodyPart = bodyParts[0],
                Equipment = equipments[1],
                description = "Vjezbanje vjezbica vjezbica vjezbica vjezbica vjezbam vjezbam",
                difficulty = 1,
                video_link = "https://www.youtube.com/watch?v=Bzo0F-YmH1Q",
                User = users[0]
            });
            return excercises;
        }

        public List<Exercis> GetAllFilteredExcercises(BodyPart bodyPart, Equipment equipment)
        {
            var FilteredExcercises = new List<Exercis>();
            if(bodyPart != null && equipment != null)
            {
                ExercisesDAO excerciseDAO = new ExercisesDAO();
                FilteredExcercises = excerciseDAO.GetAllFiltered(bodyPart, equipment).ToList();
            }
            return FilteredExcercises;
        }

        public static List<Exercis> GetAllExcercises()
        {
            var exerciseDAO = new ExercisesDAO();
            return exerciseDAO.GetAll().ToList();
        }

        public static bool CheckIfExerciseExists(string name)
        {
            var exerciseDAO = new ExercisesDAO();
            var exists = exerciseDAO.GetExercise(name);
            var exercise = exists.ToList();

            if (exercise.Count == 0)
            {
                return false;
            }
            else
                return true;
        }

        public static int CreateExercise(string name, string description, string video_link, int difficulty, Equipment equipment, BodyPart bodyPart)
        {
            var exercise = new Exercis
            {
                name = name,
                description = description,
                video_link = video_link,
                difficulty = difficulty,
                bodypart_id = bodyPart.id,
                equipment_id = equipment.id,
            };

            var exerciseDAO = new ExercisesDAO();
            return exerciseDAO.AddExercise(exercise);
        }

        public static List<Exercis> GetRandomExercises(int count, string bodypart)
        {
            var exerciseDAO = new ExercisesDAO();
            List<Exercis> exercisesList = exerciseDAO.GetAllByBodyPart(bodypart).ToList();

            var random = new Random();
            return exercisesList.OrderBy(exercise => random.Next()).Take(count).Distinct().ToList();
        }

        public static List<Exercis> GetRandomExercises(int count)
        {
            var exerciseDAO = new ExercisesDAO();
            List<Exercis> exercisesList = exerciseDAO.GetAll().ToList();

            var random = new Random();
            return exercisesList.OrderBy(exercise => random.Next()).Take(count).Distinct().ToList();
        }
    }
}
