﻿namespace Backend.Models;

public partial class RequestTags
{
    public Request Request { get; set; } 

    public Tag[] Tags { get; set; } = [];
}
