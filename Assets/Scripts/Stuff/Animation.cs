using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField] protected Sprite[] sprites;
    [SerializeField] protected float timer;
    protected float leftTime;
    protected int index = 0;

    protected SpriteRenderer image;

    protected virtual void Start()
    {
        SetUp();
    }

    protected virtual void Update()
    {
        Anim();
    }

    protected virtual void SetUp()
    {
        image = GetComponent<SpriteRenderer>();
        image.sprite = sprites[index];
        leftTime = timer;
    }

    protected virtual void Anim()
    {
        leftTime -= Time.deltaTime;

        if (leftTime <= 0)
        {
            leftTime = timer;

            index = index + 1 >= sprites.Length ? 0 : index + 1;

            image.sprite = sprites[index];
        }
    }
}
