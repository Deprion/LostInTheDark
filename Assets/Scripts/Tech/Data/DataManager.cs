using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    private string path;

    public Data data { get; private set; }

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);

        path = Application.persistentDataPath + "/Data.dat";
        LoadData();
    }

    public (bool, bool) GetLvl(int lvl)
    {
        if (data.Levels.ContainsKey($"Level_{lvl}"))
            return data.Levels[$"Level_{lvl}"];
        return (false, false);
    }
    public void SetLvl(int lvl, (bool, bool) values)
    {
        data.Levels[$"Level_{lvl}"] = values;
    }
    public void AddGem(int lvl)
    {
        string str = $"Level_{lvl}";
        if (!data.Gems.Contains(str)) data.Gems.Add(str);
    }

    public void ResetProgress()
    {
        data.Levels.Clear();
        data.TotalDeaths = 0;
        data.Gems.Clear();
    }

    private void LoadData()
    {
        if (!File.Exists(path))
        {
            data = new Data();
            return;
        }

        data = JsonConvert.DeserializeObject<Data>(File.ReadAllText(path));
    }

    private void SaveData()
    {
        File.WriteAllText(path, JsonConvert.SerializeObject(data));
    }

    public class Data
    {
        public Dictionary<string, (bool, bool)> Levels;
        public int TotalDeaths;
        public List<string> Gems;

        public Data()
        {
            Levels = new Dictionary<string, (bool, bool)>(24);
            TotalDeaths = 0;
            Gems = new List<string>(4);
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus) SaveData();
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }
}
