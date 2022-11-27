using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] private ParticleSystem FX;

    private void Awake()
    {
        Events.ExitOpen.AddListener(ExitOpen);

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    private void ExitOpen(bool value)
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;

        FX.Play();
    }

    private void OnDestroy()
    {
        Events.ExitOpen.RemoveListener(ExitOpen);
    }
}
