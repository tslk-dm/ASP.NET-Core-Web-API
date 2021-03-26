using MetricsManager.Controllers;
using MetricsManager;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class AgentsControllerUnitTests
    {
        private AgentsController _controller;
        public AgentsControllerUnitTests()
        {
            _controller = new AgentsController();
        }

        [Fact]
        public void RegisterAgent_ReturnsOk()
        {
            //Arrange
            var agentInfo = new AgentInfo
            {
                AgentId = 1,
                AgentAddress = new Uri("http://www.contoso.com/")
            };
            //Act
            var result = _controller.RegisterAgent(agentInfo);
            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public void EnableAgentById_ReturnsOk()
        {
            //Arrange
            var agentId = 1;
            //Act
            var result = _controller.EnableAgentById(agentId);
            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void DisableAgentById_ReturnsOk()
        {
            //Arrange
            var agentId = 1;
            //Act
            var result = _controller.DisableAgentById(agentId);
            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void ReadRegisterAgents_ReturnsOk()
        {
            //Act
            var result = _controller.ReadRegisterAgents();
            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

    }
    
}
