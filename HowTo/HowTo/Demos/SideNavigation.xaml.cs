using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HowTo.Demos
{
    /// <summary>
    /// SideNavigation.xaml 的交互逻辑
    /// </summary>
    public partial class SideNavigation : UserControl
    {
        public SideNavigation()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ease= new CircleEase();
            contain.Visibility = Visibility.Visible;
            DoubleAnimation da= new DoubleAnimation();
            da.Duration = new Duration(TimeSpan.FromSeconds(0.7));
            da.From = 0;
            da.To = 150;
            da.EasingFunction = ease;

            Storyboard.SetTarget(da,sideBar);
            Storyboard.SetTargetProperty(da,new PropertyPath(nameof(sideBar.Width)));

            var St=new Storyboard();
            St.Children.Add(da);
            St.Begin();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var ease = new CircleEase();
            contain.Visibility = Visibility.Visible;
            wOacity.IsHitTestVisible = true;

            DoubleAnimation da = new DoubleAnimation();
            da.Duration = new Duration(TimeSpan.FromSeconds(0.7));
            da.From = 0;
            da.To = 150;
            da.EasingFunction= ease;
            Storyboard.SetTarget(da, sideBar);
            Storyboard.SetTargetProperty(da, new PropertyPath(nameof(sideBar.Width)));
            DoubleAnimation daOpacity = new DoubleAnimation();

            daOpacity.Duration = new Duration(TimeSpan.FromSeconds(0.7));
            daOpacity.From = 0;
            daOpacity.To = 0.6;
            daOpacity.EasingFunction= ease;
            Storyboard.SetTarget(daOpacity, wOacity);
            Storyboard.SetTargetProperty(daOpacity, new PropertyPath(nameof(wOacity.Opacity)));

            var St = new Storyboard();
            St.Children.Add(da);
            St.Children.Add(daOpacity);
            St.Begin();
        }

        private void wOacity_Click(object sender, RoutedEventArgs e)
        {
            


            var ease = new CircleEase();
            contain.Visibility = Visibility.Visible;
            wOacity.IsHitTestVisible = true;

            DoubleAnimation da = new DoubleAnimation();
            da.Duration = new Duration(TimeSpan.FromSeconds(0.7));
            da.From = 150;
            da.To = 0;
            da.EasingFunction = ease;
            Storyboard.SetTarget(da, sideBar);
            Storyboard.SetTargetProperty(da, new PropertyPath(nameof(sideBar.Width)));
            DoubleAnimation daOpacity = new DoubleAnimation();

            daOpacity.Duration = new Duration(TimeSpan.FromSeconds(0.7));
            daOpacity.From = 0.6;
            daOpacity.To = 0;
            daOpacity.EasingFunction = ease;
            Storyboard.SetTarget(daOpacity, wOacity);
            Storyboard.SetTargetProperty(daOpacity, new PropertyPath(nameof(wOacity.Opacity)));

            var St = new Storyboard();
            St.Children.Add(da);
            St.Children.Add(daOpacity);
            St.Begin();

           // contain.Visibility = Visibility.Collapsed;
           wOacity.IsHitTestVisible = false;
           // wOacity.Opacity = 0;
        }
    }
}
