using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace API.Models;

public partial class ChatroomEmployee
{
    public int Id { get; set; }

    public int? EmployeeId { get; set; }

    public int? ChatroomId { get; set; }

    [ValidateNever, BindNever]
    [JsonIgnore]
    public virtual Chatroom? Chatroom { get; set; }

    [ValidateNever, BindNever]
    [JsonIgnore]
    public virtual Employee? Employee { get; set; }
}
