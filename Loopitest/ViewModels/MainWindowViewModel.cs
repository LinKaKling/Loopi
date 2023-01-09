using LoopiAvalonia.Models.Interfaces;
using LoopiAvalonia.ViewModels;
using System.Collections.Generic;

namespace Loopitest.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        //Temporäre Testpfade. Pfad soll später durch den Nutzer bestimmt werden. Dynamische generierung weiterer Pfade vorgesehen.
        private string path1 = "C:\\Temp\\Test0001";
        private string path2 = "C:\\Temp\\Test0002";
        private string path3 = "C:\\Temp\\Test0003";

        public ButtonControlViewModel ButtonVM1 { get; }
        public ButtonControlViewModel ButtonVM2 { get; }
        public ButtonControlViewModel ButtonVM3 { get; }
        public SequencerControlViewModel Sequencer1 { get; }

        public MainWindowViewModel()
        {
            ButtonVM1 = new ButtonControlViewModel(path1);
            ButtonVM2 = new ButtonControlViewModel(path2);
            ButtonVM3 = new ButtonControlViewModel(path3);
            Sequencer1 = new SequencerControlViewModel(new List<ISoundFileControl>()
            {
                {ButtonVM1},
                {ButtonVM2},
                {ButtonVM3},
            });
            Sequencer1.run();
        }
    }
}