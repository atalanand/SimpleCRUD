using System;
using System.Collections.Generic;

namespace SimpleCRUD.DataModels;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int RoleId { get; set; }

    public int StateId { get; set; }

    public string Address { get; set; } = null!;

    public DateTime UpdatedDate { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual State State { get; set; } = null!;
}
