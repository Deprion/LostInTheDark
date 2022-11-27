using System.Collections;
using UnityEngine;

public class Plate : MonoBehaviour
{
    [SerializeField] private float timeAwait;
    [SerializeField] private GameObject[] spikes;
    private WaitForSeconds waitFor;
    private BoxCollider2D col;
    private SpriteRenderer spr;

    private void Awake()
    {
        waitFor = new WaitForSeconds(timeAwait);
        col = GetComponent<BoxCollider2D>();
        spr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(SwitchSpike());
        }
    }

    private IEnumerator SwitchSpike()
    {
        col.enabled = false;
        spr.color = Color.gray;

        foreach (var spike in spikes)
        {
            spike.SetActive(false);
        }

        yield return waitFor;

        col.enabled = true;
        spr.color = Color.white;

        foreach (var spike in spikes)
        {
            spike.SetActive(true);
        }
    }
}
