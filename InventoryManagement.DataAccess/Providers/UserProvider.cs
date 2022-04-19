using System;
using System.Collections.Generic;
using System.Text;
using InventoryManagement.DataAccess.Models;
using System.Linq;

namespace InventoryManagement.DataAccess.Providers
{
    public class UserProvider
    {
        public List<UserTable> ListUser()
        {
            using(var dbContext = new INVENTORYMANAGEMENTContext())
            {
                return dbContext.UserTable.ToList();
            }
        }


        public UserTable GetUser(int userId)
        {
            using (var dbContext = new INVENTORYMANAGEMENTContext())
            {
                var user = (from i in dbContext.UserTable
                            where i.UserId == userId
                            select i).FirstOrDefault();
                return user;
            }
        }


        public bool InsertUser(int userId, string userName)
        {
            try
            {
                using (var dbContext = new INVENTORYMANAGEMENTContext())
                {
                    UserTable userTable = new UserTable();
                    //userTable.UserId = userId;
                    userTable.UserName = userName;
                    dbContext.UserTable.Add(userTable);
                    dbContext.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.InnerException.Message);
                throw;
            }
        }

        public bool UpdateUser(int userId, string userName)
        {
            try
            {
                using (var dbContext = new INVENTORYMANAGEMENTContext())
                {
                    var user = (from b in dbContext.UserTable
                                where b.UserId == userId
                                select b).FirstOrDefault();
                    user.UserId = userId;
                    user.UserName = userName;
                    dbContext.UserTable.Update(user);
                    dbContext.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.InnerException.Message);
                throw;
            }
        }


        public bool DeleteUser(int userId, string userName)
        {
            try
            {
                using (var dbContext = new INVENTORYMANAGEMENTContext())
                {
                    var user = (from b in dbContext.UserTable
                                where b.UserId == userId
                                select b).FirstOrDefault();
                    user.UserId = userId;
                    user.UserName = userName;
                    dbContext.UserTable.Remove(user);
                    dbContext.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.InnerException.Message);
                throw;
            }
        }
    }
}
