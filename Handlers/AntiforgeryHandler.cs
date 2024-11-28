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
            var token = _antiforgery.GetAndStoreTokens(_httpContextAccessor.HttpContext).RequestToken;

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Add("RequestVerificationToken", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
