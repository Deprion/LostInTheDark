using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem FX;
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private BoxCollider2D col;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            FX.Play();
            movement.enabled = false;
            col.enabled = false;
            StartCoroutine(GameManager.inst.Die());
        }
        else if (collision.CompareTag("Crystal"))
        {
            collision.GetComponent<Crystal>().Hit();
        }
        else if (collision.CompareTag("Exit"))
        {
            GameManager.inst.CompleteLevel();
        }
    }
}
