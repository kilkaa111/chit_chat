using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace API.Models;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    [ValidateNever, BindNever]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
