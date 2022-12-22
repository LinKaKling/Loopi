using System;

namespace LoopiAvalonia.Models.Interfaces
{
    public interface ISoundfile
    {
        string Path { get; }
        void Play();
        EventHandler OnPlay { get; set; }
    }
}
