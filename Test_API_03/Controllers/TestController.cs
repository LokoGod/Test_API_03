using Microsoft.AspNetCore.Mvc;
using Test_API_03.Data;
using Test_API_03.Models;
using Test_API_03.Models.DTO;

namespace Test_API_03.Controllers
{
    //[Route("api/v1/[controller]"]
    [Route("api/v1/Test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<TestDTO> GetTestModels()
        {
            return TestStore.testList;
        }
    }
}
