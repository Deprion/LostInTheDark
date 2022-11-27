using UnityEngine;

public class SmartSpikedSphere : MonoBehaviour
{
    [SerializeField] private Vector2[] movePoints;
    [SerializeField] private float speed;

    private Rigidbody2D rb;

    private int curIndex;

    private Vector2 playerPos;
    private bool playerIn = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        curIndex = 1;
    }

    private void FixedUpdate()
    {
        Vector2 dir;

        if (playerIn && curIndex == 1)
        {
            dir = playerPos - (Vector2)transform.localPosition;
            dir.Normalize();
        }
        else
        {
            dir = movePoints[curIndex] - (Vector2)transform.localPosition;
            dir.Normalize();
        }

        rb.velocity = dir * speed * Time.fixedDeltaTime;
        if (Vector3.Distance(movePoints[curIndex], transform.localPosition) <= 0.1f)
            UpdateIndex();
    }

    public void PlayerEnter() => playerIn = true;
    public void PlayerExit() => playerIn = false;
    public void PlayerStay(Vector2 pos) => playerPos = transform.parent.InverseTransformPoint(pos);

    private void UpdateIndex()
    {
        curIndex = curIndex + 1 >= movePoints.Length ? 0 : curIndex + 1;
    }
}
