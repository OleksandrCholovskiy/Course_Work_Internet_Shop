using BLL;
using System.Collections.Generic;
using System.Web.Http;

namespace Course_Work_Internet_Shop.Controllers
{
    /// <summary>
    /// Контроллер для регистрации пользователей
    /// </summary>
    public class RegController : ApiController
    {
        // GET: api/Reg
        public IEnumerable<string> Get()
        {
            return new string[] { "", "" };
        }

        // GET: api/Reg/5
        public string Get(int id)
        {
            return "";
        }

        // POST: api/Reg
        [HttpPost]
        public void Post([FromBody]MUser value)
        {
            UserActions ua = new UserActions();
            value.Role_FK = 3;
            ua.AddUser(value);
        }

        // PUT: api/Reg/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Reg/5
        public void Delete(int id)
        {
        }
    }
}
