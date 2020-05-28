using System.Collections.Generic;
using DAL;
using AutoMapper;

namespace BLL
{
    public class ProductActions : IProductActions
    {
        IMapper ProductM = new MapperConfiguration(cfg => cfg.CreateMap<User, MUser>()).CreateMapper();
       
        private readonly UnitOfWork uow;

        public ProductActions(UnitOfWork uow)
        {
            this.uow = uow;
        }

        public ProductActions()
        {
            DataContext context = new DataContext();
            uow = new UnitOfWork(context, new ContextRepository<Product>(context), new ContextRepository<Role>(context), new ContextRepository<User>(context));
        }


        public virtual List<MProduct> GetProducts()
        {
            return ProductM.Map<IEnumerable<Product>, List<MProduct>>(uow.Products.Get());
        }

        public virtual MProduct GetProductById(int id)
        {
            return ProductM.Map<Product, MProduct>(uow.Products.GetOne(x => (x.ID == id)));
        }

        public virtual bool AddProduct(MProduct newproduct)
        {
            uow.Products.Create(new Product {Name = newproduct.Name, Category = newproduct.Category , ID = newproduct.ID , Info = newproduct.Info , Price = newproduct.Price});
            uow.Save();
            return true;
        }

        public virtual bool DeleteProductByID(int id)
        {
            uow.Products.Remove(uow.Products.FindById(id));
            uow.Save();
            return true;
        }


        public virtual bool ChangeProduct(MProduct newproduct)
        {   
           
            uow.Products.Update(new Product { Name = newproduct.Name, Category = newproduct.Category, ID = newproduct.ID, Info = newproduct.Info, Price = newproduct.Price });
            uow.Save();
            return true;
        }
    }
}
