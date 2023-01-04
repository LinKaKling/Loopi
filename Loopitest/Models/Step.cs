using LoopiAvalonia.Models.Interfaces;
using LoopiAvalonia.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;

namespace LoopiAvalonia.Models
{
    internal class Step
    {
        private List<ISoundFileControl> Buttons { get; }
        public int StepNr { get; }
        public Step()
        {
            Buttons = new List<ISoundFileControl>();
        }
        public void AddButton(ISoundFileControl button)
        {
            Buttons.Add(button);
        }

        public void Execute()
        {
            foreach (ISoundFileControl button in Buttons)
            {
                button.Play();
            }
        }
    }
}
