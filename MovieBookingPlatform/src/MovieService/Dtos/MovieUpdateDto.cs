﻿using System.ComponentModel.DataAnnotations;

namespace MovieService.Dtos;

public class MovieUpdateDto
{
    public long MovieId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public int DurationMinutes { get; set; }

    public string Language { get; set; }

    public string Genre { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public decimal? Rating { get; set; }

    public bool IsActive { get; set; } = true;
}
