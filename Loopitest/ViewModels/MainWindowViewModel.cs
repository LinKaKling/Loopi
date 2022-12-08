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
        public ButtonControlViewModel ButtonVM1 { get; set; }
        public ButtonControlViewModel ButtonVM2 { get; set; }
        public ButtonControlViewModel ButtonVM3 { get; set; }
        public MainWindowViewModel()
        {
            ButtonVM1 = new ButtonControlViewModel();
            //ButtonVM2 = new ButtonControlViewModel();
            //ButtonVM3 = new ButtonControlViewModel();
        }
    }
}