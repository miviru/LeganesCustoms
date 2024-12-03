using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace LeganesCustomsBlazor.Handlers
{
    public class AntiforgeryHandler : DelegatingHandler
    {
        private readonly IAntiforgery _antiforgery;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AntiforgeryHandler(IAntiforgery antiforgery, IHttpContextAccessor httpContextAccessor)
        {
            _antiforgery = antiforgery;
            _httpContextAccessor = httpContextAccessor;
        }

       protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
            {
                Console.WriteLine("HttpContext is null. Cannot add antiforgery token.");
                throw new InvalidOperationException("No HttpContext available.");
            }

            var tokens = _antiforgery.GetAndStoreTokens(httpContext);

            if (string.IsNullOrEmpty(tokens.RequestToken))
            {
                Console.WriteLine("Antiforgery token is null or empty.");
            }
            else
            {
                request.Headers.Add("RequestVerificationToken", tokens.RequestToken);
            }

            return await base.SendAsync(request, cancellationToken);
        }

    }
}
