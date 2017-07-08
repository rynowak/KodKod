
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace KodKodSample.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[controller]")]
    public class ApiExplorerController : ControllerBase
    {
        private readonly IApiDescriptionGroupCollectionProvider _provider;

        public ApiExplorerController(IApiDescriptionGroupCollectionProvider provider)
        {
            _provider = provider;
        }

        public IActionResult Index()
        {
            var group = _provider.ApiDescriptionGroups.Items.Single();
            return Ok(group);
        }
    }
}
