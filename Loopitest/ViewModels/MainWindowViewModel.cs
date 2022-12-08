using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using Microsoft.VisualBasic;
using NAudio.Wave;
using ReactiveUI;
using System;
using System.Windows.Input;
using System.Threading;

namespace Loopitest.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IWaveIn? waveSource;
        private WaveFileWriter? waveFile;
        private bool isRecording;

        public ICommand StartCommand { get; }
        public ICommand StopCommand { get; }

        public ICommand PlayCommand { get; }

        public MainWindowViewModel()
        {
            StartCommand = ReactiveCommand.Create(Start);
            StopCommand = ReactiveCommand.Create(Stop);
            PlayCommand = ReactiveCommand.Create(Play);
            StartRecording();
        }

        private void StartRecording()
        {
            waveSource = new NAudio.Wave.WaveInEvent();
            waveSource.WaveFormat = new WaveFormat(44100, 1);

            waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(waveSource_DataAvailable);
            waveSource.RecordingStopped += new EventHandler<StoppedEventArgs>(waveSource_RecordingStopped);

            waveFile = new WaveFileWriter(@"C:\Temp\Test0001.wav", waveSource.WaveFormat);

            waveSource.StartRecording();
        }

        private void Start()
        {
            isRecording = true;
        }

        private void Stop()
        {
            waveSource?.StopRecording();
            isRecording = false;
        }

        public void waveSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (waveFile != null && isRecording)
            {
                waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                waveFile.Flush();
            }
        }

        public void waveSource_RecordingStopped(object sender, StoppedEventArgs e)
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
        }

        private void Play()
        {
            using (var audioFile = new AudioFileReader("C:\\Temp\\Test0001.wav"))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();
                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(100);
                }
            }
        }
    }
}