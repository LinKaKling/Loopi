
using Microsoft.VisualBasic;
using NAudio.Wave;
using ReactiveUI;
using System;
using System.Windows.Input;

namespace Loopitest.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IWaveIn waveSource = null;
        private WaveFileWriter waveFile = null;
        public ICommand StartCommand { get; }
        public ICommand StopCommand { get; }

        public MainWindowViewModel()
        {
            StartCommand = ReactiveCommand.Create(Start);
        }

        private void Start()
        {
            waveSource = new WaveIn();
            waveSource.WaveFormat = new WaveFormat(44100, 1);

            waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(waveSource_DataAvailable);
            waveSource.RecordingStopped += new EventHandler<StoppedEventArgs>(waveSource_RecordingStopped);

            waveFile = new WaveFileWriter(@"C:\Temp\Test0001.wav", waveSource.WaveFormat);

            waveSource.StartRecording();
        }

        private void Stop(object sender, EventArgs e)
        {
            waveSource.StopRecording();
        }

        void waveSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (waveFile != null)
            {
                waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                waveFile.Flush();
            }
        }

        void waveSource_RecordingStopped(object sender, StoppedEventArgs e)
        {
            if (waveSource != null)
            {
                waveSource.Dispose();
                waveSource = null;
            }

            if (waveFile != null)
            {
                waveFile.Dispose();
                waveFile = null;
            }

            StartBtn.Enabled = true;
        }
    }
}