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
    public class HddMetricsControllerUnitTests
    {
        private HddMetricsController controller;
        private Mock<IHddMetricsRepository> mock;
        private Mock<ILogger<HddMetricsController>> mock_logger;

        public HddMetricsControllerUnitTests()
        {
            mock = new Mock<IHddMetricsRepository>();
            mock_logger = new Mock<ILogger<HddMetricsController>>();

            controller = new HddMetricsController(mock.Object, mock_logger.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // устанавливаем параметр заглушки
            // в заглушке прописываем что в репозиторий прилетит HddMetric объект
            mock.Setup(repository => repository.Create(It.IsAny<HddMetric>())).Verifiable();

            // выполняем действие на контроллере
            var result = controller.Create(new MetricsAgent.Requests.HddMetricCreateRequest { Time = 1, Value = 50 });

            // проверяем заглушку на то, что пока работал контроллер
            // действительно вызвался метод Create репозитория с нужным типом объекта 
            // в параметре
            mock.Verify(repository => repository.Create(It.IsAny<HddMetric>()), Times.AtMostOnce());
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            //Arrange

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
//    public class HddControllerUnitTests
//    {
//        private HddMetricsController _controller;
//        public HddControllerUnitTests()
//        {
//            _controller = new HddMetricsController();
//        }

//        [Fact]
//        public void GetMetricsFromAgent_ReturnsOk()
//        {
//            //Arrange

//            //Act
//            var result = _controller.GetMetricsFromAgent();
//            // Assert
//            _ = Assert.IsAssignableFrom<IActionResult>(result);
//        }
//    }
//}
