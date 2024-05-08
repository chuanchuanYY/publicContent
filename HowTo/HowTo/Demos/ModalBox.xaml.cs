using HowTo.Common;
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
    /// ModalBox.xaml 的交互逻辑
    /// </summary>
    /// 
    [Demo]
    public partial class ModalBox : UserControl
    {
        public ModalBox()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pop.IsOpen= true;
            pop.HorizontalOffset = Application.Current.MainWindow.ActualWidth / 4;
            var cicleEase = new CircleEase();
            DoubleAnimation da = new DoubleAnimation();
            da.Duration = new Duration(TimeSpan.FromSeconds(0.7));
            da.From = -30;
            da.To = 80;
            da.EasingFunction = cicleEase;
            Storyboard.SetTarget(da,pop);
            Storyboard.SetTargetProperty(da,new PropertyPath(nameof(pop.VerticalOffset)));

            var st=new Storyboard();
            st.Children.Add(da);
            st.Begin();

        }

        private void Close_Pop(object sender, RoutedEventArgs e)
        {
            pop.IsOpen = false;
        }
    }
}
