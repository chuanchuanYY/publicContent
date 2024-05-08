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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Circle.WPF.Controls
{
    /// <summary>
    /// CircleTime.xaml 的交互逻辑
    /// </summary>
    public partial class CircleTime : UserControl
    {
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty
            .Register("Value",
                typeof(double),
                typeof(CircleTime),
                new UIPropertyMetadata(0.0,
                    new PropertyChangedCallback(ValuePropertyChangedCallback))
                );

        private static void ValuePropertyChangedCallback(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var obj = (d as CircleTime);
            if (obj == null)
                return;

            obj.Refresh();
        }


        //刻度颜色 


        public Color ScaleBrush
        {
            get { return (Color)GetValue(ScaleBrushProperty); }
            set { SetValue(ScaleBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ScaleBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScaleBrushProperty =
            DependencyProperty.Register("ScaleBrush",
                typeof(Color),
                typeof(CircleTime),
                new PropertyMetadata(null));



        public object Content
        {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Content.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content",
                typeof(object),
                typeof(CircleTime),
                new PropertyMetadata(null));


        public CircleTime()
        {
            InitializeComponent();
            this.SizeChanged += CircleTime_SizeChanged;
        }

        private void CircleTime_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Refresh();
        }

        void Refresh()
        {
            //清空原来的线
            contain.Children.Clear();


            //计算半径 
            double centerX = root.ActualWidth / 2;
            double centerY = root.ActualHeight / 2;
            double raduis = Math.Min(root.ActualHeight, root.ActualWidth) / 2;
            
            //添加背景
            Border border = new Border();
            border.Width = raduis * 2;
            border.Height = raduis * 2;
            border.Background =
                new SolidColorBrush(Color.FromRgb(45, 53, 61));
            // 创建阴影效果
            DropShadowEffect shadowEffect = new DropShadowEffect();
            shadowEffect.Color = Colors.Black; // 阴影颜色
            shadowEffect.Direction = 270; // 阴影的方向（以度为单位）
            shadowEffect.ShadowDepth = -20; // 阴影的距离
            shadowEffect.Opacity = 0.5; // 阴影的不透明度
            shadowEffect.BlurRadius = 100; // 阴影的模糊半径

            // 将阴影效果应用到Border
            border.Effect = shadowEffect;
            border.CornerRadius = new CornerRadius(raduis, raduis, raduis, raduis);
            contain.Children.Add(border);
            //要画5*12 =60 条线
            //保存最后一个要刻度的引用（），用于添加高亮。
            Line tailLine = null!;
            for (int i = 0; i < 60; i++)
            {
                var line = new Line();
                line.StrokeThickness = 2;
                line.Stroke = Brushes.Gray;//刻度的默认颜色

                line.X1 = centerX + (raduis - 5) * Math.Cos((i * (360 / 60) - 90) / 180.0 * Math.PI);
                line.Y1 = centerY + (raduis - 5) * Math.Sin((i * (360 / 60) - 90) / 180.0 * Math.PI);

                line.X2 = centerX + (raduis - 10) * Math.Cos((i * (360 / 60) - 90) / 180.0 * Math.PI);
                line.Y2 = centerY + (raduis - 10) * Math.Sin((i * (360 / 60) - 90) / 180.0 * Math.PI);
                if (i % 5 == 0)
                {
                    line.X2 = centerX + (raduis - 20) * Math.Cos((i * (360 / 60) - 90) / 180.0 * Math.PI);
                    line.Y2 = centerY + (raduis - 20) * Math.Sin((i * (360 / 60) - 90) / 180.0 * Math.PI);
                }


                if (Value != null && Value >= 0 && Value <= 60)
                {
                    if (Value >= i)
                    {
                        if (ScaleBrush != null)
                            line.Stroke = new SolidColorBrush(ScaleBrush);
                        tailLine = line;
                    }
                }
                contain.Children.Add(line);
            }
            // 创建发光效果
            DropShadowEffect glowLikeEffect = new DropShadowEffect();
            if (ScaleBrush != null)
                glowLikeEffect.Color = ScaleBrush; // 发光颜色
            glowLikeEffect.ShadowDepth = 0; // 阴影深度设置为0
            glowLikeEffect.BlurRadius = 14; // 模糊半径，增加这个值会增强发光效果
            glowLikeEffect.Opacity = 1; // 不透明度设置为1，以便发光效果更明显
            // 将发光效果应用到Line上
            if (tailLine != null)
            {
                tailLine.StrokeThickness = 3.5;
                tailLine.Effect = glowLikeEffect;
            }
            var contentpresenter = new ContentPresenter();
            contentpresenter.Content = Content;
            //contentpresenter.Margin = new Thickness(centerX, centerY, 0, 0);
            //contentpresenter.HorizontalAlignment = HorizontalAlignment.Center;
            //contentpresenter.VerticalAlignment = VerticalAlignment.Center;
            contain.Children.Add(contentpresenter);

        }
    }
}

