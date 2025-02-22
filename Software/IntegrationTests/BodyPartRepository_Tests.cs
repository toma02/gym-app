using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class BodyPartRepository_Tests
    {
        [Fact]
        public void GetBodyParts_ReturnsAllBodyParts()
        {
            // Arrange
            BodyPartRepository repository = new BodyPartRepository();

            // Act
            var bodyParts = repository.GetBodyParts();

            // Assert
            Assert.Equal(11, bodyParts.Count);
            Assert.Equal("Chest", bodyParts[0].name);
            Assert.Equal("Cardiovascular", bodyParts[10].name);
        }
    }
}
