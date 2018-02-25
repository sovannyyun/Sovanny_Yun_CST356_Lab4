using Sovanny_Yun_CST356_Lab3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sovanny_Yun_CST356_Lab3.Models;
using Sovanny_Yun_CST356_Lab3.Models.View;
using Sovanny_Yun_CST356_Lab3.Data.Entities;
using System.Web.Mvc;

namespace Sovanny_Yun_CST356_Lab3.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Create(User userData)
        {
            try
            {
                _dbContext.Users.Add(userData);

                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteUser(int id)
        {
            try
            {
                var user = _dbContext.Users.Find(id);

                if (user != null)
                {
                    _dbContext.Users.Remove(user);
                    _dbContext.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Edit(User userData)
        {


            try
            {
                var user = _dbContext.Users.Find(userData.Id);

                user.FirstName = userData.FirstName;
                user.MiddleName =userData.MiddleName;
                user.LastName = userData.LastName;
                user.EmailAddress = userData.EmailAddress;
                user.DateOfBirth = userData.DateOfBirth;
                user.YearInSchoo = userData.YearInSchoo;

                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public IEnumerable<User> GetAllUsers()
        {
            return _dbContext.Users;
        }

        public User GetUser(int id)
        {
            var user = _dbContext.Users.Find(id);
            return user;
        }
    }
}