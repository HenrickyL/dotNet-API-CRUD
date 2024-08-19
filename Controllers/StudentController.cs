using Microsoft.AspNetCore.Mvc;

namespace StudentApi.Controllers;


[Route("api/students")]
[ApiController]
public class StudentController : Controller
{
    [HttpGet]
    [ProducesResponseType(typeof(List<Object>), 200)]
    public ActionResult<List<Object>> Get() { 
        return new List<Object>();
    }
}
