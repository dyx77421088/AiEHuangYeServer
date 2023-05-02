using NHibernate;
using NHibernate.Cfg;

namespace AiEHuangYeGameServer.Util
{
    public class DataBaseUtil
    {
        private static ISessionFactory factory;

        private static ISessionFactory Factory 
        { 
            get 
            { 
                if (factory == null)
                {
                    Configuration config = new Configuration();
                    config.Configure(); // 解析 hibernate.cfg 可以指定名字，默认找这个 hibernate.cfg.xml
                    config.AddAssembly("AiEHuangYeGameServer"); // 添加程序集，右击属性可以看到

                    factory = config.BuildSessionFactory();
                }
                return factory;
            } 
        }

        public static ISession OpenSession()
        {
            return Factory.OpenSession();
        }
    }
}
