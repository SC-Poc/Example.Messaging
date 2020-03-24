using System;
using System.Collections.Generic;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Publisher.WebApi.Models.IsAlive;
using Swisschain.Examples.Publisher.MessagingContract;
using Swisschain.Sdk.Server.Common;

namespace Publisher.WebApi
{
    [ApiController]
    [Route("api/isalive")]
    public class IsAliveController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public IsAliveController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IsAliveResponse), StatusCodes.Status200OK)]
        public IsAliveResponse Get()
        {
            var response = new IsAliveResponse
            {
                Name = ApplicationInformation.AppName,
                Version = ApplicationInformation.AppVersion,
                StartedAt = ApplicationInformation.StartedAt,
                Env = ApplicationEnvironment.Environment,
                HostName = ApplicationEnvironment.HostName,
                StateIndicators = new List<IsAliveResponse.StateIndicator>()
            };

            _publishEndpoint.Publish(new IsAliveTriggered
            {
                At = DateTime.UtcNow, 
                HostName = response.HostName
            });

            return response;
        }
    }
}
