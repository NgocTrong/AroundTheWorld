using System.Collections.Generic;
using System.Linq;
using Models.EF;

namespace Models.Dao
{
    public class UserDao
    {
        TravelDbContext db;
        public UserDao()
        {
            db = new TravelDbContext();
        }

        //User Login
        public int Login(string userName, string passWord)
        {
            var result = db.Users.FirstOrDefault(m => m.UserName == userName);
            if (result == null)
            {
                return -1;
            }
            else
            {

                if (result.Status == false)
                {
                    return 0;
                }
                else
                {
                    if (result.PassWord == passWord)
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }

            }
        }


        //get userId
        public User GetById(string userName)
        {
            return db.Users.FirstOrDefault(m => m.UserName == userName);

        }

        //Insert user
        public int Insert(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user.UserId;
        }

        //List User
        public List<User> listUser()
        {
            return db.Users.ToList();
        }


        //delete user 
        public void Delete(int userId)
        {
            var user = db.Users.Find(userId);
            db.Users.Remove(user);
            db.SaveChanges();
        }
    }
}
