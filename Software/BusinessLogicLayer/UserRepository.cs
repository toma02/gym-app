using DataAccessLayer;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace BusinessLogicLayer
{
    public class UserRepository
    {
        public static bool CheckIfUsernameTaken(string username)
        {
            var usersDao = new UsersDAO();
            var userQuery = usersDao.GetUser(username);
            var users = userQuery.ToList();

            if (users.Count == 0)
            {
                return false;
            }
            else return true;
        }

        public static bool CheckIfEmailTaken(string email)
        {
            var usersDao = new UsersDAO();
            var userQuery = usersDao.GetUserByEmail(email);
            var users = userQuery.ToList();

            if (users.Count == 0)
            {
                return false;
            }
            else return true;
        }

        public static bool CheckCredentials(string username, string password)
        {
            var usersDao = new UsersDAO();
            var userQuery = usersDao.FindUser(username, password);
            var credentialsValid = userQuery.Any();

            return credentialsValid;
        }

        public static int CreateUser(string firstname, string lastname, string username, string email, string password)
        {
            var user = new User
            {
                first_name = firstname,
                last_name = lastname,
                username = username,
                email = email,
                password = password
            };

            var usersDao = new UsersDAO();
            return usersDao.AddUser(user);

        }

        public static void UpdateUserData(string username, Gender selectedGender, string age, string weight, string height, ActivityLevel selectedActivity)
        {
            var usersDAO = new UsersDAO();
            var usersQueriable = usersDAO.GetUser(username);
            var user = usersQueriable.SingleOrDefault();

           

            user.Gender = selectedGender;
            user.ActivityLevel = selectedActivity;
            user.age = int.Parse(age);
            user.weight = double.Parse(weight);
            user.height = double.Parse(height);

            usersDAO.Update(user);
        }

        public static void SaveCurrentUser(string username)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Username.txt");

            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                writer.WriteLine(username);
            }
        }

        public static string GetCurrentUser()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Username.txt");

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    return reader.ReadLine();
                }
            }

            return null;
        }

        public static User GetUser(string currentUser)
        {
            var usersDAO = new UsersDAO();

            var usersQueriable = usersDAO.GetUser(currentUser);
            var editUser = usersQueriable.SingleOrDefault();

            return editUser;
        }

        public static void UpdateUserInfo(string firstName, string lastName, string password, double weight)
        {
            var usersDAO = new UsersDAO();
            var currentUser = GetCurrentUser();
            var editUser = GetUser(currentUser);
            
            editUser.first_name = firstName;
            editUser.last_name = lastName;
            editUser.password = password;
            editUser.weight = weight;

            usersDAO.UpdateInfo(editUser);
        }
    }
}
