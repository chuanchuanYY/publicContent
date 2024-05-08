using Circle.WPF.Controls;
using Circle.WPF.Models;
using Circle.WPF.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.WPF.ViewModels
{
    public partial class MainViewModel :ObservableObject
    {

        public MainViewModel()
        {
            init();
            
        }
        void init()
        {
            navMenus = new ObservableCollection<NavMenuModel>();
            NavMenus.Add(new NavMenuModel() {Title=nameof(CircleProgress1),TargetType=typeof(View1)});
            NavMenus.Add(new NavMenuModel() {Title=nameof(CircleTime),TargetType=typeof(View2)});
            NavMenus.Add(new NavMenuModel() {Title=nameof(basicCircleProgress),TargetType=typeof(View3)});
            NavMenus.Add(new NavMenuModel() {Title=nameof(CircleProgress3),TargetType=typeof(View4)});
        }

        [ObservableProperty]
        private object pageContent;

        [ObservableProperty]
        public ObservableCollection<NavMenuModel> navMenus;

        [RelayCommand]
        public void Nav(Type target)
        {

            PageContent = Activator.CreateInstance(target)!;
        }

    }
}
