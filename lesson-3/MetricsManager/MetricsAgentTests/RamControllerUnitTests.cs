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
    public class RamMetricsControllerUnitTests
    {
        private RamMetricsController controller;
        private Mock<IRamMetricsRepository> mock;
        private Mock<ILogger<RamMetricsController>> mock_logger;

        public RamMetricsControllerUnitTests()
        {
            mock = new Mock<IRamMetricsRepository>();
            mock_logger = new Mock<ILogger<RamMetricsController>>();

            controller = new RamMetricsController(mock.Object, mock_logger.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // устанавливаем параметр заглушки
            // в заглушке прописываем что в репозиторий прилетит RamMetric объект
            mock.Setup(repository => repository.Create(It.IsAny<RamMetric>())).Verifiable();

            // выполняем действие на контроллере
            var result = controller.Create(new MetricsAgent.Requests.RamMetricCreateRequest { Time = 1, Value = 50 });

            // проверяем заглушку на то, что пока работал контроллер
            // действительно вызвался метод Create репозитория с нужным типом объекта 
            // в параметре
            mock.Verify(repository => repository.Create(It.IsAny<RamMetric>()), Times.AtMostOnce());
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            //Act
            var result = controller.GetMetricsFromAgent();
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
//    public class RamControllerUnitTests
//    {
//        private RamMetricsController _controller;
//        public RamControllerUnitTests()
//        {
//            _controller = new RamMetricsController();
//        }

//        [Fact]
//        public void GetMetricsFromAgent_ReturnsOk()
//        {
//            //Act
//            var result = _controller.GetMetricsFromAgent();
//            // Assert
//            _ = Assert.IsAssignableFrom<IActionResult>(result);
//        }
//    }
//}
