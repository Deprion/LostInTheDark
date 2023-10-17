using UnityEngine;

public class ScreenMaker : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ScreenCapture.CaptureScreenshot(Random.Range(0, 1000) + ".png");
        }
    }
}
