using System.Collections.Generic;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace TestProject
{
    public class PatientsControllerTests
    {
        [Fact]
        public async Task PatientsController_ReturnsPatients()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var dbContext = new AppDbContext(options);

            var patientsController = new PatientsController(dbContext);

            // Act
            var actionResult = await patientsController.GetPatients();
            var result = actionResult.Value;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Patient>>(result);
        }
    }
}
