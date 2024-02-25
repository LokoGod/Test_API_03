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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<TestDTO>> GetTests()
        {
            return Ok(TestStore.testList);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TestDTO> CreateTest([FromBody]TestDTO testDTO)
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            if(testDTO == null)
            {
                return BadRequest(testDTO);
            }
            if (testDTO.Id > 0) {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            testDTO.Id = TestStore.testList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            TestStore.testList.Add(testDTO);

            return CreatedAtRoute("GetSpecificTest", new { id = testDTO.Id }, testDTO);
        }

        [HttpGet("{id:int}", Name = "GetSpecificTest" /*Giving explicit name for the method*/)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<TestDTO> GetSpecificTest(int id) 
        {
            if ( id == 0 )
            {
                return BadRequest();
            }

            // u.Id == id is the condition used to filter elements,
            // It checks if the Id property of each element (u) is equal to the provided id variable.
            var test = TestStore.testList.FirstOrDefault(u => u.Id == id);

            if (test == null )
            {
                return NotFound();
            }
            return Ok(test);
        }

        [HttpDelete("${id}")]
        public ActionResult<TestDTO> DeleteSpecificTest(int id)
        {

        }
    }
}
