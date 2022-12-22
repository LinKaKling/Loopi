using LoopiAvalonia.Models.Interfaces;
using NAudio.Wave;
using ReactiveUI;
using System;
using System.IO;
using System.Threading;
using System.Windows.Input;

//start Recording wieder an den anfang?
namespace LoopiAvalonia.ViewModels
{
    public class ButtonControlViewModel : ISoundfile
    {
        private static readonly string fileEnding = ".Wav";
        private static readonly string tempSuffix = "_temp";
        private static readonly string backupSuffix = "_backup";
        private IWaveIn? waveSource;
        private WaveFileWriter? waveFile;
        private bool isRecording;
        private string path;

        public string Path => path + fileEnding;
        private string TempFile => path + tempSuffix + fileEnding;
        private string BackupFile => path + backupSuffix + fileEnding;

        public ICommand StartCommand { get; }
        public ICommand StopCommand { get; }
        public ICommand PlayCommand { get; }

        public EventHandler OnPlay { get; set; }

        public ButtonControlViewModel()
            : this("C:\\Temp\\Test0001")
        {
        }

        public ButtonControlViewModel(string pathToFile)
        {
            path = pathToFile;

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

            waveFile = new WaveFileWriter(TempFile, waveSource.WaveFormat);

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

        private void TempToFinal()
        {
            var finalInfo = new FileInfo(Path);
            var tempInfo = new FileInfo(TempFile);

            if (finalInfo.Exists)
            {
                tempInfo.Replace(Path, BackupFile);
                tempInfo.Delete();
            }
            else
                tempInfo.MoveTo(Path);
        }

        private void waveSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (waveFile != null && isRecording)
            {
                waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                waveFile.Flush();
            }
        }

        private void waveSource_RecordingStopped(object sender, StoppedEventArgs e)
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

            TempToFinal();
            StartRecording();
        }

        public void Play()
        {

            new Thread(() =>
            {
                using (var audioFile = new AudioFileReader(Path))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(100);
                    }
                }
            }).Start();
            OnPlay?.Invoke(this, EventArgs.Empty);
            //Sequencer1.Fill(this);
        }
    }
}


