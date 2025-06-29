﻿namespace GameDevsConnect.Backend.API.Configuration.DTOs;

public partial class FileDTO
{
    public string Id { get; set; } = null!;

    public string Type { get; set; } = string.Empty;

    public int? Size { get; set; }

    public string? Created { get; set; }

    public string? OwnerId { get; set; }
}
