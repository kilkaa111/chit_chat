using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace API.Models;

public partial class Chatmessage
{
    public int Id { get; set; }

    public int SenderId { get; set; }

    public int ChatroomId { get; set; }

    public DateTime Date { get; set; }

    public string Message { get; set; } = null!;

    [ValidateNever, BindNever]
    [JsonIgnore]
    public virtual Chatroom Chatroom { get; set; } = null!;

    [ValidateNever, BindNever]
    [JsonIgnore]
    public virtual Employee Sender { get; set; } = null!;
}
