using Application.Interface;
using Domain.Interfaces;
using Domain.Interfaces.InterfacesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Holiday;

namespace Application.Application
{
    public class ApplicationHoliday : IApplicationHoliday
    {
        IServiceHoliday _IHoliday;
        public ApplicationHoliday(IServiceHoliday IHoliday)
        {
            _IHoliday = IHoliday;
        }
       

        public async Task<bool> Set(List<ViewModelHoliday> model)
        {
            return await _IHoliday.Set(model);
        }

        public async Task<List<ViewModelHoliday>> Get()
        {
            return await _IHoliday.Get();
        }

        public async Task Del(int id)
        {
            await _IHoliday.Del(id);
        }
    }
}
