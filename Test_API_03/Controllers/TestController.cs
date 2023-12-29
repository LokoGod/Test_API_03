using Microsoft.AspNetCore.Mvc;
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
            return new List<TestDTO>
            {
                new TestDTO{Id = 1, Name = "Kratos"},
                new TestDTO{Id = 2, Name = "Batman"}
            };
        }
    }
}
