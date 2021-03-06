﻿using System;
using System.Collections.Generic;
using System.Text;
using WorkingWithVisualStudio.Models;
using Xunit;

namespace WorkingWithVisualStudio.Tests
{
    public class ProductTest
    {
        [Fact]
        public void CanChangeProductName()
        {
            //Arrange
            var p = new Product { Name = "Test", Price = 100M };
            //Act
            p.Name = "New name";
            //Assert
            Assert.Equal("New name", p.Name);
        }
        [Fact]
        public void CanChangeProductPrice()
        {
            //Arrange
            var p = new Product { Name = "Test", Price = 100M };
            //Act
            p.Price = 200M;
            //Assert
            Assert.Equal(200M, p.Price);
        }
    }
}
