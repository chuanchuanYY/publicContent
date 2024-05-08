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

namespace Circle.WPF.Controls
{
    /// <summary>
    /// CircleProgress1.xaml 的交互逻辑
    /// </summary>
    public partial class CircleProgress1 : UserControl
    {


        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", 
                typeof(double),
                typeof(CircleProgress1), 
                new PropertyMetadata(0.0,new PropertyChangedCallback(ValuePropertyChanged)));

        private static void ValuePropertyChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var obj = d as CircleProgress1;
            if (obj != null)
            {
                obj.Refresh();
            }
        }




        public Brush ProgressBarBrush
        {
            get { return (Brush)GetValue(ProgressBarBrushProperty); }
            set { SetValue(ProgressBarBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProgressBarBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProgressBarBrushProperty =
            DependencyProperty.Register("ProgressBarBrush",
                typeof(Brush),
                typeof(CircleProgress1), 
                new PropertyMetadata(null));


        public CircleProgress1()
        {
            InitializeComponent();
            this.SizeChanged += CircleProgress1_SizeChanged;
        }
        
        private void CircleProgress1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Refresh();
        }
       
        //刷新绘制
        void Refresh()
        {
            //获取圆形坐标
            double centerX = root.ActualWidth / 2;
            double centerY = root.ActualHeight / 2;

            //获取半径 
            double raduis = Math.Min(root.ActualWidth,root.ActualHeight) /2 - 5 ;
            if (raduis <= 0)
                return;
            double pathBgEndX = centerX + raduis * Math.Cos((360.0 - 90.0) / 180.0 * Math.PI); 
            double pathBgEndY = centerY + raduis * Math.Sin((360.0 - 90.0) / 180.0 * Math.PI);
            
            //路径参数信息查看：https://learn.microsoft.com/zh-cn/dotnet/desktop/wpf/graphics-multimedia/path-markup-syntax?view=netframeworkdesktop-4.8
            string pathBgData = 
                $"M{centerX + 0.1} {centerY - raduis} A{raduis} {raduis} {0} {1} {1} {pathBgEndX} {pathBgEndY} ";
            pathBg.Data = PathGeometry.Parse(pathBgData);


            double angle = (360.0 / 100.0) * (Value % 100.1); 
            double ProgressEndX = centerX + raduis * Math.Cos((angle - 90.0) / 180.0 * Math.PI);
            double ProgressEndY = centerY + raduis * Math.Sin((angle - 90.0) / 180.0 * Math.PI);

            int isLargerArc = angle > 180 ? 1 : 0;
            string ProgressData =
                $"M{centerX + 0.1} {centerY - raduis} A{raduis} {raduis} {0} {isLargerArc} {1} {ProgressEndX} {ProgressEndY} ";
            progressBar.Data = PathGeometry.Parse(ProgressData);
        }
    }
}
