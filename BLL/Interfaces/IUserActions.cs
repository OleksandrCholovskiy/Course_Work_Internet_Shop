using System.Collections.Generic;

namespace BLL
{
    /// <summary>
    /// Интерфейс для сервиса пользователей
    /// </summary>
    interface IUserActions
    {
        List<MUser> GetUsers();

        MUser GetUserById(int id);

        bool AddUser(MUser newuser);

        bool DeleteUserByID(int id);
    }
}
