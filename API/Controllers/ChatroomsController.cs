using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public record ChatroomemployeeWithLastMessage(int Id, string Topic, string Date);
public record Chatroomwithmembersandmessages(Chatroom Chatroom, List<ChatroomEmployee> Employees, List<Chatmessage> Chatmessages);

[ApiController]
[Route("[controller]")]
public class ChatroomsController(ChatContext db) : ControllerBase
{
    [HttpGet("{Id:int}")]
    public async Task<IActionResult> GetChatrooms(int Id)
    {
        var chatrooms = await db.Chatrooms
        .Where(c => c.ChatroomEmployees.Any(m => m.EmployeeId == Id)
        )
        .Select(c =>
            new ChatroomemployeeWithLastMessage(
                c.Id,
                c.Topic,
                c.Chatmessages.OrderByDescending(msg => msg.Date).First().Date.ToShortDateString()
            )
        )
        .ToListAsync();

        return Ok(chatrooms);
    }

    [HttpGet("chat/{Id:int}")]
    public async Task<IActionResult> GetChatroom(int Id)
    {
        var chatroom = await db.Chatrooms.Where(i => i.Id == Id).Select(q =>
            new Chatroomwithmembersandmessages(
                q,
                q.ChatroomEmployees.ToList(),
                q.Chatmessages.ToList()
            ))
            .FirstOrDefaultAsync();

        if (chatroom == null)
             return NotFound();

        return Ok(chatroom);
        
    }


}