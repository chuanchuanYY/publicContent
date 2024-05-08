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

namespace HowTo.Demos
{
    /// <summary>
    /// Slideshow.xaml 的交互逻辑
    /// </summary>
    public partial class Slideshow : UserControl
    {
        public Slideshow()
        {
            InitializeComponent();
            onShowChanged += Slideshow_onShowChanged;
            for (int i = 0; i < radiobuttonContain.Children.Count; i++)
            {
                (radiobuttonContain.Children[i] as RadioButton).Click += Slideshow_Click; ;
            }
        }

        private void Slideshow_Click(object sender, RoutedEventArgs e)
        {
            var btn=sender as RadioButton;
            _index=int.Parse(btn.CommandParameter.ToString());
            Show(_index);
        }

        private void Slideshow_onShowChanged()
        {
            indexText.Text= (_index+1).ToString();
            (radiobuttonContain.Children[_index] as RadioButton).IsChecked = true;
        }

        private event Action onShowChanged;
        private int _index = 0;
        private void Left(object sender, RoutedEventArgs e)
        {
            _index--;
            if (_index < 0)
                _index = contain.Children.Count - 1;
            Show(_index);
            TextBlock textBlock = new TextBlock();
           
        }

        private void Right(object sender, RoutedEventArgs e)
        {
            _index++;
            if (_index > contain.Children.Count - 1)
                _index = 0;
            Show(_index);
        }

        private void Show(int index)
        {
            for (int i = 0; i < contain.Children.Count; i++)
            {
                contain.Children[i].Visibility = Visibility.Hidden;
            }
           contain.Children[index].Visibility = Visibility.Visible;
           onShowChanged?.Invoke();
        }
    }
}
