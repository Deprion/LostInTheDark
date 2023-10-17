using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using YG;

public class TranslateManager : MonoBehaviour
{
    public static TranslateManager inst;
    private Dictionary<string, string> translate = new Dictionary<string, string>();

    private void Awake()
    {
        DontDestroyOnLoad(this);

        inst = this;
    }

    private void Start()
    {
        AddressableLoader.inst.LanguageLoaded += Setup;
    }

    private void Setup()
    {
        string lang = YandexGame.EnvironmentData.language;

        if (lang == "ru" || lang == "be" || lang == "kk" || lang == "uk" || lang == "uz")
            Fill(AddressableLoader.inst.GetLang("Russian"));
        else if (lang == "es")
            Fill(AddressableLoader.inst.GetLang("Spanish"));
        else if (lang == "tr")
            Fill(AddressableLoader.inst.GetLang("Turkish"));
        else
            Fill(AddressableLoader.inst.GetLang("English"));

        AddressableLoader.inst.LanguageLoaded -= Setup;
    }

    private void Fill(TextAsset txt)
    {
        Regex regex = new Regex(":|;\r?\n?");
        var arr = regex.Split(txt.text);

        for (int i = 0; i < arr.Length - 1; i+=2)
        {
            translate[arr[i]] = arr[i + 1];
        }
    }

    public string GetText(string text)
    {
        return translate[text];
    }
}
