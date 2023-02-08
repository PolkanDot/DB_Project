﻿using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Image
{
    public int IdImage { get; set; }

    public string Url { get; set; } = null!;

    public short Type { get; set; } // 0 - account 1 - film 2 - actor 

    public int IdEntity { get; set; }

    public virtual ICollection<Account> Accounts { get; } = new List<Account>();

    public virtual ICollection<Actor> Actors { get; } = new List<Actor>();
}
