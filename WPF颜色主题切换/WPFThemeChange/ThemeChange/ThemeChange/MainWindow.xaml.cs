using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Definitions.Charts;
using LiveCharts.Wpf;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ThemeChange
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            //var theme_color=new ColorTheme() { 
            // Primary_100=Color.FromRgb(194,29,3),//红色
            //};
            //ThemeManage.ChangeTheme(theme_color);


            navMenus=new List<NavMenu> ();
            initChart();

            NavMenus.Add(new NavMenu { Icon= WebUtility.HtmlDecode("&#xeac4;") ,Title ="Wallet" });
            NavMenus.Add(new NavMenu { Icon= WebUtility.HtmlDecode("&#xe6a6;"), Title ="PortFolio" });
            NavMenus.Add(new NavMenu { Icon= WebUtility.HtmlDecode("&#xe653;"), Title ="Projects" });
            NavMenus.Add(new NavMenu { Icon=WebUtility.HtmlDecode("&#xe64a;"), Title ="Transfers" });
            
            all_themes=Enum.GetNames(typeof(Themes)).ToList();
        }

        private List<string> all_themes;
        public List<string> All_Themes { 
            get { return all_themes; } 
            set { all_themes = value; }
        }
        public List<NavMenu> navMenus;
        public List<NavMenu> NavMenus { 
            get { return navMenus; }
            set { navMenus = value; }
        }
       public class NavMenu { 
            public string? Icon { get; set; }
            public string? Title { get; set; }
        }

        private void ThemeSelect(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
               var new_theme= (Themes)Enum.Parse(typeof(Themes),
                   btn.Content.ToString()!);
                ThemeManage.ChangeTheme(new_theme);
            }
        }
        #region Charts
        void initChart()
        {
            ThemeManage.ThemeChanged += () =>
            {
               var l= LastHourSeries[0] as LineSeries;
                l.Stroke = new SolidColorBrush(
                    (Color)Application.Current.Resources["Primary_100"]);
                var fill = new SolidColorBrush(
                  (Color)Application.Current.Resources["Primary_100"]);
                fill.Opacity = 0.1;
                l.Fill = fill;
            };
            var fill = new SolidColorBrush(
                    (Color)Application.Current.Resources["Primary_100"]);
            fill.Opacity = 0.1;
            var lineSeries = new LineSeries
            {
                Stroke = new SolidColorBrush(
                    (Color)Application.Current.Resources["Primary_100"]),
                Fill= fill,
                AreaLimit = -10,
                Values = new ChartValues<ObservableValue>
                    {
                        new ObservableValue(3),
                        new ObservableValue(5),
                        new ObservableValue(6),
                        new ObservableValue(7),
                        new ObservableValue(3),
                        new ObservableValue(4),
                        new ObservableValue(2),
                        new ObservableValue(5),
                        new ObservableValue(8),
                        new ObservableValue(3),
                        new ObservableValue(5),
                        new ObservableValue(6),
                        new ObservableValue(7),
                        new ObservableValue(3),
                        new ObservableValue(4),
                        new ObservableValue(2),
                        new ObservableValue(5),
                        new ObservableValue(8)
                    }
            };
            LastHourSeries = new SeriesCollection
            {
                lineSeries
            };
        }
        public SeriesCollection LastHourSeries { get; set; }
        #endregion
    }
}