using AiEHuangYeGameServer.Model;
using AiEHuangYeGameServer.Util;
using MySqlX.XDevAPI;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AiEHuangYeGameServer.Manage
{
    internal class UserManage : IUserManage
    {
        public int Add(User user)
        {
            using(ISession session = DataBaseUtil.OpenSession())
            {
                using(ITransaction trans = session.BeginTransaction())
                {
                    int iss = -1;
                    try
                    {
                        iss = int.Parse(session.Save(user).ToString());
                        MyGameServer.logger.Info("保存的消息:" + iss);
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        MyGameServer.logger.Error("保存出错了：：：" + ex.Message);
                    }
                    return iss;

                }
            }
        }

        public void Delete(User user)
        {
            using (ISession session = DataBaseUtil.OpenSession())
            {
                using (ITransaction trans = session.BeginTransaction())
                {
                    session.Delete(user);
                    trans.Commit();
                }
            }
        }

        public void Update(User user)
        {
            using (ISession session = DataBaseUtil.OpenSession())
            {
                using (ITransaction trans = session.BeginTransaction())
                {
                    User u =  session.Load<User>(user.Id);
                    u.Name = user.Name;
                    u.Password = user.Password;
                    //session.Update(user);
                    trans.Commit();
                }
            }
        }

        public List<User> GetAll()
        {
            using (ISession session = DataBaseUtil.OpenSession())
            {
                IQueryable<User> users = session.Query<User>();
                return users.ToList();
            }
        }

        public User GetUserById(int id)
        {
            using (ISession session = DataBaseUtil.OpenSession())
            {
                return session.Get<User>(id);
            }
        }

        public User GetUserByName(string name)
        {
            using (ISession session = DataBaseUtil.OpenSession())
            {
                using(ITransaction trans = session.BeginTransaction())
                {
                    ICriteria criteria = session.CreateCriteria(typeof(User));
                    criteria.Add(Restrictions.Eq("Id", 17));
                    User user = criteria.UniqueResult<User>();
                    //user.Name = "我能修改吗";
                    //user.Password = "我还能修改密码啊  ";
                    //MyGameServer.logger.Info("大小是:" + ?.Password);
                    //foreach (User u in criteria.List<User>())
                    //{
                    //    MyGameServer.logger.Info(u.Name);
                    //    MyGameServer.logger.Info(u.Password);
                    //}

                    trans.Commit();
                    return null;
                }
            }
        }

        /// <summary>
        /// 登录
        /// </summary>
        public User Login(string username, string password)
        {
            using (ISession session = DataBaseUtil.OpenSession())
            {
                using (ITransaction trans = session.BeginTransaction())
                {
                    ICriteria criteria = session.CreateCriteria(typeof(User));
                    criteria.Add(Restrictions.Eq("Name", username));
                    criteria.Add(Restrictions.Eq("Password", password));
                    User user = criteria.UniqueResult<User>();

                    if (user != null) user.IsLogin = 1; // 修改登录的状态(数据库也同步更新)
                    trans.Commit();
                    return user;
                }
            }
        }

        /// <summary>
        /// 获得所有登录的用户
        /// </summary>
        public IList<User> GetLoginUser()
        {
            using (ISession session = DataBaseUtil.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(User));
                criteria.Add(Restrictions.Eq("IsLogin", 1));
                IList<User> user = criteria.List<User>();

                return user;
            }
        }
    }
}
