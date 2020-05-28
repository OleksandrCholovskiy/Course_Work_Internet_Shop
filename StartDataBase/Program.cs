using DAL;

namespace StartDataBase
{
    class Program
    {
        static void Main(string[] args)
        {

            using (DataContext dataContext = new DataContext())
            {
                dataContext.Roles.Add(new Role() { Role_name = "Адміністратор" });
                dataContext.Roles.Add(new Role() { Role_name = "Менеджер" });
                dataContext.Roles.Add(new Role() { Role_name = "Зареєстрований" });
                dataContext.Roles.Add(new Role() { Role_name = "Незареєстрований" });

                dataContext.SaveChanges();

                dataContext.Users.Add(new User() { Login = "Admin", Pass = "Admin", Role_FK = 1, Name = "Andrew" });
                dataContext.Users.Add(new User() { Login = "Meneger", Pass = "Meneger", Role_FK = 2, Name = "Max" });
                dataContext.Users.Add(new User() { Login = "UserRegistered", Pass = "UserRegistered", Role_FK = 3, Name = "Dima" });
                dataContext.Users.Add(new User() { Login = "UserUnregistered", Pass = "UserUnregistered", Role_FK = 4, Name = "Anton" });

                dataContext.SaveChanges();

                dataContext.Products.Add(new Product() { Name = "Кроссовки", Info = "Черные , 45 размер", Category = "Одежда", Price = 3500 });
                dataContext.Products.Add(new Product() { Name = "Телефон", Info = "Xiaomi Mi A1 64 GB", Category = "Техника", Price = 6000 });
                dataContext.Products.Add(new Product() { Name = "Планшет", Info = "Ipad Air 128 GB", Category = "Техника", Price = 9500 });

                dataContext.SaveChanges();
            }
        }
    }
}
