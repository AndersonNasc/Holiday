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
    }
}
