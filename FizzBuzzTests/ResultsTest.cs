using System;
using Xunit;
using FizzBuzz.Data;
using FizzBuzz.Models;
using FizzBuzz.Controllers;
using Microsoft.EntityFrameworkCore;

namespace FizzBuzzTests
{
    public class ResultsTest
    {

        #region Seeding
        protected ResultsTest(DbContextOptions<ApplicationDBContext> contextOptions)
        {
            ContextOptions = contextOptions;

            Seed();
        }

        protected DbContextOptions<ApplicationDBContext> ContextOptions { get; }

        private void Seed()
        {
            using (var context = new ApplicationDBContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.Migrate();
            }
        }
        #endregion
        [Fact]
        public void Test1()
        {

        }
    }
}
