using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager inst;

    private GameObject level;

    private int lvlDeaths = 0;

    private bool isDead = false;

    private void Awake()
    {
        inst = this;

        LoadLevel(Global.Level);

        Events.LevelDeaths.Invoke(lvlDeaths);
        Events.TotalDeaths.Invoke(DataManager.instance.data.TotalDeaths);
    }

    public IEnumerator Die()
    {
        isDead = true;

        lvlDeaths++;
        Events.LevelDeaths.Invoke(lvlDeaths);
        Events.TotalDeaths.Invoke(++DataManager.instance.data.TotalDeaths);

        yield return new WaitForSeconds(1);

        LoadLevel(Global.Level);
    }
    public void RestartLvl()
    {
        if (!isDead)
        {
            lvlDeaths++;
            Events.LevelDeaths.Invoke(lvlDeaths);
            Events.TotalDeaths.Invoke(++DataManager.instance.data.TotalDeaths);
        }

        StopAllCoroutines();

        LoadLevel(Global.Level);
    }

    public void CompleteLevel()
    {
        bool gold = lvlDeaths == 0 ? true : false;

        (bool, bool) lvl = DataManager.instance.GetLvl(Global.Level);

        if (!lvl.Item1 || (!lvl.Item2 && gold))
        {
            DataManager.instance.SetLvl(Global.Level, (true, gold));
        }

        ++Global.Level;
        lvlDeaths = 0;
        Events.LevelDeaths.Invoke(lvlDeaths);

        if (Global.Level - 1 >= AddressableLoader.inst.GetCount()) SceneManager.LoadScene("MenuScene");
        else LoadLevel(Global.Level);
    }

    private void LoadLevel(int num)
    {
        if (level != null) Destroy(level);

        level = Instantiate(AddressableLoader.inst.GetLevel(num));

        isDead = false;
    }
}
