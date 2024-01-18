using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Holiday
{
    //public class ViewModelHoliday
    //{
    //    public int Id { get; set; }

    //    public string Date { get; set; }

        
    //    public string Title { get; set; }

    //    public string Description { get; set; }

    //    public string Legislation { get; set; }

        
    //    public string Type { get; set; }

    //    public string StartTime { get; set; }

    //    public string EndTime { get; set; }

    //    public List<ViewModelVariableDate> VariableDates { get; set; }
    //}
    public class ViewModelVariableDate
    {
        public string Year { get; set; }
        public string Date { get; set; }
    }

    public class ViewModelHoliday
    {
        public string Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Legislation { get; set; }
        public string Type { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public Dictionary<string, string> VariableDates { get; set; }
    }
}


