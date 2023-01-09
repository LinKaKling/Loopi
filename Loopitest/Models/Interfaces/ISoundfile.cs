using System;

namespace LoopiAvalonia.Models.Interfaces
{
    public interface ISoundFileControl
    {
        //Pfad des Soundfiles
        string Path { get; }
        //Methode zum Abspielen des Files
        void Play();
        //Tritt auf wenn die Play-Mehtode ausgeführt wird
        EventHandler OnPlay { get; set; }
    }
}
