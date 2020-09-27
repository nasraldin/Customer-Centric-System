using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace AccountService.Core.Common.Behaviours
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;

        public RequestLogger(ILogger<TRequest> logger)
        {
            _logger = logger;
        }


#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task Process(TRequest request, CancellationToken cancellationToken)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogInformation($"AccountService Request: {requestName} {request}");
        }
    }
}
