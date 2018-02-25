using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sovanny_Yun_CST356_Lab3.Data.Entities;
using System.Web.Mvc;
using Sovanny_Yun_CST356_Lab3.Models.View;

namespace Sovanny_Yun_CST356_Lab3.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        bool Create(User userData);
        User GetUser(int id);
        bool Edit(User userData);
        bool DeleteUser(int id);
    }
}
