using LoopiAvalonia.Models;
using System.Collections.Generic;

namespace LoopiAvalonia.ViewModels
{
    public class SequencerControlViewModel
    {
        private int numberOfSteps;
        private int spm;
        private int currentStepNr = 1;
        private Dictionary<int, Step> steps;

        public SequencerControlViewModel()
        {
            spm = 60;
            numberOfSteps = 16;
            steps = new Dictionary<int, Step>();
        }
        public void run()
        {
            //execute step
            //step++
            //wait
        }
        public void restart()
        {
            currentStepNr = 1;
        }
        public void Fill(ButtonControlViewModel sound)
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


