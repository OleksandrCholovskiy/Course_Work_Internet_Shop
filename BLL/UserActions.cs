using System.Collections.Generic;
using AutoMapper;
using DAL;

namespace BLL
{
    public class UserActions : IUserActions
    {
        IMapper UsersM = new MapperConfiguration(cfg => cfg.CreateMap<User, MUser>()).CreateMapper();
        private readonly UnitOfWork uow;

        public UserActions(UnitOfWork uow)
        {
            this.uow = uow;
        }

        public UserActions()
        {
            DataContext context = new DataContext();
            uow = new UnitOfWork(context, new ContextRepository<Product>(context), new ContextRepository<Role>(context), new ContextRepository<User>(context));
        }

        public virtual List<MUser> GetUsers()
        {
            return UsersM.Map<IEnumerable<User>, List<MUser>>(uow.Users.Get());
        }

        public virtual MUser GetUserById(int id)
        {
            return UsersM.Map<User, MUser>(uow.Users.GetOne(x => (x.Id == id)));
        }

        public virtual bool AddUser(MUser newuser)
        {
            uow.Users.Create(new User { Name = newuser.Name, Id = newuser.Id, Login = newuser.Login, Pass = newuser.Pass, Role_FK = 3 });
            uow.Save();
            return true;
        }

        public virtual bool DeleteUserByID(int id)
        {
            uow.Users.Remove(uow.Users.FindById(id));
            uow.Save();
            return true;
        }
    }
}
