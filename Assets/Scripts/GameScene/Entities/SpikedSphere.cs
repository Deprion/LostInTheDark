using UnityEngine;

public class SpikedSphere : MonoBehaviour
{
    [SerializeField] private Vector2[] movePoints;
    [SerializeField] private float speed;

    private Rigidbody2D rb;

    private int curIndex;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        curIndex = 1;
    }

    private void FixedUpdate()
    {
        Vector2 dir = movePoints[curIndex] - (Vector2)transform.localPosition;
        dir.Normalize();
        rb.velocity = dir * speed * Time.fixedDeltaTime;

        if (Vector3.Distance(movePoints[curIndex], transform.localPosition) <= 0.1f)
            UpdateIndex();
    }

    private void UpdateIndex()
    {
        curIndex = curIndex + 1 >= movePoints.Length ? 0 : curIndex + 1;
    }

    private void OnDrawGizmosSelected()
    {
        if (movePoints.Length < 1) return;

        for (int i = 0; i < movePoints.Length - 1; i++)
        {
            Gizmos.DrawCube(movePoints[i], Vector3.one);
            Gizmos.DrawLine(movePoints[i], movePoints[i + 1]);
        }
        Gizmos.DrawCube(movePoints[movePoints.Length - 1], Vector3.one);
        Gizmos.DrawLine(movePoints[movePoints.Length - 1], movePoints[0]);
    }
}
