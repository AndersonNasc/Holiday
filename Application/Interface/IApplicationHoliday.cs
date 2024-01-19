
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Holiday;

namespace Application.Interface
{
    public interface IApplicationHoliday
    {
        Task<bool> Set(List<ViewModelHoliday> model);
        Task<List<ViewModelHoliday>> Get();
        Task Del(int id);
    }
}
