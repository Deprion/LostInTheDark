using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

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
        if (Application.systemLanguage == SystemLanguage.Russian)
            Fill(AddressableLoader.inst.GetLang("Russian"));
        else if (Application.systemLanguage == SystemLanguage.Spanish)
            Fill(AddressableLoader.inst.GetLang("Spanish"));
        else if (Application.systemLanguage == SystemLanguage.Turkish)
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
