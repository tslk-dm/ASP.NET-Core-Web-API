﻿using MetricsAgent.Controllers;
using MetricsAgent;
using MetricsManager;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsAgentTests
{
    public class RamControllerUnitTests
    {
        private RamMetricsController _controller;
        public RamControllerUnitTests()
        {
            _controller = new RamMetricsController();
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            //Arrange
            var agentId = 1;
            //Act
            var result = _controller.GetMetricsFromAgent(agentId);
            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}