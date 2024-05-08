using CommunityToolkit.Mvvm.ComponentModel;
using HowTo.Common;
using HowTo.Demos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HowTo.ViewModels
{
    public partial class HomeVIewModel :ObservableObject
    {
        public HomeVIewModel()
        {
            Demos = new ObservableCollection<DemosModel>();
             Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetCustomAttribute<DemoAttribute>() != null)
                .ToList()
                .ForEach(t => {
                    Demos.Add(new DemosModel { View = Activator.CreateInstance(t)!});
                });
        }

        [ObservableProperty]
        private ObservableCollection<DemosModel> demos;

    }
    public class DemosModel {
        public object View { get; set; }
        public string Route { get; set; }
    }
}
