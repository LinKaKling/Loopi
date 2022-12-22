using LoopiAvalonia.Models.Interfaces;
using LoopiAvalonia.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;

namespace LoopiAvalonia.Models
{
    internal class Step
    {
        private List<ISoundfile> Buttons { get; }
        public int StepNr { get; }
        public Step()
        {
            Buttons = new List<ISoundfile>();
        }
        public void AddButton(ISoundfile button)
        {
            Buttons.Add(button);
        }

        public void Execute()
        {
            foreach (ISoundfile button in Buttons)
            {
                button.Play();
            }
        }
    }
}
