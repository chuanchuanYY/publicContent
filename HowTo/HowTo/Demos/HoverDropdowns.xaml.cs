using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HowTo.Demos
{
    /// <summary>
    /// HoverDropdowns.xaml 的交互逻辑
    /// </summary>
    public partial class HoverDropdowns : UserControl
    {
        public HoverDropdowns()
        {
            InitializeComponent();
        }

        bool isPopEntry = false;
        private async void popButton_MouseLeave(object sender, MouseEventArgs e)
        {
            await Task.Delay(200);
            if(!isPopEntry)
            pop.IsOpen=false;
           
        }

        private  void popButton_MouseEnter(object sender, MouseEventArgs e)
        {
            
            pop.IsOpen = true;
        }

        private void pop_MouseEnter(object sender, MouseEventArgs e)
        {
            isPopEntry=true;
            pop.IsOpen = true;
        }

        private void pop_MouseLeave(object sender, MouseEventArgs e)
        {
            pop.IsOpen = false;
            isPopEntry = false;
        }
    }
}
