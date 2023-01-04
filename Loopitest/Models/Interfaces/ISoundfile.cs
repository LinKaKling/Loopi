using System;

namespace LoopiAvalonia.Models.Interfaces
{
    public interface ISoundFileControl
    {
        string Path { get; }
        void Play();
        EventHandler OnPlay { get; set; }
    }
}
