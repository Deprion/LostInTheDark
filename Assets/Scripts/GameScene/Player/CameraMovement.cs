using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private PlayerMovement player;

    private void LateUpdate()
    {
        if (player == null)
        {
            TrySearch();
        }

        Vector3 pos = player.transform.localPosition;

        pos.z = -10;

        transform.localPosition = pos;
    }

    private void TrySearch()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
}
