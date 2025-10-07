using System.Net.Http.Headers;

public class AuthMessageHandler : DelegatingHandler
{
    private readonly IHttpContextAccessor _ctx;

    public AuthMessageHandler(IHttpContextAccessor ctx) => _ctx = ctx;

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = _ctx.HttpContext?.Session.GetString("JWT");
        if (!string.IsNullOrEmpty(token))
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return base.SendAsync(request, cancellationToken);
    }
}