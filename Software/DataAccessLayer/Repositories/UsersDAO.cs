using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UsersDAO : Repository<User>
    {
        public UsersDAO() : base(new DatabaseModel())
        {

        }

        public override IQueryable<User> GetAll()
        {
            var query = from u in Entities
                        select u;
            return query;
        }

        public IQueryable<User> GetUser(string username)
        {
            var query = from u in Entities
                        where u.username == username
                        select u;
            return query;
        }

        public IQueryable<User> GetUserByEmail(string email)
        {
            var query = from u in Entities
                        where u.email == email
                        select u;
            return query;
        }

        public void DeleteUser(int id)
        {
            var user = Entities.FirstOrDefault(p => p.id == id);
            if (user != null)
            {
                Entities.Remove(user);
                SaveChanges();
            }
        }

        public IQueryable<User> FindUser(string username, string password)
        {
            var query = from u in Entities
                        where u.username == username && u.password == password
                        select u;
            return query;
        }

        public int AddUser(User entity, bool saveChanges = true)
        {
            //var gender = Context.Genders.SingleOrDefault(g => g.id == entity.Gender.id);
            //var activityLevel = Context.ActivityLevels.SingleOrDefault(a => a.id == entity.ActivityLevel.id);

            var user = new User
            {
                first_name = entity.first_name,
                last_name = entity.last_name,
                username = entity.username,
                email = entity.email,
                password = entity.password,
                //age = entity.age,
                //height = entity.height,
                //weight = entity.weight,

                //ActivityLevel = activityLevel,
                //Gender = gender,
            };

            Entities.Add(user);

            if (saveChanges)
            {
               return SaveChanges();
            }
            else return 0;
        }


        public override int Update(User entity, bool saveChanges = true)
        {
            var gender = Context.Genders.SingleOrDefault(g => g.id == entity.Gender.id);
            var activityLevel = Context.ActivityLevels.SingleOrDefault(a => a.id == entity.ActivityLevel.id);

            var user = Entities.SingleOrDefault(u => u.id == entity.id);

            user.Gender = gender;
            user.ActivityLevel = activityLevel;
            user.email = entity.email;
            user.username = entity.username;
            user.password = entity.password;
            user.first_name = entity.first_name;
            user.last_name = entity.last_name;
            user.age = entity.age;
            user.height = entity.height;
            user.weight = entity.weight;

            if (saveChanges)
            {
                return SaveChanges();
            }
            else return 0;
        }

        public int UpdateInfo(User entity, bool saveChanges = true)
        {
            var user = Entities.SingleOrDefault(u => u.id == entity.id);

            user.first_name = entity.first_name;
            user.last_name = entity.last_name;
            user.password = entity.password;
            user.weight = entity.weight;

            if (saveChanges)
            {
                return SaveChanges();
            }
            else
                return 0;
        }
    }
}
