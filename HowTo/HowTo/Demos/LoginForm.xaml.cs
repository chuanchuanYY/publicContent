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
    /// LoginForm.xaml 的交互逻辑
    /// </summary>
    public partial class LoginForm : UserControl
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void OpenDialog(object sender, RoutedEventArgs e)
        {
            var easef = new BackEase();
            easef.Amplitude = 0.4;
            dialogContain.Visibility = Visibility.Visible;
            var widthAnimation = new DoubleAnimation();
            widthAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.3));
            widthAnimation.From = 0;
            widthAnimation.To = dialog.ActualWidth;
            widthAnimation.EasingFunction = easef;
            var heightAnimation = new DoubleAnimation();
            heightAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.3));
            heightAnimation.From = 0;
            heightAnimation.To = dialog.ActualHeight;
            heightAnimation.EasingFunction = easef;

            Storyboard.SetTarget(widthAnimation, dialog);
            Storyboard.SetTargetProperty(widthAnimation,
                new PropertyPath(nameof(dialog.Width)));

            Storyboard.SetTarget(heightAnimation, dialog);
            Storyboard.SetTargetProperty(heightAnimation,
                new PropertyPath(nameof(dialog.Height)));
            var storyboard= new Storyboard();
            storyboard.Children.Add(widthAnimation);
            storyboard.Children.Add(heightAnimation);

            storyboard.Begin();
        }

        private void CloseDialog(object sender, RoutedEventArgs e)
        {
            dialogContain.Visibility=Visibility.Hidden;
            
        }
    }
}
