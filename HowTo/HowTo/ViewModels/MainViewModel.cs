using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HowTo.Common;
using HowTo.Demos;
using HowTo.Models;
using HowTo.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HowTo.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {

            Page = new Home();
            Menus = new List<NavMenu>();
            initMenus();
        }

        private void initMenus()
        {
            Menus.Add(new NavMenu { Title="HowTo Home",View=typeof(Home)});
            Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetCustomAttribute<DemoAttribute>() != null)
                .ToList()
                .ForEach(t => {
                    Menus.Add(new NavMenu {Title=t.Name,View=t});
                });
        }

        [ObservableProperty]
        private List<NavMenu> menus;

        [ObservableProperty]
        private object page;

        [RelayCommand]
        public void Nav(NavMenu menu)
        {
            Page = Activator.CreateInstance(menu.View)!;
        }
    }
}
