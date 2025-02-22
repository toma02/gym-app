using BusinessLogicLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class EquipmentRepository_Tests
    {
        [Fact]
        public void GetEquipment2_ReturnsAllEquipment()
        {
            // Arrange
            EquipmentRepository repository = new EquipmentRepository();

            // Act
            var equipment = repository.GetEquipment2();

            // Assert
            Assert.Equal(10, equipment.Count);
            Assert.Equal("Machine", equipment[0].name);
            Assert.Equal("Stationary Bicycle", equipment[9].name);
        }
    }
}
