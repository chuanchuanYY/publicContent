using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Circle.WPF.Common
{
    public class CircleHelper
    {
        public (double centerX, double CenterY, double radius) 
            GetInitParameter(FrameworkElement root)
        {
            double centerX = root.ActualWidth / 2;
            double centerY = root.ActualHeight / 2;
            double radius = GetRadius(root);
            return (centerX, centerY, radius);
        }
        public double GetRadius(FrameworkElement element)
        {
            return Math.Min(element.ActualWidth,element.ActualHeight) / 2 ;
        }

        public double CalculateX(double centerX,double radius,double radian)
        {
            return centerX + radius * Math.Cos(radian);
        }
        public double CalculateY(double centerY, double radius, double radian)
        {
            return centerY + radius * Math.Sin(radian);
        }
      
    }
}
