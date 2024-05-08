using Microsoft.Windows.Themes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace ThemeChange
{
    public enum Themes
    {
        ElectricCityNights,
        Lavendar,
        HackerNews,
        LightBlue,
        DarkSapphineBlue,
        Turquoise,
        Navyandblush
    }
    public class ColorTheme {
        public Color Primary_100 { get; set; }
        public Color Primary_200 { get; set; }
        public Color Primary_300 { get; set; }
        public Color Accent_100 { get; set; }
        public Color Accent_200 { get; set; }
        public Color Text_100 { get; set; }
        public Color Text_200 { get; set; }
        public Color Backgroud_100 { get; set; }
        public Color Backgroud_200 { get; set; }
        public Color Backgroud_300 { get; set; }
    }
    public static class ThemeManage
    {
        static ThemeManage()
        {
            mergedDictionaries = Application.Current.
                Resources.MergedDictionaries;
            ChangeTheme(Themes.ElectricCityNights);
        }
        public static Themes CurrentTheme { get; set; }
        public static event Action? ThemeChanged;
        private static Collection<ResourceDictionary> mergedDictionaries;
        public static void ChangeTheme(Themes NewTheme)
        {
            int index;
            if ((index=ExistsThemeResourceDictionarie())<0)
                return;
            mergedDictionaries[index].Source =
                new Uri(@$"\Themes\{NewTheme}.xaml",
                UriKind.Relative);
            CurrentTheme = NewTheme;
            ThemeChanged?.Invoke();
            return;
        }
        public static void ChangeTheme(ColorTheme theme)
        {
            if (ExistsThemeResourceDictionarie()<0)
                return;
            Application.Current.Resources[nameof(theme.Primary_100)]= theme.Primary_100;
            Application.Current.Resources["Primary_200"]= theme.Primary_200;
            Application.Current.Resources["Primary_300"]= theme.Primary_300;
            Application.Current.Resources[nameof(theme.Accent_100)]= theme.Accent_100;
            Application.Current.Resources[nameof(theme.Accent_200)]= theme.Accent_200;
            Application.Current.Resources[nameof(theme.Text_100)]= theme.Text_100;
            Application.Current.Resources[nameof(theme.Text_200)]= theme.Text_200;
            Application.Current.Resources[nameof(theme.Backgroud_100)]= theme.Backgroud_100;
            Application.Current.Resources[nameof(theme.Backgroud_200)]= theme.Backgroud_200;
            Application.Current.Resources[nameof(theme.Backgroud_300)]= theme.Backgroud_300;
        }
        static int ExistsThemeResourceDictionarie()
        {
            for (int i = 0; i < mergedDictionaries.Count; i++)
            {
                var last_str = mergedDictionaries[i].Source.ToString()
                               .Split(@"\").Last();
                if (IsTheme(last_str))
                {
                   return i;
                }
            }
            return -1;
        }
        private static bool IsTheme(string Theme)
        {
            string[] theme_names = Enum.GetNames(typeof(Themes));
            foreach (string theme_name in theme_names)
            {
                if (Theme.Equals($"{theme_name}.xaml"))
                {
                    return true;
                };
            }
            return false;
        }
    }
}
