
using IdentityServer.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) ﻿: base(options) { }
        public DbSet<User> Users { get; set; }
    }
}

