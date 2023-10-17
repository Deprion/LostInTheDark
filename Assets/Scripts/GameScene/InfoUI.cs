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

    private void UpdateLvlDeaths(int amount) => lvlDeaths.text = $"{TranslateManager.inst.GetText("leveldeaths")} {amount}";
    private void UpdateTotalDeaths(int amount) => totalDeaths.text = $"{TranslateManager.inst.GetText("totaldeaths")} {amount}";
    private void UpdateCrystals(int cur, int max) => crystalTxt.text = $"{TranslateManager.inst.GetText("crystals")} {cur}/{max}";

    private void OnDestroy()
    {
        Events.LevelDeaths.RemoveListener(UpdateLvlDeaths);
        Events.TotalDeaths.RemoveListener(UpdateTotalDeaths);
        Events.CrystalCollected.RemoveListener(UpdateCrystals);
    }
}
