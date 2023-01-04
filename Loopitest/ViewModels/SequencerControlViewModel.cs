using LoopiAvalonia.Models;
using LoopiAvalonia.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LoopiAvalonia.ViewModels
{
    public class SequencerControlViewModel
    {
        private int numberOfSteps;
        private int spm;
        private int currentStepNr = 1;
        private Dictionary<int, Step> steps;
        private int millisPerStep = 1000;
        public bool isSequencerRunning = true;
        private IEnumerable<ISoundFileControl> soundFiles;

        public SequencerControlViewModel(IEnumerable<ISoundFileControl> soundFiles)
        {
            spm = 60;
            numberOfSteps = 4;
            steps = new Dictionary<int, Step>();
            this.soundFiles = soundFiles;
            soundFiles.Select(x => x.OnPlay += OnPlayFile).ToList();
        }

        private void OnPlayFile(object? sender, EventArgs e)
        {
            if (sender is ISoundFileControl soundfile) {
            
                if (isSequencerRunning)
                {
                    Fill(soundfile);
                }
            }
        }

        public void run()
        {
            new Thread(() =>
            {
                while (true)
                {
                    //execute step
                    if (steps.TryGetValue(currentStepNr, out var step))
                    {
                        step.Execute();
                    }
                    //step++
                    currentStepNr++;
                    if (currentStepNr > numberOfSteps) { currentStepNr = 1; }
                    //wait
                    Thread.Sleep(millisPerStep);
                }
            }).Start();
        }

        public void restart()
        {
            currentStepNr = 1;
        }

        public void Fill(ISoundFileControl sound)
        {
            if (!steps.TryGetValue(currentStepNr, out var step))
            {
                step = new Step();
                steps.Add(currentStepNr, step);
            }

            step.AddButton(sound);
        }
    }
}
