using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace API.Models;

public partial class Chatroom
{
    public int Id { get; set; }

    public string Topic { get; set; } = null!;

    [ValidateNever, BindNever]
    public virtual ICollection<Chatmessage> Chatmessages { get; set; } = new List<Chatmessage>();

    [ValidateNever, BindNever]
    public virtual ICollection<ChatroomEmployee> ChatroomEmployees { get; set; } = new List<ChatroomEmployee>();
}
