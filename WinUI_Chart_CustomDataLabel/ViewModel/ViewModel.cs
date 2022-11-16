using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDataLabel
{
    public class ViewModel
    {
        public ObservableCollection<Model> Data { get; set; }
        public ViewModel() 
        {
            Data = new ObservableCollection<Model>()
            {
                new Model(){ XValue = "Jan", YValue = 10},
                new Model(){ XValue = "Feb", YValue = 20},
                new Model(){ XValue = "Mar", YValue = 15},
                new Model(){ XValue = "Apr", YValue = 21},
                new Model(){ XValue = "May", YValue = 18},
                new Model(){ XValue = "Jun", YValue = 28},
                new Model(){ XValue = "Jul", YValue = 25},
                new Model(){ XValue = "Aug", YValue = 29},
                new Model(){ XValue = "Sep", YValue = 35},
                new Model(){ XValue = "Oct", YValue = 28},
            };
        }
    }
}
