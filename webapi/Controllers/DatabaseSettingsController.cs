using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DatabaseSettingsController : ControllerBase
    {
        private readonly DatabaseSettings _databaseSettings;
        
        public DatabaseSettingsController(IOptions<DatabaseSettings> databaseSettings)
        {
            _databaseSettings = databaseSettings.Value;
        }

        [HttpGet]
        public DatabaseSettings Get()
        {
            return _databaseSettings;
        }
    }
}
