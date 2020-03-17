using System.Windows;
using System.Windows.Data;

namespace LauncherToolTip
{
    /// <summary>
    /// Property binding for process launcher element
    /// </summary>
    public static class LauncherBehavior
    {
        #region properties

        public static readonly DependencyProperty PathProperty =
            DependencyProperty.RegisterAttached(
                "Path", typeof(string),
                typeof(LauncherBehavior),
                new FrameworkPropertyMetadata
                {
                    DefaultValue = "",
                    BindsTwoWayByDefault = false,
                    PropertyChangedCallback = PathPropertyChanged,
                    DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                });

        public static string GetPath(FrameworkElement fe)
        {
            return (string)fe.GetValue(PathProperty);
        }

        public static void SetPath(FrameworkElement fe, string path)
        {
            fe.SetValue(PathProperty, path);
        }

        private static void PathPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = d as FrameworkElement;
            var launcher = GetLauncher(obj);
            if (launcher != null)
            {
                launcher.Path = e.NewValue as string;
            }
        }

        public static readonly DependencyProperty ToolTipTextProperty =
            DependencyProperty.RegisterAttached(
                "ToolTipText", typeof(string),
                typeof(LauncherBehavior), 
                new FrameworkPropertyMetadata
                {
                    DefaultValue = "",
                    BindsTwoWayByDefault = false,
                    PropertyChangedCallback = ToolTipTextPropertyChanged,
                    DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                });


        public static string GetToolTipText(FrameworkElement fe)
        {
            return (string)fe.GetValue(ToolTipTextProperty);
        }

        public static void SetToolTipText(FrameworkElement fe, string text)
        {
            fe.SetValue(ToolTipTextProperty, text);
        }

        private static void ToolTipTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = d as FrameworkElement;
            var launcher = GetLauncher(obj);
            if (launcher != null)
            {
                launcher.ToolTipText = e.NewValue as string;
            }
        }

        public static readonly DependencyProperty LauncherProperty =
            DependencyProperty.RegisterAttached(
                "Launcher", typeof(ProcessLauncherView),
                typeof(LauncherBehavior));

        public static ProcessLauncherView GetLauncher(FrameworkElement fe)
        {
            return (ProcessLauncherView)fe.GetValue(LauncherProperty);
        }

        public static void SetLauncher(FrameworkElement fe, ProcessLauncherView launcher)
        {
            fe.SetValue(LauncherProperty, launcher);
        }

        #endregion
    }
}
