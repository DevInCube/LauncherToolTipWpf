using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace LauncherToolTip
{
    /// <summary>
    /// Interaction logic for ProcessLauncher.xaml
    /// </summary>
    public partial class ProcessLauncher : UserControl
    {
        public static readonly DependencyProperty PathProperty =
              DependencyProperty.Register(
                  "Path", typeof(string), 
                  typeof(ProcessLauncher));

        public static readonly DependencyProperty ToolTipTextProperty =
              DependencyProperty.Register(
                  "TooltipText", typeof(string),
                  typeof(ProcessLauncher), new FrameworkPropertyMetadata()
                  {
                      DefaultValue = "",
                      BindsTwoWayByDefault = true,
                      PropertyChangedCallback = TooltipTextValueChanged,
                      DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                  });

        private static void TooltipTextValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = d as ProcessLauncher;
            obj.TooltipLabel.Content = e.NewValue;
        }

        public string Path
        {
            get { return (string)GetValue(PathProperty); }
            set { SetValue(PathProperty, value); }
        }

        public string ToolTipText
        {
            get { return (string)GetValue(ToolTipTextProperty); }
            set { SetValue(ToolTipTextProperty, value); }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(this.Path);
        }

        public ProcessLauncher()
        {
            InitializeComponent();
        }
    }
}
