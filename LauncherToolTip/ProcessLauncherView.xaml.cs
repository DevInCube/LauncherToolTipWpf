using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace LauncherToolTip
{
    /// <summary>
    /// Interaction logic for ProcessLauncherView.xaml
    /// </summary>
    public partial class ProcessLauncherView : UserControl
    {
        #region dependency properties

        public static readonly DependencyProperty PathProperty =
              DependencyProperty.Register(
                  "Path", typeof(string), 
                  typeof(ProcessLauncherView));

        public string Path
        {
            get => (string)GetValue(PathProperty);
            set => SetValue(PathProperty, value);
        }

        public static readonly DependencyProperty ToolTipTextProperty =
              DependencyProperty.Register(
                  "ToolTipText", typeof(string),
                  typeof(ProcessLauncherView), new FrameworkPropertyMetadata()
                  {
                      DefaultValue = "",
                      BindsTwoWayByDefault = true,
                      PropertyChangedCallback = TooltipTextValueChanged,
                      DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                  });

        private static void TooltipTextValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (ProcessLauncherView)d;
            obj.TooltipLabel.Content = e.NewValue;
        }

        public string ToolTipText
        {
            get => (string)GetValue(ToolTipTextProperty);
            set => SetValue(ToolTipTextProperty, value);
        }

        #endregion

        public ProcessLauncherView()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(this.Path);
        }
    }
}
