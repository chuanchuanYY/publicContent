using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
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
    /// View2.xaml 的交互逻辑
    /// </summary>
    public partial class View2 : UserControl,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
        private int second;
        public int Second
        {
            get { return this.second; }
            set { second = value;OnPropertyChanged(); }
        }
        public View2()
        {
            InitializeComponent();
            DataContext = this;
            Second = 50;
           
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000); // 设置时间间隔为1秒
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (Second < 59)
            {
                Second++;
            }
            else
            {
                Second = 0;
            }
        }
    }
}
