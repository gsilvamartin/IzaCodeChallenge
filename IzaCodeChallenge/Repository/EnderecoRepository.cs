using System;
using IzaCodeChallenge.Model.Database;
using Microsoft.EntityFrameworkCore;

namespace IzaCodeChallenge.Repository
{
    public class EnderecoRepository : BaseRepository<Endereco>
    {
        public EnderecoRepository(DbContext _dbContext) : base(_dbContext) { }
    }
}

