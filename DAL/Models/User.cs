using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    /// <summary>
    /// Модель пользователя
    /// </summary>
    public partial class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }
        public int? Role_FK { get; set; }
        public string Name { get; set; }
        [ForeignKey("Role_FK")]
        public virtual Role Role { get; set; }
    }
}
