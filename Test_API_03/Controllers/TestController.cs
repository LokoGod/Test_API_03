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
            if (id == 0)
            {
                return BadRequest();
            }
            var test = TestStore.testList.FirstOrDefault(element => element.Id == id);
            if (test == null)
            {
                return NotFound();
            }
            return Ok(test);
        }
    }
}

// : - inherits
// ActionResult - allows to send status codes
// IEnumerable - Iterate through the data set (i think)
// Ok - sends 200 status code
// BadRequest - 400
// NotFound - 404
//FirstOrDefault (LINQ query), ((element => element.Id == id), a lambda expression where element is a parameter and tells the LINQ query
                                                                                        //to return the resuslts based on the expression)
