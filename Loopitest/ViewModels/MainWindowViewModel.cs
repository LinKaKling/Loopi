//using System;
//using System.Diagnostics;
//using System.IO;
//using System.Linq;
//using NAudio.CoreAudioApi;
//using NAudio.Wave;
//using Microsoft.VisualBasic;
//using NAudio.Wave;
//using ReactiveUI;
//using System;
//using System.Windows.Input;
//using System.Threading;

using LoopiAvalonia.ViewModels;

namespace Loopitest.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string path1 = "C:\\Temp\\Test0001.wav";
        private string path2 = "C:\\Temp\\Test0002.wav";
        private string path3 = "C:\\Temp\\Test0003.wav";
        public ButtonControlViewModel ButtonVM1 { get; set; }
        public ButtonControlViewModel ButtonVM2 { get; set; }
        public ButtonControlViewModel ButtonVM3 { get; set; }
        public MainWindowViewModel()
        {
            
            ButtonVM1 = new ButtonControlViewModel(path1);
            ButtonVM2 = new ButtonControlViewModel(path2);
            ButtonVM3 = new ButtonControlViewModel(path3);
        }
    }
}

//for (int i = 1; i <= 3; i++)
//{

//}