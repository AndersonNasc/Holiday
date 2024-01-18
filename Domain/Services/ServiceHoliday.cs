using Domain.Interfaces;
using Domain.Interfaces.InterfacesServices;
using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Holiday;

namespace Domain.Services
{
    public class ServiceHoliday : IServiceHoliday
    {
        private readonly IHoliday _IHoliday;
        private readonly IVariableDate _IVariableDate;

        public ServiceHoliday(IHoliday IHoliday, IVariableDate iVariableDate)
        {
            _IHoliday = IHoliday;
            _IVariableDate = iVariableDate;
        }

        public async Task<bool> Set(List<ViewModelHoliday> model)
        {
            try
            {
                foreach (var holiday in model)
                {
                    Holiday clsholiday = new Holiday()
                    {
                        Date = holiday.Date,
                        Title = holiday.Title,
                        Description = holiday.Description,
                        Legislation = holiday.Legislation,
                        Type = holiday.Type,
                        StartTime = holiday.StartTime,
                        EndTime = holiday.EndTime,
                    };
                                        
                    await _IHoliday.set(clsholiday);
                                        
                    if (clsholiday.Id > 0)
                    {
                        foreach (var variableDate in holiday.VariableDates)
                        {
                            VariableDate clsVariableDate = new VariableDate()
                            {
                                FeriadoId = clsholiday.Id,
                                Year = Convert.ToInt32(variableDate.Key),
                                Date = variableDate.Value
                            };

                            
                            await _IVariableDate.set(clsVariableDate);
                        }
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

            return true;            
        }
    }
}
