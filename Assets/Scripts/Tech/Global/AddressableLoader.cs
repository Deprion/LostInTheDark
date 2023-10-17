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

    private string key = "level";
    private AsyncOperationHandle<IList<GameObject>> handle;

    private Dictionary<string, GameObject> levels = new Dictionary<string, GameObject>();
    public List<AudioClip> music = new List<AudioClip>(4);

    public GameObject GetLevel(int num)
    {
        return levels[$"Level_{num}"];
    }
    public int GetCount()
    {
        return levels.Count;
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

        yield return handle;

        foreach (var item in handle.Result)
        {
            levels.Add(item.name, item);
        }

        yield return musicHandle;

        musicDone.Invoke(musicHandle.Result.ToArray());

        Addressables.Release(musicHandle);
    }

    private void OnDestroy()
    {
        Addressables.Release(handle);
    }
}
