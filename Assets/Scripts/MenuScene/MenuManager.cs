using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject lvlPrefab;
    [SerializeField] private Button playBtn, resetBtn, soundBtn;

    [SerializeField] private Sprite baseSprite, goldSprite;

    [SerializeField] private UIStats uiStats;

    private void Awake()
    {
        if (Global.FirstLaunch)
        {
            YandexGame.GameReadyAPI();
            Global.FirstLaunch = false;
        }
    }

    private void Start()
    {
        AudioManager audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        soundBtn.onClick.AddListener(audio.Mute);

        playBtn.onClick.AddListener(delegate 
        {
            Global.Level = GetLastOpenedLevel();
            SceneManager.LoadScene("GameScene");
        });

        resetBtn.onClick.AddListener(delegate 
        { 
            DataManager.instance.ResetProgress();
            ResetLvl();
        });

        InitLvl(AddressableLoader.inst.GetCount());
    }

    private int GetLastOpenedLevel()
    {
        for (int i = 1; i <= AddressableLoader.inst.GetCount(); i++)
        {
            (bool, bool) values = DataManager.instance.GetLvl(i);

            if (!values.Item1 && DataManager.instance.GetLvl(i - 1).Item1)
            {
                return i;
            }
        }

        int indexLast = AddressableLoader.inst.GetCount();
        (bool, bool) lastLvl = DataManager.instance.GetLvl(indexLast);

        if (lastLvl.Item1 && !lastLvl.Item2) return indexLast;

        return 1;
    }
    private void ResetLvl()
    {
        int max = parent.childCount;

        for (int i = max - 1; i >= 0; i--)
        {
            Destroy(parent.GetChild(i).gameObject);
        }

        uiStats.UpdateText();
        InitLvl(AddressableLoader.inst.GetCount());
    }

    private void InitLvl(int max)
    {
        for (int i = 1; i <= max; i++)
        {
            Sprite curSpr;
            bool locked = true;

            (bool, bool) values = DataManager.instance.GetLvl(i);

            if (values.Item1 || i == 1 || DataManager.instance.GetLvl(i - 1).Item1)
            {
                locked = false;
            }
            if (values.Item2) curSpr = goldSprite;
            else curSpr = baseSprite;

            var obj = Instantiate(lvlPrefab, parent, false);
            obj.GetComponent<Level>().Init(i, curSpr, LoadLevel, locked);
        }
    }

    private void LoadLevel(int lvl)
    {
        Global.Level = lvl;
        SceneManager.LoadScene("GameScene");
    }

    private void OnDestroy()
    {
        playBtn.onClick.RemoveAllListeners();
        resetBtn.onClick.RemoveAllListeners();
        soundBtn.onClick.RemoveAllListeners();
    }
}
