using TMPro;
using UnityEngine;

public class UIStats : MonoBehaviour
{
    [SerializeField] private TMP_Text deathsTxt, gemsTxt;

    private void Awake()
    {
        UpdateText();
    }

    public void UpdateText()
    { 
        deathsTxt.text = $"{TranslateManager.inst.GetText("totaldeaths")}: {DataManager.instance.data.TotalDeaths}";
        gemsTxt.text = 
            $"{DataManager.instance.data.Gems.Count}/{DataManager.instance.data.Gems.Capacity} {TranslateManager.inst.GetText("gems")}";
    }
}
