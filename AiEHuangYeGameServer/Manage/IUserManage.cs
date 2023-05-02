using AiEHuangYeGameServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiEHuangYeGameServer.Manage
{
    internal interface IUserManage
    {
        int Add(User user);
        void Update(User user);
        void Delete(User user);
        List<User> GetAll();
        User GetUserById(int id);
        User GetUserByName(string name);
        User Login(string username, string password);
        IList<User> GetLoginUser();
    }
}
