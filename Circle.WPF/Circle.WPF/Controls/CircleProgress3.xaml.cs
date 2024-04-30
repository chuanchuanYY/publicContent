using Circle.WPF.Common;
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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Circle.WPF.Controls
{
    /// <summary>
    /// CircleProgress3.xaml 的交互逻辑
    /// </summary>
    public partial class CircleProgress3 : UserControl
    {
        public CircleProgress3()
        {
            InitializeComponent();
            this.SizeChanged += CircleProgress3_SizeChanged;
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0.0;
            doubleAnimation.To = 360.0;
            doubleAnimation.Duration = TimeSpan.FromSeconds(2);
            doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            doubleAnimation.EasingFunction = new SineEase();
           
            Storyboard.SetTarget(doubleAnimation,this);
            Storyboard.SetTargetProperty(doubleAnimation,new PropertyPath("Angle"));

            DoubleAnimation startAngleDA = new DoubleAnimation();
            startAngleDA.From = 0.0;
            startAngleDA.To = 360.0;
            startAngleDA.Duration = TimeSpan.FromSeconds(2);
            startAngleDA.RepeatBehavior = RepeatBehavior.Forever;
            startAngleDA.EasingFunction = new SineEase();
            Storyboard.SetTarget(startAngleDA, this);
            Storyboard.SetTargetProperty(startAngleDA, new PropertyPath("StartAngle"));

            Storyboard storyboard = new Storyboard();
            Storyboard storyboard1 = new Storyboard();
            storyboard1.BeginTime = TimeSpan.FromSeconds(0.3);
            storyboard.Children.Add(doubleAnimation);
            storyboard1.Children.Add(startAngleDA);
            storyboard.Begin();
            storyboard1.Begin();


        }
         
        private void CircleProgress3_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Refresh();
        }


      



        public Color PointColor
        {
            get { return (Color)GetValue(PointColorProperty); }
            set { SetValue(PointColorProperty, value); }
        }

        public static readonly DependencyProperty PointColorProperty =
            DependencyProperty.Register("PointColor", 
                typeof(Color),
                typeof(CircleProgress3), 
                new PropertyMetadata(null));


        public double Angle
        {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }

        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.Register("Angle",
                typeof(double), 
                typeof(CircleProgress3), 
                new PropertyMetadata(0.0,new PropertyChangedCallback(AngleChanged)));
        private  static void AngleChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var obj = d as CircleProgress3;
            if (obj != null)
            {
                obj.Refresh();
            }
        }



        public double StartAngle
        {
            get { return (double)GetValue(StartAngleProperty); }
            set { SetValue(StartAngleProperty, value); }
        }

        public static readonly DependencyProperty StartAngleProperty =
            DependencyProperty.Register("StartAngle",
                typeof(double), 
                typeof(CircleProgress3), 
                new PropertyMetadata(0.0,new PropertyChangedCallback(StartAngleChanged)));

        private static void StartAngleChanged(DependencyObject d,
          DependencyPropertyChangedEventArgs e)
        {
            var obj = d as CircleProgress3;
            if (obj != null)
            {
                obj.Refresh();
            }
        }






        private CircleHelper helper = new CircleHelper();

        public bool EnableTailLine { get; set; }= true;
        
        void Refresh()
        {
            var (centerX,centerY,radius) = helper.GetInitParameter(root);
            radius -= 5;
            if (radius <= 0)
                return;
           
            contain.Children.Clear();
            //画背景
            var bgEndX = helper.CalculateX(centerX,radius,(360.0 - 90.0) / 180.0 * Math.PI);
            var bgEndY = helper.CalculateY(centerY,radius,(360.0 - 90.0) / 180.0 * Math.PI);
            string bgData = $"M{centerX + 0.1} {centerY - radius} A{radius} {radius} 0 1 1 {bgEndX} {bgEndY}";

            var bgpath = new Path();
            bgpath.Stroke = new SolidColorBrush(Color.FromRgb(34, 34, 34));
            bgpath.StrokeThickness = 4;
            bgpath.Data = PathGeometry.Parse(bgData);
            contain.Children.Add(bgpath);


            var lightPoint = new Line();
            lightPoint.Stroke= new SolidColorBrush(PointColor);
            lightPoint.StrokeThickness = 6;
            
            DropShadowEffect effect = new DropShadowEffect();
            effect.Color = PointColor;
            effect.BlurRadius = 20;
            effect.Opacity = 1;
            effect.ShadowDepth = 0;
            lightPoint.Effect = effect;


            double pointX = helper.CalculateX(centerX,radius+3.0,(Angle - 90.0 ) / 180.0 * Math.PI);
            double pointY = helper.CalculateY(centerY,radius+3.0,(Angle - 90.0 ) / 180.0 * Math.PI);
            double pointX2 = helper.CalculateX(centerX, radius-3.0, (Angle - 90.0) / 180.0 * Math.PI);
            double pointY2 = helper.CalculateY(centerY, radius-3.0, (Angle - 90.0) / 180.0 * Math.PI);
            lightPoint.X1 = pointX;
            lightPoint.Y1 = pointY;
            lightPoint.X2 = pointX2;
            lightPoint.Y2 = pointY2;



            if (EnableTailLine)
            {
                double tailX = helper.CalculateX(centerX, radius , (Angle - 90.0) / 180.0 * Math.PI);
                double tailY = helper.CalculateY(centerY, radius , (Angle - 90.0) / 180.0 * Math.PI);
                int isLargeArc=Angle > 180.0 ? 1 : 0;
                
                string tailData = $"M{centerX+0.1 } {centerY -radius} A{radius} {radius} 0 {isLargeArc} 1 {tailX} {tailY}";
               
                var tailpath = new Path();
                tailpath.Stroke = new SolidColorBrush(PointColor);
                tailpath.StrokeThickness = 4;
                tailpath.Data = PathGeometry.Parse(tailData);
                contain.Children.Add(tailpath);

                double overPathX = helper.CalculateX(centerX, radius, (StartAngle - 90.0) / 180.0 * Math.PI);
                double overPathY = helper.CalculateY(centerY, radius, (StartAngle - 90.0) / 180.0 * Math.PI);
                string overData = $"M{centerX + 0.1} {centerY - radius} A{radius} {radius} 0 {(StartAngle > 180.0 ? 1 : 0)} 1 {overPathX} {overPathY}";
                var overPath = new Path();
                overPath.Stroke = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                overPath.StrokeThickness = 5;
                overPath.Data = PathGeometry.Parse(overData);
                contain.Children.Add(overPath);
            }
            contain.Children.Add(lightPoint);
        }
    }
}
