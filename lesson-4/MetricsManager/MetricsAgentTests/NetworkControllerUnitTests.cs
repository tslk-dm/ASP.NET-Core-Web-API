using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using MetricsAgent.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace MetricsAgentTests
{
    public class NetworkMetricsControllerUnitTests
    {
        private NetworkMetricsController controller;
        private Mock<INetworkMetricsRepository> mock;
        private Mock<ILogger<NetworkMetricsController>> mock_logger;

        public NetworkMetricsControllerUnitTests()
        {
            mock = new Mock<INetworkMetricsRepository>();
            mock_logger = new Mock<ILogger<NetworkMetricsController>>();

            controller = new NetworkMetricsController(mock.Object, mock_logger.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // устанавливаем параметр заглушки
            // в заглушке прописываем что в репозиторий прилетит NetworkMetric объект
            mock.Setup(repository => repository.Create(It.IsAny<NetworkMetric>())).Verifiable();

            // выполняем действие на контроллере
            var result = controller.Create(new MetricsAgent.Requests.NetworkMetricCreateRequest { Time = 1, Value = 50 });

            // проверяем заглушку на то, что пока работал контроллер
            // действительно вызвался метод Create репозитория с нужным типом объекта 
            // в параметре
            mock.Verify(repository => repository.Create(It.IsAny<NetworkMetric>()), Times.AtMostOnce());
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            //Arrange
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);
            //Act
            var result = controller.GetMetricsFromAgent(fromTime, toTime);
            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}




//using MetricsAgent.Controllers;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using Xunit;

//namespace MetricsAgentTests
//{
//    public class NetworkControllerUnitTests
//    {
//        private NetworkMetricsController _controller;
//        public NetworkControllerUnitTests()
//        {
//            _controller = new NetworkMetricsController();
//        }

//        [Fact]
//        public void GetMetricsFromAgent_ReturnsOk()
//        {
//            //Arrange
//            var fromTime = TimeSpan.FromSeconds(0);
//            var toTime = TimeSpan.FromSeconds(100);
//            //Act
//            var result = _controller.GetMetricsFromAgent(fromTime, toTime);
//            // Assert
//            _ = Assert.IsAssignableFrom<IActionResult>(result);
//        }
//    }
//}
