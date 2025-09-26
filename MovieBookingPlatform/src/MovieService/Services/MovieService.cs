using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieService.Dtos;
using MovieService.Entities;
using MovieService.Persistense;

namespace MovieService.Services;

public class MovieService : IMovieService
{
    private readonly AppDbContext _context;
    public MovieService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<long> AddAsync(MovieCreateDto movieCreateDto)
    {
        var entity = new Movie
        {
            Title = movieCreateDto.Title,
            Description = movieCreateDto.Description,
            DurationMinutes = movieCreateDto.DurationMinutes,
            Language = movieCreateDto.Language,
            Genre = movieCreateDto.Genre,
        };
        _context.Add(entity);
        await _context.SaveChangesAsync();
        return entity.MovieId;
    }

    public async Task DeleteAsync(long movieId)
    {
        var entity = await _context.Movies.FindAsync(movieId);
        if (entity is not null)
        {
            _context.Movies.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<MovieDto>> GetAllAsync()
    {
        return await _context.Movies
           .Select(m => new MovieDto
           {
               MovieId = m.MovieId,
               Title = m.Title,
               Description = m.Description,
               DurationMinutes = m.DurationMinutes,
               ReleaseDate = m.ReleaseDate,
               Language = m.Language,
               Genre = m.Genre
           }).ToListAsync();
    }

    public async Task<MovieDto> GetByIdAsync(long movieId)
    {
        var entity = await _context.Movies.FindAsync(movieId);
        if (entity is null) return null;
        return new MovieDto
        {
            MovieId = entity.MovieId,
            Title = entity.Title,
            Description = entity.Description,
            DurationMinutes = entity.DurationMinutes,
            ReleaseDate = entity.ReleaseDate,
            Language = entity.Language,
            Genre = entity.Genre
        };
    }

    public async Task UpdateAsync(MovieUpdateDto movieUpdateDto)
    {
        var entity = await _context.Movies.FindAsync(movieUpdateDto.MovieId);
        if (entity is not null)
        {
            entity.Title = movieUpdateDto.Title;
            entity.DurationMinutes = movieUpdateDto.DurationMinutes;
            entity.Description = movieUpdateDto.Description;
            entity.Genre = movieUpdateDto.Genre;

            _context.Update(entity);
            await _context.SaveChangesAsync();
        } 
    }
}
