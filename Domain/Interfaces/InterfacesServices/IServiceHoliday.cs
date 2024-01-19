using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Holiday;

namespace Domain.Interfaces.InterfacesServices
{
    public interface IServiceHoliday
    {
        Task<bool> Set(List<ViewModelHoliday> model);
        Task<List<ViewModelHoliday>> Get();
        Task Del(int id);
    }
}
