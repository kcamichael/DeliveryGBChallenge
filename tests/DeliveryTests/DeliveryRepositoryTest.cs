using DeliveryService.Repository;

namespace DeliveryTests;

public class DeliveryRepositoryTest
{
    private DeliveryRepository _dRepo;
    public DeliveryRepositoryTest()
    {
        _dRepo = new DeliveryRepository();
    }
    [Fact]
    public void AddDelivery_ShouldReturnTrue()
    {
        // Arrange
        var del = new Delivery(new DateTime(2023, 5, 20), new DateTime(2023, 5, 20).AddDays(7), 001, 5, 1);

        // Act
        bool isSuccess = _dRepo.AddDelivery(del);

        // Assert
        Assert.True(isSuccess);
    }


    [Fact]
    public void GetEnrouteDeliveries_ShouldReturnCorrectCount()
    {
        // Arrange

        // Act
        int expectedCount = 1;
        int actualCount = _dRepo.GetAllEnrouteDeliveries().Count;

        // Assert
        Assert.Equal(expectedCount, actualCount);
    }

        [Fact]
    public void GetCompletedDeliveries_ShouldReturnCorrectCount()
    {
        // Arrange

        // Act
        int expectedCount = 2;
        int actualCount = _dRepo.GetAllCompleteDeliveries().Count;

        // Assert
        Assert.Equal(expectedCount, actualCount);
    }

}