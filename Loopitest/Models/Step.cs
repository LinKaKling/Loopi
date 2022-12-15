using LoopiAvalonia.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;

namespace LoopiAvalonia.Models
{
    internal class Step
    {
        private List<ButtonControlViewModel> Buttons { get; }
        public int StepNr { get; }
        public Step()
        {
            Buttons = new List<ButtonControlViewModel>();
        }
        public void AddButton(ButtonControlViewModel button)
        {
            Buttons.Add(button);
        }
    }
}
