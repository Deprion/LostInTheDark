using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyboardManager : MonoBehaviour
{
    private float restartTime = 1f;
    private float restartLeft = 0;

    private void Update()
    {
        if (Input.GetAxisRaw("Cancel") > 0)
        {
            SceneManager.LoadScene("MenuScene");
        }

        if (restartLeft >= 0)
        { 
            restartLeft -= Time.deltaTime;
            return;
        }

        if (Input.GetKey(KeyCode.R))
        {
            restartLeft = restartTime;
            GameManager.inst.RestartLvl();
        }

    }
}
