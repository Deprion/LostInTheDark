using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] private GameObject hint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hint.SetActive(true);

            DataManager.instance.AddGem(Global.Level);

            Destroy(gameObject);
        }
    }
}
