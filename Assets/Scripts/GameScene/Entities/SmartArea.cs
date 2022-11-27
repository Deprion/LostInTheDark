using UnityEngine;

public class SmartArea : MonoBehaviour
{
    [SerializeField] private SmartSpikedSphere spike;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) spike.PlayerEnter();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) spike.PlayerExit();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) spike.PlayerStay(collision.transform.localPosition);
    }
}
