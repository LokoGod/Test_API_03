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
        public ActionResult<IEnumerable<TestDTO>> GetTestModels()
        {
            return Ok(TestStore.testList);
        }

        [HttpGet("{id:int}")]
        public ActionResult<TestDTO> GetTestModel(int id) 
        {
            if ( id == 0 )
            {
                return BadRequest();
            }

            var test = TestStore.testList.FirstOrDefault(u => u.Id == id);

            if (test == null )
            {
                return NotFound();
            }
            return Ok(test);
        }
    }
}
