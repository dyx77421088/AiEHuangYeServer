
namespace AiEHuangYeGameServer.Model
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Password { get; set; }
        public virtual int IsLogin { get; set; }
        public virtual long CreateTime { get; set; }
    }
}
