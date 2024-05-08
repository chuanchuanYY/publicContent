using CommunityToolkit.Mvvm.ComponentModel;
using HowTo.Demos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HowTo.ViewModels
{
    public partial class HomeVIewModel :ObservableObject
    {
        public HomeVIewModel()
        {
            Demos = new ObservableCollection<DemosModel>();
            Demos.Add(new DemosModel { View=new Slideshow() });
            Demos.Add(new DemosModel { View=new LoginForm() });
            Demos.Add(new DemosModel { View=new Accordion() });
            Demos.Add(new DemosModel { View=new HoverDropdowns() });
            Demos.Add(new DemosModel { View=new ClickDropdowns() });
            Demos.Add(new DemosModel { View=new SideNavigation() });
            Demos.Add(new DemosModel { View=new ModalBox() });
        }

        [ObservableProperty]
        private ObservableCollection<DemosModel> demos;

    }
    public class DemosModel {
        public object View { get; set; }
        public string Route { get; set; }
    }
}
