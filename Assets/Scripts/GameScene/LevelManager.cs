using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Transform parent;

    public static LevelManager inst;

    private int curCrystal, maxCrystal;

    private void Awake()
    {
        inst = this;

        curCrystal = 0;
        maxCrystal = 0;

        maxCrystal = parent.childCount;

        Events.CrystalCollected.Invoke(curCrystal, maxCrystal);
    }

    public void CrystalCollected()
    {
        curCrystal++;

        Events.CrystalCollected.Invoke(curCrystal, maxCrystal);

        if (curCrystal >= maxCrystal)
        {
            Events.ExitOpen.Invoke(true);
        }
    }
}
