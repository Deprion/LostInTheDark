using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private TMP_Text lvl;
    [SerializeField] private Image frame;
    private Button btn;

    public void Init(int lvl, Sprite sprite, Action<int> action, bool locked)
    {
        btn = GetComponent<Button>();

        this.lvl.text = lvl.ToString();
        frame.sprite = sprite;

        if (locked)
        {
            frame.color = Color.grey;
            btn.interactable = false;
        }
        else
        { 
            btn.onClick.AddListener(() => action(lvl));
        }
    }

    private void OnDestroy()
    {
        btn.onClick.RemoveAllListeners();
    }
}
