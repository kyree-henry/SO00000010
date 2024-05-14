﻿using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace SO00000010.Presentation
{
    public class HealthCheck : IHealthCheck
    {
        private readonly ILogger<HealthCheck> _logger;

        public HealthCheck(ILogger<HealthCheck> logger)
        {
            _logger = logger;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            _logger.LogInformation($"Health check success");
            return Task.FromResult(HealthCheckResult.Healthy());
        }
    }
}