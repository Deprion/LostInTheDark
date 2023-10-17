using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableLoader : MonoBehaviour
{
    public static AddressableLoader inst { get; private set; }

    public SimpleEvent<AudioClip[]> musicDone = new SimpleEvent<AudioClip[]>();
    public Action LanguageLoaded;

    private string key = "level";
    private AsyncOperationHandle<IList<GameObject>> handle;

    private Dictionary<string, GameObject> levels = new Dictionary<string, GameObject>();
    private Dictionary<string, TextAsset> languages = new Dictionary<string, TextAsset>();

    public GameObject GetLevel(int num)
    {
        return levels[$"Level_{num}"];
    }
    public int GetCount()
    {
        return levels.Count;
    }

    public TextAsset GetLang(string lang)
    {
        return languages[lang];
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
        inst = this;
    }

    private IEnumerator Start()
    {
        handle = Addressables.LoadAssetsAsync<GameObject>(
            key,
            addressable => {} );

        var musicHandle = Addressables.LoadAssetsAsync<AudioClip>(
            "music",
            addressable => { });

        var langHandle = Addressables.LoadAssetsAsync<TextAsset>(
            "lang",
            addressable => { });

        yield return handle;

        foreach (var item in handle.Result)
        {
            levels.Add(item.name, item);
        }

        yield return musicHandle;

        musicDone.Invoke(musicHandle.Result.ToArray());

        yield return langHandle;

        LanguageLoaded.Invoke();

        Addressables.Release(langHandle);
        Addressables.Release(musicHandle);
    }

    private void OnDestroy()
    {
        Addressables.Release(handle);
    }
}
