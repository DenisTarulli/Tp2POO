using UnityEngine;

public class FatBirdTriggerZone : MonoBehaviour
{
    [SerializeField] private FatBird enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        if (enemy != null)
            enemy.TriggerAttack();
    }
}
