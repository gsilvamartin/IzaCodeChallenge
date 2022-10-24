using System;
using IzaCodeChallenge.Model.Database;
using Microsoft.EntityFrameworkCore;

namespace IzaCodeChallenge.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>
    {
        public ClienteRepository(DbContext _dbContext) : base(_dbContext) { }
    }
}

