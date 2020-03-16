using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace LauncherToolTip
{
    public static class LauncherBehavior
    {
        public static readonly DependencyProperty PathProperty =
            DependencyProperty.RegisterAttached(
                "Path", typeof(string),
                typeof(LauncherBehavior),
                new FrameworkPropertyMetadata()
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

        public static void SetPath(FrameworkElement fe, string launcher)
        {
            fe.SetValue(PathProperty, launcher);
        }

        public static readonly DependencyProperty ToolTipTextProperty =
            DependencyProperty.RegisterAttached(
                "ToolTipText", typeof(string),
                typeof(LauncherBehavior), 
                new FrameworkPropertyMetadata()
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

        public static void SetToolTipText(FrameworkElement fe, string launcher)
        {
            fe.SetValue(ToolTipTextProperty, launcher);
        }

        public static readonly DependencyProperty LauncherProperty =
            DependencyProperty.RegisterAttached(
                "Launcher", typeof(ProcessLauncher),
                typeof(LauncherBehavior));

        public static ProcessLauncher GetLauncher(FrameworkElement fe)
        {
            return (ProcessLauncher)fe.GetValue(LauncherProperty);
        }

        public static void SetLauncher(FrameworkElement fe, ProcessLauncher launcher)
        {
            fe.SetValue(LauncherProperty, launcher);
        }

        private static void ToolTipTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DependencyObjectLoaded(d, e);
            var obj = d as FrameworkElement;
            var launcher = GetLauncher(obj);
            if (launcher != null)
            {
                launcher.ToolTipText = e.NewValue as string;
            }
        }

        private static void PathPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DependencyObjectLoaded(d, e);
            var obj = d as FrameworkElement;
            var launcher = GetLauncher(obj);
            if (launcher != null)
            {
                launcher.Path = e.NewValue as string;
            }
        }

        /// <summary>
        /// onload handler
        /// </summary>
        /// <param name="depObj">attached element</param>
        /// <param name="e">event arguments</param>
        private static void DependencyObjectLoaded(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
        {
            if (!(depObj is ContentControl element)) return;
            if (GetLauncher(element) != null) return;

            var launcher = new ProcessLauncher();
            SetLauncher(element, launcher);

            var oldContent = element.Content;
            element.Content = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Children =
                {
                    oldContent is UIElement el ? el : new TextBlock{ Text = (string)oldContent },
                    launcher,
                }
            };
        }
    }
}
