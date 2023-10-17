
using System.Collections.Generic;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // saves

        public bool[] LvlComplete;
        public bool[] LvlPerfect;
        public int TotalDeaths;
        public int[] Gems;

        public SavesYG()
        {
            LvlComplete = new bool[24];
            LvlPerfect = new bool[24];
            TotalDeaths = 0;
            Gems = new int[4];
        }
    }
}
