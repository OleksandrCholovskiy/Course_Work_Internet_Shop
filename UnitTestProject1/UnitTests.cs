using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using BLL;
using DAL;
using Moq;
using Assert = NUnit.Framework.Assert;
using System.Collections.Generic;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTests
    {
        private ProductActions _service;

        private Mock<UnitOfWork> _unitOfWork;

        private Mock<IGenericRepository<Product>> _productRepository;

        private List<Product> products;

        [TestInitialize]
        public void Initialize()
        {
            _productRepository = new Mock<IGenericRepository<Product>>();
            var rolesRepository = new Mock<IGenericRepository<Role>>();
            var userRepository = new Mock<IGenericRepository<User>>();
            var context = new Mock<DataContext>();

            _unitOfWork = new Mock<UnitOfWork>(context.Object, _productRepository.Object, rolesRepository.Object, userRepository.Object);

            _service = new ProductActions(_unitOfWork.Object);
        }


        [TestMethod]
        public void Get_ReturnsCorrectNumberOfServices()
        {
            //Arrange
            products = new List<Product>
            {
                new Product(){Name ="First"},
                 new Product(){Name ="Second"},
                  new Product(){Name ="Third"},

            };

            _productRepository.Setup(x => x.Get()).Returns(products);

            //Act
            var result = _service.GetProducts();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void Add_CalledCreateMethod()
        {
            //Arrange
            _productRepository.Setup(x => x.Create(It.IsAny<Product>()));

            //Act
            _service.AddProduct(new MProduct());

            //Assert
            _productRepository.Verify(x => x.Create(It.IsAny<Product>()), Times.Once);
        }

        [TestMethod]
        public void Update_CalledUpdateMethod()
        {
            //Arrange
            _productRepository.Setup(x => x.GetOne(It.IsAny<Func<Product, bool>>()))
                .Returns(new Product() { ID = 1, Name = "First" });

            _productRepository.Setup(x => x.Update(It.IsAny<Product>()));

            //Act
            _service.ChangeProduct(new MProduct());

            //Assert
            _productRepository.Verify(x => x.Update(It.IsAny<Product>()), Times.Once);
        }

        [TestMethod]
        public void GetByID_ReturnsCorrectNumber()
        {
            //Arrange
            var expectedService = new Product() { ID = 1, Name = "First" };
            _productRepository.Setup(x => x.GetOne(It.IsAny<Func<Product, bool>>()))
               .Returns(expectedService);

            //Act
            var result = _service.GetProductById(1);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedService.ID, result.ID);
            Assert.AreEqual(expectedService.Name, result.Name);
        }

        [TestMethod]
        public void RemoveByID_ReturnsCorrectNumber()
        {
            //Arrange
            var expectedService = new Product() { ID = 1, Name = "First" };
            _productRepository.Setup(x => x.Remove(expectedService));

            //Act
            _service.DeleteProductByID(1);

            //Assert
            _productRepository.Verify(x => x.Remove(It.IsAny<Product>()), Times.Once);
        }
    }
}
