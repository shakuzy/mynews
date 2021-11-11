﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mynewsreally.Areas.Identity.Data;
using mynewsreally.Models;

namespace mynewsreally.Data
{
    public class mynewsreallyContext : IdentityDbContext<mynewsreallyUser>
    {
        public mynewsreallyContext(DbContextOptions<mynewsreallyContext> options)
            : base(options)
        {
        }
        public DbSet<Post> Noticias { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
