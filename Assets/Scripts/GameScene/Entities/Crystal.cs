using UnityEngine;

public class Crystal : MonoBehaviour
{
    private SpriteRenderer image;
    private float curTime = 0;
    private int multi = 1;

    private Light spotLight;

    private void Awake()
    {
        image = GetComponent<SpriteRenderer>();
        spotLight = GetComponentInChildren<Light>();
    }

    private void Update()
    {
        curTime += Time.deltaTime * multi;
        image.color = RGBLerp.Lerp(curTime);
        spotLight.color = RGBLerp.Lerp(curTime);

        if (curTime >= 3 || curTime <= 0)
        {
            multi = -multi;
        }
    }

    public void Hit()
    {
        LevelManager.inst.CrystalCollected();
        Destroy(gameObject);
    }
}
