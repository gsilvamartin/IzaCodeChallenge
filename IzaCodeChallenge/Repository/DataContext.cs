using System;
using IzaCodeChallenge.Model.Database;
using Microsoft.EntityFrameworkCore;

namespace IzaCodeChallenge.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Cliente> Cliente => Set<Cliente>();
        public DbSet<Endereco> Endereco => Set<Endereco>();
    }
}

