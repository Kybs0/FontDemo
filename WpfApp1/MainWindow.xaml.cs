using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Globalization;
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
using FontFamily = System.Drawing.FontFamily;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                //StringBuilder str = new StringBuilder(2000);
                //InstalledFontCollection fonts = new InstalledFontCollection();
                //str.Append($"总共{fonts.Families.Length}个");
                //str.AppendLine();
                //foreach (FontFamily family in fonts.Families)
                //{
                //    str.Append(family.Name);
                //    str.AppendLine();
                //}
                //ContentTextBlock.Text = str.ToString();

                StringBuilder str = new StringBuilder(2000);
                CultureInfo currentCulture = CultureInfo.CurrentUICulture;
                CultureInfo enUsCultureInfo = new CultureInfo("en-US");
                int currentIndex = 0;
                int engIndex = 0;
                foreach (var family in Fonts.SystemFontFamilies)
                {
                    foreach (var keyPair in family.FamilyNames)
                    {
                        var specificCulture = keyPair.Key.GetSpecificCulture();
                        if (specificCulture.Equals(currentCulture))
                        {
                            if (keyPair.Key != null && !string.IsNullOrEmpty(keyPair.Value))
                            {
                                str.Append(keyPair.Value);
                                str.AppendLine();
                                currentIndex++;
                                continue;
                            }
                        }
                        if (specificCulture.Equals(currentCulture) || specificCulture.Equals(enUsCultureInfo))
                        {
                            if (keyPair.Key != null && !string.IsNullOrEmpty(keyPair.Value))
                            {
                                str.Append(keyPair.Value);
                                str.AppendLine();
                                engIndex++;
                            }
                        }
                    }
                }

                var count = $"当前语言{currentCulture.Name}：{currentIndex}个，{enUsCultureInfo.Name}：{engIndex}个\r\n";
                ContentTextBlock.Text = count+str.ToString();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }
    }
}
