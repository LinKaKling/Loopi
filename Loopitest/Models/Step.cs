using LoopiAvalonia.Models.Interfaces;
using System.Collections.Generic;

namespace LoopiAvalonia.Models
{
    //WIP! Aktuell ohne Funktion
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
            //foreach (ISoundFileControl button in Buttons)
            //{
            //    button.Play();
            //}
        }
    }
}
