using System.ComponentModel.DataAnnotations;

namespace DAL
{
    /// <summary>
    /// Модель роли пользователя
    /// </summary>
    public partial class Role
    {
        [Key] 
        public int Id { get; set; }
        public string Role_name { get; set; }
    }
}
