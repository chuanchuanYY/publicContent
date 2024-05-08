using Circle.WPF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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
    /// basicCircleProgress.xaml 的交互逻辑
    /// </summary>
    public partial class basicCircleProgress : UserControl
    {
        public basicCircleProgress()
        {
            InitializeComponent();
            this.SizeChanged += BasicCircleProgress_SizeChanged;
        }

        private void BasicCircleProgress_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Refresh();
        }

        public Path PathBgProgress
        {
            get { return (Path)GetValue(PathBgProgressProperty); }
            set { SetValue(PathBgProgressProperty, value); }
        }

        public static readonly DependencyProperty PathBgProgressProperty =
            DependencyProperty.Register("PathBgProgress", 
                typeof(Path), 
                typeof(basicCircleProgress),
                new PropertyMetadata(null));



        public Path PathProgress
        {
            get { return (Path)GetValue(PathProgressProperty); }
            set { SetValue(PathProgressProperty, value); }
        }

        public static readonly DependencyProperty PathProgressProperty =
            DependencyProperty.
            Register("PathProgress", 
                typeof(Path), 
                typeof(basicCircleProgress),
                new PropertyMetadata(null));


        public double Angle
        {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }

        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.Register("Angle",
                typeof(double), 
                typeof(basicCircleProgress), 
                new PropertyMetadata(0.0 ,new PropertyChangedCallback(AnglePropertyChanged)));

        private static void AnglePropertyChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
             var obj = d as basicCircleProgress;
            if (obj != null)
            {
                obj.Refresh();
            }
        }


        public new object Content
        {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Content.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", 
                typeof(object),
                typeof(basicCircleProgress), 
                new PropertyMetadata(null));




        private CircleHelper helper = new CircleHelper();
        ContentPresenter contentPresenter = new ContentPresenter();
        void Refresh()
        {
            
            var (centerX,centerY,radius) = helper.GetInitParameter(root);
            radius -= 5;
            if (radius <= 0)
                return;
            contain.Children.Clear();

            double bgEndX = helper.CalculateX(centerX,radius,(360.0 - 90.0) / 180.0 * Math.PI);
            double bgEndY = helper.CalculateY(centerY,radius,(360.0 - 90.0) / 180.0 * Math.PI);
            string pathBgData = $"M{centerX + 0.1 } {centerY - radius} A{radius} {radius} 0 1 1 {bgEndX} {bgEndY}";
            if (PathBgProgress != null)
            {
                PathBgProgress.Data = PathGeometry.Parse(pathBgData);
                contain.Children.Add(PathBgProgress);
            }

            double EndX = helper.CalculateX(centerX, radius, (Angle - 90.0) / 180.0 * Math.PI);
            double EndY = helper.CalculateY(centerY, radius, (Angle - 90.0)  / 180.0 * Math.PI);
            int isLargerArc = Angle > 180 ? 1 : 0;       
            string pathData = $"M{centerX + 0.1} {centerY - radius} A{radius} {radius} 0 {isLargerArc} 1 {EndX} {EndY}";
            if (PathBgProgress != null)
            {
                PathProgress.Data = PathGeometry.Parse(pathData);
                contain.Children.Add(PathProgress);

            }




            if (Content != null)
            {
                contentPresenter.HorizontalAlignment= HorizontalAlignment.Center;
                contentPresenter.VerticalAlignment = VerticalAlignment.Center;
                contentPresenter.Content = Content;
                contain.Children.Add(contentPresenter);
            }
        }

    }
}
