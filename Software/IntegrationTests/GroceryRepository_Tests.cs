using BusinessLogicLayer;
using DataAccessLayer;
using IntegrationTests.TestHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class GroceryRepository_Tests
    {
        [Fact]
        public void AddGrocery_ReturnsNewGrocery()
        {
            //Arrange
            var groceryName = "burek";
            var groceryCalory = 300;

            // Act
            var grocery = GroceryRepository.AddGrocery(groceryName,groceryCalory);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Equal(groceryName, grocery.name);
                Assert.Equal(groceryCalory, grocery.calories);
            });
            var groceryHelper = new GroceryHelper();
            groceryHelper.DeleteGrocery(grocery.id);
        }

        [Fact]
        public void GetAll_ReturnAllGroceries()
        {
            // Act
            var grocery = GroceryRepository.GetAll();

            // Assert
            Assert.IsType<List<Grocery>>(grocery.ToList());
        }

        [Fact]
        public void GetGrocery_ReturnSpecificGrocery()
        {
            // Act
            var grocery = GroceryRepository.GetGrocery(1);

            // Assert
            Assert.Equal("parmezan", grocery[0].name);
        }

        [Fact]
        public void CheckGroceryDuplicates_GivenGroceryExistInDataBase_ReturnFalse()
        {
            // Act
            var grocery = GroceryRepository.CheckGroceryDuplicates("parmezan");

            // Assert
            Assert.False(grocery);
        }
    }
}
