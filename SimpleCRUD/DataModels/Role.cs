﻿using System;
using System.Collections.Generic;

namespace SimpleCRUD.DataModels;

public partial class Role
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;
}
