﻿using UserService.Configurations.Settings;
using UserService.Persistense;
using Microsoft.EntityFrameworkCore;

namespace UserService.Configurations;

public static class DatabaseConfigurations
{
    public static void ConfigureDB(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
        var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();

        builder.Services.AddDbContext<AppDbContext>(options =>
          options.UseSqlServer(connectionString));

        builder.Services.AddSingleton(jwtSettings);
    }
}
