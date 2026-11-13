using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace API.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int DepartmentId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Salt { get; set; }

    [ValidateNever, BindNever]
    public virtual ICollection<Chatmessage> Chatmessages { get; set; } = new List<Chatmessage>();

    [ValidateNever, BindNever]
    public virtual ICollection<ChatroomEmployee> ChatroomEmployees { get; set; } = new List<ChatroomEmployee>();

    [ValidateNever, BindNever]
    [JsonIgnore]
    public virtual Department Department { get; set; } = null!;
}
