using Domain.Interfaces;
using Entity.Entity;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RepositoryHoliday : RepositoryGenerecs<Holiday>, IHoliday
    {
        private readonly DbContextOptions<Context> _optionsbuilder;

        public RepositoryHoliday()
        {
            _optionsbuilder = new DbContextOptions<Context>();
        }

        public async Task<bool> SetUser(string email, string password, int Age, string phone)
        {
            try
            {
                using (var data = new Context(_optionsbuilder))
                {
                    await data.Holiday.AddAsync(new Holiday
                    {
                        //Email = email,
                        //PasswordHash = password,
                        //Age = Age,
                        //Phone = phone
                    });

                    await data.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return true;
        }
    }
}
