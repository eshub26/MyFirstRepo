using LoadTesting.Models;
using LoadTesting.Services;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LoadTesting
{
    public class LoadTest01
    {

        private DBService _dbService;
        private InMemoryDbContext _dbContext;

        const int NODE1_FIVE_MULTIPLES = 10;
        const int NODE2_FIVE_MULTIPLES = 12;
        const int NODE3_FIVE_MULTIPLES = 20;
        const int NODE4_FIVE_MULTIPLES = 15;
        

        [SetUp]
        public void Setup()
        {
            _dbContext = new InMemoryDbContext();
            _dbService = new DBService(_dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Dispose();

        }


        [Test, Category("Category1")]
        //[Category("Category1")]
        public async Task TestLoad_AddingEntities_Node1(
            [Values(1, 2, 3, 4, 5)] int value,
            [Random(50, 5000, NODE1_FIVE_MULTIPLES)] int numberOfRecords)
        {

            // Read a parameter passed to the test
            string parameterValue = Environment.GetEnvironmentVariable("USERNAME");

            Console.WriteLine($"Parameter Output is :  {parameterValue} ");

            var tasks = Enumerable.Range(0, numberOfRecords).Select(async i =>
            {
                var entity = new MyEntity1 { Data = $"Entity {i}" };
                await _dbService.AddEntityAsync(entity);
            });

            Stopwatch stopwatch = Stopwatch.StartNew();
            await Task.WhenAll(tasks);
            stopwatch.Stop();

            Assert.IsTrue( _dbContext.Entities.Count() > 0);

            _dbContext.Entities.RemoveRange(_dbContext.Entities);

            Console.WriteLine($"Time taken for {numberOfRecords} entities: {stopwatch.ElapsedMilliseconds} ms");
        }



        [Test, Category("Category2")]
        //[Category("Category2")]
        public async Task TestLoad_AddingEntities_Node2(
           [Values(1, 2, 3, 4, 5)] int value,
           [Random(100, 8000, NODE2_FIVE_MULTIPLES)] int numberOfRecords)
        {

            var tasks = Enumerable.Range(0, numberOfRecords).Select(async i =>
            {
                var entity = new MyEntity1 { Data = $"Entity {i}" };
                await _dbService.AddEntityAsync(entity);
            });

            Stopwatch stopwatch = Stopwatch.StartNew();
            await Task.WhenAll(tasks);
            stopwatch.Stop();

            Assert.IsTrue(_dbContext.Entities.Count() > 0);

            _dbContext.Entities.RemoveRange(_dbContext.Entities);

            Console.WriteLine($"Time taken for {numberOfRecords} entities: {stopwatch.ElapsedMilliseconds} ms");
        }


        [Test, Category("Category3")]
        //[Category("Category3")]
        public async Task TestLoad_AddingEntities_Node3(
     [Values(1, 2, 3, 4, 5)] int value,
     [Random(100, 6000, NODE3_FIVE_MULTIPLES)] int numberOfRecords)
        {

            var tasks = Enumerable.Range(0, numberOfRecords).Select(async i =>
            {
                var entity = new MyEntity1 { Data = $"Entity {i}" };
                await _dbService.AddEntityAsync(entity);
            });

            Stopwatch stopwatch = Stopwatch.StartNew();
            await Task.WhenAll(tasks);
            stopwatch.Stop();

            Assert.IsTrue(_dbContext.Entities.Count() > 0);

            _dbContext.Entities.RemoveRange(_dbContext.Entities);

            Console.WriteLine($"Time taken for {numberOfRecords} entities: {stopwatch.ElapsedMilliseconds} ms");
        }



        [Test, Category("Category4")]
        //[Category("Category4")]
        public async Task TestLoad_AddingEntities_Node4(
     [Values(1, 2, 3, 4, 5)] int value,
     [Random(100, 7000, NODE4_FIVE_MULTIPLES)] int numberOfRecords)
        {

            var tasks = Enumerable.Range(0, numberOfRecords).Select(async i =>
            {
                var entity = new MyEntity1 { Data = $"Entity {i}" };
                await _dbService.AddEntityAsync(entity);
            });

            Stopwatch stopwatch = Stopwatch.StartNew();
            await Task.WhenAll(tasks);
            stopwatch.Stop();

            Assert.IsTrue(_dbContext.Entities.Count() > 0);

            _dbContext.Entities.RemoveRange(_dbContext.Entities);

            Console.WriteLine($"Time taken for {numberOfRecords} entities: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
