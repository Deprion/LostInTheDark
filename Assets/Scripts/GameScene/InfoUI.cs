using TMPro;
using UnityEngine;

public class InfoUI : MonoBehaviour
{
    [SerializeField] private TMP_Text lvlDeaths, totalDeaths, crystalTxt;

    private void Awake()
    {
        Events.LevelDeaths.AddListener(UpdateLvlDeaths, true);
        Events.TotalDeaths.AddListener(UpdateTotalDeaths, true);
        Events.CrystalCollected.AddListener(UpdateCrystals, true);
    }

    private void UpdateLvlDeaths(int amount) => lvlDeaths.text = $"Level Deaths {amount}";
    private void UpdateTotalDeaths(int amount) => totalDeaths.text = $"Total Deaths {amount}";
    private void UpdateCrystals(int cur, int max) => crystalTxt.text = $"Crystals {cur}/{max}";

    private void OnDestroy()
    {
        Events.LevelDeaths.RemoveListener(UpdateLvlDeaths);
        Events.TotalDeaths.RemoveListener(UpdateTotalDeaths);
        Events.CrystalCollected.RemoveListener(UpdateCrystals);
    }
}
