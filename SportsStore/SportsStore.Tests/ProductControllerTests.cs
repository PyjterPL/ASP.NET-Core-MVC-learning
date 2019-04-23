using Moq;
using SportsStore.Controllers;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace SportsStore.Tests
{
    public class ProductControllerTests
    {
        private Mock<IProductRepository> repoMock;
        private ProductController controller;

        public ProductControllerTests()
        {
            repoMock = new Mock<IProductRepository>();
            repoMock.Setup(m => m.Products).Returns((new Product[] {
                new Product {ProductID = 1, Name = "P1", Category = "Cat1"},
                new Product {ProductID = 2, Name = "P2", Category = "Cat2"},
                new Product {ProductID = 3, Name = "P3", Category = "Cat1"},
                new Product {ProductID = 4, Name = "P4", Category = "Cat2"},
                new Product {ProductID = 5, Name = "P5", Category = "Cat3"}
            }).AsQueryable<Product>());

            controller = new ProductController(repoMock.Object);
            controller.PageSize = 3;
        }
        [Fact]
        public void Can_Send_Pagination_View_Model()
        {
            // Arrange
            // Act
            var result = controller.List(null,2).ViewData.Model as ProductsListViewModel;
            // Assert
            var pageInfo = result.PagingInfo;
            Assert.Equal(2, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.ItemsPerPage);
            Assert.Equal(5, pageInfo.TotalItems);
            Assert.Equal(2, pageInfo.TotalPages);
        }

        [Fact]
        public void Can_Paginate()
        {
            // Arrange
            // Act
            var result =
            controller.List(null,2).ViewData.Model as ProductsListViewModel;
            // Assert
            Product[] prodArray = result.Products.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P4", prodArray[0].Name);
            Assert.Equal("P5", prodArray[1].Name);
        }
        [Fact]
        public void Can_Filter_Products()
        {
            // Arrange
            // Act
            var result =
            controller.List("Cat2").ViewData.Model as ProductsListViewModel;
            // Assert
            Product[] prodArray = result.Products.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P2", prodArray[0].Name);
            Assert.Equal("Cat2", prodArray[0].Category);

            Assert.Equal("P4", prodArray[1].Name);
            Assert.Equal("Cat2", prodArray[1].Category);
        }

    }
}
