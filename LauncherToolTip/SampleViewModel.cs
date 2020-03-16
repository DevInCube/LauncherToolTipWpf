using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LauncherToolTip
{
    public class SampleViewModel : INotifyPropertyChanged
    {
        public string Text { get; } = "Sample text";

        public string LaunchPath { get; } = "notepad.exe";

        public string LaunchTooltip => LaunchPath + " - " + Text;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
