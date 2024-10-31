using LoadTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace LoadTesting.Services
{
    internal class DBService
    {

        private readonly InMemoryDbContext _dbContext;

        public DBService(InMemoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddEntityAsync(MyEntity1 entity)
        {
            _dbContext.Entities.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        
    }
}
