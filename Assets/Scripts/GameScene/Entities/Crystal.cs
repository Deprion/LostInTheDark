using UnityEngine;

public class Crystal : MonoBehaviour
{
    private SpriteRenderer image;
    private float curTime = 0;
    private int multi = 1;

    private void Awake()
    {
        image = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        curTime += Time.deltaTime * multi;
        image.color = RGBLerp.Lerp(curTime);

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
