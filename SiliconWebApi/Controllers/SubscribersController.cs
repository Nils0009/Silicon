using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace SiliconWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscribersController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            return Ok();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        } 
        return BadRequest();
    }
}
