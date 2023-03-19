namespace CVBackend.Controllers
{
    public class BaseController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        public const string BaseUrl = "https://localhost:7289"; // for now, TODO
        public const string ApiRoutePrefix = "api";
        public const string ApiRouteController = $"{ApiRoutePrefix}/[controller]";
    }
}
