using UnityEngine;

public class Hint : MonoBehaviour
{
    [SerializeField] private GameObject hint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hint.SetActive(true);
        }
    }
}
