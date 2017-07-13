using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using XYZZ.Library;

namespace SearchTable
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

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            int index = TypeBox.SelectedIndex;
            string text = InputText.Text;
            bool nullable = !AllowNull.IsChecked ?? false;
            MainContent.ItemsSource = null;
            Loading.Visibility = Visibility.Visible;
            Task.Run(() =>
              {
                  if (index == 0)
                  {
                      //数据表搜索
                      return DataBaseSupport.GetLibraryFromTable(text, nullable);
                  }
                  else if (index == 1)
                  {
                      //SQL搜索
                      return DataBaseSupport.GetLibraryFromSQL(text, nullable);
                  }
                  else
                  {
                      //同步数据表
                      return new List<string>();
                  }
              }).ContinueWith((t) =>
            {
                if (t.Status == TaskStatus.RanToCompletion)
                {
                    Dispatcher.Invoke(() =>
                    {
                        t.Result.Sort();
                        MainContent.ItemsSource = t.Result.Select(x => new { LibraryName = x });
                        Loading.Visibility = Visibility.Hidden;
                    });
                }
                else
                {
                    Dispatcher.Invoke(() =>
                    {
                        Loading.Visibility = Visibility.Hidden;
                        MessageBox.Show((t.Exception.InnerException ?? t.Exception).Message);
                        new LogControl("ErrorLog").WriteLog(t.Exception.InnerException.ToString() ?? t.Exception.ToString());
                    });
                }
            });
        }
    }
}
