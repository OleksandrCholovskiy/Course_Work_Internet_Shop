using BLL;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Course_Work_Internet_Shop.Controllers
{
    /// <summary>
    /// Контроллер авторизации
    /// </summary>
    public class AutoController : ApiController
    {
        // GET: api/Auto
        public IEnumerable<string> Get()
        {
            return new string[] { "", "" };
        }

        // GET: api/Auto/5
        public string Get(int id)
        {
            return "";
        }

        // POST: api/Auto
        [HttpPost]
        public string Check([FromBody]object data)
        {
            UserActions ua = new UserActions();
            MUser Str = JsonConvert.DeserializeObject<MUser>(data.ToString());
            MUser login = ua.GetUsers().Where(l => Str.Login == l.Login && Str.Pass == l.Pass).FirstOrDefault();
            if(login == null)
            {
                return null;
            }
            else
            {
                return login.Role.Role_name;
            }
        }

        // PUT: api/Auto/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Auto/5
        public void Delete(int id)
        {
        }
    }
}
