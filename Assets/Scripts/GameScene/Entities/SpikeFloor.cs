using System.Collections;
using UnityEngine;

public class SpikeFloor : MonoBehaviour
{
    [SerializeField] private GameObject spike;
    private BoxCollider2D col;

    private WaitForSeconds twoSec = new WaitForSeconds(1.5f);

    private void Awake()
    {
        col = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(InvokeSpike());
        }
    }

    private IEnumerator InvokeSpike()
    {
        col.enabled = false;

        yield return twoSec;

        spike.SetActive(true);

        yield return twoSec;

        spike.SetActive(false);
        col.enabled = true;
    }
}
