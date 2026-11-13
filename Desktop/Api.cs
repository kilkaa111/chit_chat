using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using API.Controllers;
using API.Models;

namespace Desktop;

public static class Api 
{
    public static HttpClient Http {get ; } = new()
    {
        BaseAddress = new Uri("http://localhost:5256/")
    };

    public static async Task<Employee> Loginuser(string username, string password)
    {
        var response = await Http.PostAsJsonAsync("Employee",new LoginParameters(password,username));

        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        return new ();

        var frombody = await response.Content.ReadFromJsonAsync<Employee>();
         return frombody;
    }

    public async static Task<List<ChatroomemployeeWithLastMessage>> GetChatrooms(int Id)
    {
        return await Http.GetFromJsonAsync<List<ChatroomemployeeWithLastMessage>>($"Chatrooms/{Id}");
        
    }

    public async static Task<Chatroomwithmembersandmessages> GetChatroom(int Id)
    {
        return await Http.GetFromJsonAsync<Chatroomwithmembersandmessages>($"Chatrooms/chat/{Id}");
        
    }
}
