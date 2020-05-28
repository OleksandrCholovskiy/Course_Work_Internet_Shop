namespace BLL
{
    /// <summary>
    /// Dto для пользователя
    /// </summary>
    public partial class MUser
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }

        public int Role_FK { get; set; }
        public string Name { get; set; }
        public virtual MRole Role { get; set; }
    }
}
