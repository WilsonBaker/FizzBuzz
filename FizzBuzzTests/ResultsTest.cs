using System;
using Xunit;
using FizzBuzz.Data;
using FizzBuzz.Models;
using FizzBuzz.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FizzBuzzTests
{
    public class ResultsTest
    {
        // to have the same Configuration object as in Startup
        private IConfigurationRoot _configuration;

        // represents database's configuration
        private DbContextOptions<ApplicationDBContext> _options;

        public ResultsTest()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
            _options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
                .Options;
        }

        [Fact]
        public void initDatabase()
        {
            using (var context = new ApplicationDBContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.Migrate();
            }
        }


        #region Check_database_is_not_empty
        [Fact]
        public void Check_database_is_not_empty()
        {
            using (var context = new ApplicationDBContext(_options))
            {
                IEnumerable<Result> objList = context.Results;
                var results = objList.ToList();

                Assert.NotEmpty(results);
            }
        }
        #endregion

        #region Check_3_is_Fizz
        [Fact]
        public void Check_3_is_Fizz()
        {
            using (var context = new ApplicationDBContext(_options))
            {
                IEnumerable<Result> objList = context.Results;
                var results = objList.ToList();

                Assert.Equal("Fizz", results[2].Output);
            }
        }
        #endregion

        #region Check_5_is_Buzz
        [Fact]
        public void Check_5_is_Buzz()
        {
            using (var context = new ApplicationDBContext(_options))
            {
                IEnumerable<Result> objList = context.Results;
                var results = objList.ToList();

                Assert.Equal("Buzz", results[4].Output);
            }
        }
        #endregion

        #region Check_15_is_FizzBuzz
        [Fact]
        public void Check_15_is_FizzBuzz()
        {
            using (var context = new ApplicationDBContext(_options))
            {
                IEnumerable<Result> objList = context.Results;
                var results = objList.ToList();

                Assert.Equal("Buzz", results[4].Output);
            }
        }
        #endregion
    }
}
