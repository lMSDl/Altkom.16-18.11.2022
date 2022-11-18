using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthChecks.Services
{
    public class RandomHelath : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {

            var value = DateTime.Now.Second % 3;

            if(value == 0)
            {
                return Task.FromResult(HealthCheckResult.Healthy());
            }

            if(value == 1)
            {
                return Task.FromResult(HealthCheckResult.Unhealthy("..."));
            }

            return Task.FromResult(HealthCheckResult.Degraded("I need help...",
                data: new Dictionary<string, object?>() { { "klucz1", "wartość1" }, { "klucz2", "wartość2" } }!));

        }
    }
}
