using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public record LoginParameters(string password, string username);


[ApiController]
[Route("[controller]")]
public class EmployeeController(ChatContext db) : ControllerBase
{


    [HttpGet("{Id:int}")]
    public IActionResult Get(int Id)
    {
        var user = db.Employees.Find(Id);

        if (user == null)
        {
            return NotFound("nasas");
        }

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginParameters parameters)
    {
        var user = await db.Employees.FirstOrDefaultAsync(p => p.Username == parameters.username && p.Password == parameters.password);
        if (user == null)
        {
            return NotFound("nasas");
        }

        return Ok(user);

    }

}
