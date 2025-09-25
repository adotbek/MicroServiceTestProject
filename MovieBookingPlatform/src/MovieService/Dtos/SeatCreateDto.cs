﻿using System.ComponentModel.DataAnnotations;

namespace MovieService.Dtos;

public class SeatCreateDto
{
    public string SeatNumber { get; set; }

    public string Row { get; set; }

    public bool IsVip { get; set; } = false;

    public long CinemaHallId { get; set; }
}
