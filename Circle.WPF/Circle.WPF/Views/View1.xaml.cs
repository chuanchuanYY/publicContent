using CommunityToolkit.Mvvm.ComponentModel;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Circle.WPF.Views
{
    /// <summary>
    /// View1.xaml 的交互逻辑
    /// </summary>
    public partial class View1 : UserControl
    {
        private DispatcherTimer timer;
        public View1()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval =TimeSpan.FromSeconds(0.1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
       
        int value = 0;
        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (value < 100)
            {
                value++;
                c1.Value=value;
                c2.Value=value;
                c3.Value=value;
                c4.Value=value;
            }
            else
            {
                value = 0;
            }
        }
    }
}
