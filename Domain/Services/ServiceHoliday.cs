using Domain.Interfaces;
using Domain.Interfaces.InterfacesServices;
using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public async Task<List<ViewModelHoliday>> Get()
        {
            var result = new List<ViewModelHoliday>();
            var lstHoliday = await _IHoliday.List();
            var lstVariableDate = await _IVariableDate.List();

            foreach (var holiday in lstHoliday)
            {
                var _variableDate = _IVariableDate.Get(holiday.Id);
                ViewModelHoliday clsholiday = new ViewModelHoliday()
                {
                    Id = holiday.Id,
                    Date = holiday.Date,
                    Title = holiday.Title,
                    Description = holiday.Description,
                    Legislation = holiday.Legislation,
                    Type = holiday.Type,
                    StartTime = holiday.StartTime,
                    EndTime = holiday.EndTime,
                    VariableDates = await GetVarableDate(_variableDate.Result)
                };
                result.Add(clsholiday);
            };

            return result;
        }

        private async Task<Dictionary<string, string>> GetVarableDate(List<VariableDate> model)
        {            
            var dictionary = model.ToDictionary(_variableDate => _variableDate.Year.ToString(), _variableDate => _variableDate.Date);

            return dictionary;
        }

        public async Task Del(int id)
        {
            try
            {
                var holidayToDelete = await _IHoliday.searchByID(id);
                var variableDateDelete = await _IVariableDate.Get(holidayToDelete.Id);

                await _IHoliday.del(holidayToDelete);
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }
    }
}
