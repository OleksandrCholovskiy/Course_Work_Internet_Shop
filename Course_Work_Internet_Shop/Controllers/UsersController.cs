using BLL;
using System.Collections.Generic;
using System.Web.Http;

namespace Course_Work_Internet_Shop.Controllers
{
    /// <summary>
    /// Контроллер для пользователей
    /// </summary>
    public class UsersController : ApiController
    {
        // GET: api/Users
        public IEnumerable<MUser> Get()
        {
            UserActions u1 = new UserActions();
            return u1.GetUsers();
        }

        // GET: api/Users/5
        public MUser Get(int id)
        {
            UserActions u1 = new UserActions();
            return u1.GetUserById(id);
        }

        // POST: api/Users
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
            UserActions u1 = new UserActions();
            u1.DeleteUserByID(id);
        }
    }
}
