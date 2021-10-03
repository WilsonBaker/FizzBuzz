using FizzBuzz.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzz.Configurations
{
    public class ResultsConfiguration : IEntityTypeConfiguration<Result>
    {
        public void Configure(EntityTypeBuilder<Result> builder)
        {
            // Create list of results which we can add to over the course of the algorithm
            var results = new List<Result>();

            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    results.Add(new Result
                    {
                        Id = i,
                        Output = "FizzBuzz"
                    }); ;
                }
                else if (i % 3 == 0)
                {
                    results.Add(new Result
                    {
                        Id = i,
                        Output = "Fizz"
                    });
                }
                else if (i % 5 == 0)
                {
                    results.Add(new Result
                    {
                        Id = i,
                        Output = "Buzz"
                    });
                }
                else
                {
                    results.Add(new Result
                    {
                        Id = i,
                        Output = i.ToString()

                    });
                }
            }

            // Add all FizzBuzz data as a seed data to the database
            builder.HasData(results);
        }
    }
}
