using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebExamenFinal.Areas.Maestro.Controllers;
using WebExamenFinal.Areas.Maestro.Models;
using WebExamenFinal.Model;
using WebExamenFinal.Repository;
using Xunit;

namespace WebDeveloper.Tests.Controllers
{
    public class PersonControllerTest
    {
        private ProductoController controller;
        private IRepository<Product> _repository;
        private Mock<DbSet<Product>> personDbSetMock;
        private Mock<WebContextDb> webContextMock;

        [Fact(DisplayName = "ListActionEmptyParametersTest")]
        private void ListActionEmptyParametersTest()
        {
            ListConfigMockData();
            controller = new ProductoController(_repository);
            var result = controller.List(null, null) as PartialViewResult;
            result.ViewName.Should().Be("_List");

            var modelCount = (IEnumerable<Product>)result.Model;
            modelCount.Count().Should().Be(10);
        }

        [Fact(DisplayName = "CreateGetTest")]
        private void CreateGetTest()
        {
            BasicConfigMockData();
            controller = new ProductoController(_repository);
            var result = controller.Create() as PartialViewResult;
            result.ViewName.Should().Be("_Create");

            var personModelCreate = (ProductoViewModel)result.Model;
            personModelCreate.Person.Should().NotBeNull();
        }

        [Fact(DisplayName = "CreatePostTestOk")]
        private void CreatePostTestOk()
        {
            BasicConfigMockData();
            controller = new ProductoController(_repository);
            var result = controller.Create(TestPersonOk()) as PartialViewResult;
            result.Should().BeNull();

            personDbSetMock.Verify(s => s.Add(It.IsAny<Product>()), Times.Once());
            webContextMock.Verify(c => c.SaveChanges(), Times.Once());
        }

        [Fact(DisplayName = "CreatePostTestWrong")]
        private void CreatePostTestWrong()
        {
            BasicConfigMockData();
            controller = new ProductoController(_repository);
            var personToFail = TestPersonWrong();
            controller.ModelState.AddModelError("errorTest", "errorTest");
            var result = controller.Create(personToFail) as PartialViewResult;
            result.ViewName.Should().Be("_Create");

            var productoModelCreate = (ProductoViewModel)result.Model;
            productoModelCreate.Product.Should().Be(personToFail);

        }


        [Fact(DisplayName = "EditGetTest")]
        private void EditGetTest()
        {
            ListConfigMockData();
            controller = new ProductoController(_repository);
            int personID = 2;
            var result = controller.Edit(personID) as PartialViewResult;
            result.ViewName.Should().Be("_Edit");

            var productoModelCreate = (ProductoViewModel)result.Model;
            productoModelCreate.Product.Should().NotBeNull();
        }

        [Fact(DisplayName = "EditPostTestOK")]
        private void EditPostTestOK()
        {
            ListConfigMockData();
            controller = new ProductoController(_repository);
            int id = 2;
            var result = controller.Edit(TestProductoEdit(id)) as PartialViewResult;
            result.Should().BeNull();
        }

        [Fact(DisplayName = "DeletePostTestOK")]
        private void DeletePostTestOK()
        {
            ListConfigMockData();
            controller = new ProductoController(_repository);
            int personID = 2;
            var result = controller.Eliminar(TestProductoEdit(personID)) as PartialViewResult;
            result.Should().BeNull();

        }

        [Fact(DisplayName = "DetailGetTest")]
        private void DetailGetTest()
        {
            ListConfigMockData();
            controller = new ProductoController(_repository);
            int id = 4;
            var result = controller.Detalle(id) as PartialViewResult;
            result.ViewName.Should().Be("_Details");

            var productoModelCreate = (ProductoViewModel)result.Model;
            productoModelCreate.Product.Should().NotBeNull();
        }


        #region Configuration Values
        public void PersonMockList()
        {
            var products = Enumerable.Range(1, 10).Select(i => new Product
            {

                ProductName = $"Name{i}",
               
               
            }).AsQueryable();
            productDbSetMock = new Mock<DbSet<Product>>();
            productDbSetMock.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            productDbSetMock.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            productDbSetMock.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            productDbSetMock.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(() => products.GetEnumerator());
        }
        private Product TestPersonOk()
        {
            var product = new Product
            {
               
                ProductName = "zapato",
                SupplierId = 3,
                UnitPrice = 2
            };
            
          
            return product;
        }
        private Product TestPersonWrong()
        {
            var product = new Product
            {
                ProductName = "cartera",
                SupplierId = 2
            };
           
            return product;
        }
        private void ListConfigMockData()
        {
            personDbSetMock = new Mock<DbSet<Product>>();
            PersonMockList();

            webContextMock = new Mock<WebContextDb>();
            webContextMock.Setup(m => m.Product).Returns(personDbSetMock.Object);
            webContextMock.Setup(m => m.Set<Product>()).Returns(personDbSetMock.Object);

            _repository = new BaseRepository<Product>(webContextMock.Object);
            controller = new ProductoController(_repository);
        }
        private void BasicConfigMockData()
        {
            personDbSetMock = new Mock<DbSet<Product>>();

            webContextMock = new Mock<WebContextDb>();
            webContextMock.Setup(m => m.Product).Returns(personDbSetMock.Object);
            webContextMock.Setup(m => m.Set<Product>()).Returns(personDbSetMock.Object);

            _repository = new BaseRepository<Product>(webContextMock.Object);
            controller = new ProductoController(_repository);
        }


        private Product TestPersonEdit(int id)
        {
            var product = new Product
            {
               
                ProductName = "Isabella",
                SupplierId =  1,
                UnitPrice = 12
            };
            product.Id = id;
         
            return product;
        }
        #endregion
    }
}
