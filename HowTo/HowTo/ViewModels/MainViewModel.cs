using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HowTo.Demos;
using HowTo.Models;
using HowTo.Views;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Menus.Add(new NavMenu { Title="Slideshow",View=typeof(Slideshow)});
            Menus.Add(new NavMenu { Title="LoginForm",View=typeof(LoginForm)});
            Menus.Add(new NavMenu { Title="Accordion",View=typeof(Accordion)});
            Menus.Add(new NavMenu { Title="HoverDropdowns",View=typeof(HoverDropdowns)});
            Menus.Add(new NavMenu { Title=nameof(ClickDropdowns),View=typeof(ClickDropdowns) });
            Menus.Add(new NavMenu { Title=nameof(SideNavigation),View=typeof(SideNavigation) });
            Menus.Add(new NavMenu { Title=nameof(ModalBox),View=typeof(ModalBox) });

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
