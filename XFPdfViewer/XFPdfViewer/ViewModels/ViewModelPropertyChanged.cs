using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace XFPdfViewer.ViewModels
{
    public class ViewModelPropertyChanged : INotifyPropertyChanged
    {
        public void RaisePropertyChanged([CallerMemberName]string nameProperty = null)
        {
            var handle = PropertyChanged;
            if (handle != null) handle(this, new PropertyChangedEventArgs(nameProperty));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
