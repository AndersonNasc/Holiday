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
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RepositoryVariableDate : RepositoryGenerecs<VariableDate>, IVariableDate
    {
        private readonly DbContextOptions<Context> _optionsbuilder;

        public RepositoryVariableDate()
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

        public async Task<List<VariableDate>> Get(int hoidayId)
        {
            try
            {
                using (var data = new Context(_optionsbuilder))
                {
                    var result = await data.VariableDate.Where(x => x.FeriadoId == hoidayId).ToListAsync();

                    return result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
