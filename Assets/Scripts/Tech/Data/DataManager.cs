using UnityEngine;
using YG;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public Data data { get; private set; }

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    public (bool, bool) GetLvl(int lvl)
    {
        return (YandexGame.savesData.LvlComplete[lvl], YandexGame.savesData.LvlPerfect[lvl]);
    }
    public void SetLvl(int lvl, (bool, bool) values)
    {
        YandexGame.savesData.LvlComplete[lvl] = values.Item1;
        YandexGame.savesData.LvlPerfect[lvl] = values.Item2;
    }
    public void AddGem(int lvl)
    {
        bool newVal = true;
        int index = 0;

        for (int i = 0; i < YandexGame.savesData.Gems.Length; i++)
        {
            if (YandexGame.savesData.Gems[i] == lvl) newVal = false;
            if (YandexGame.savesData.Gems[i] == 0)
            {
                index = i;
                break;
            }
        }

        if (newVal) YandexGame.savesData.Gems[index] = lvl;
    }

    public void ResetProgress()
    {
        YandexGame.ResetSaveProgress();
        YandexGame.SaveProgress();
    }

    public class Data
    {
        public int TotalDeaths 
        { 
            get 
            {
                return YandexGame.savesData.TotalDeaths;
            }
            set
            {
                YandexGame.savesData.TotalDeaths++;
            }
        }
        public int Gems
        {
            get 
            {
                int index = 0;

                for (int i = 0; i < YandexGame.savesData.Gems.Length; i++)
                {
                    if (YandexGame.savesData.Gems[i] == 0)
                    {
                        index = i;
                        break;
                    }
                }

                return index;
            }
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            YandexGame.SaveProgress();
        }
    }
}
