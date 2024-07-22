using System.Collections;
using UnityEngine;

public class JumpPowerUp : PowerUps
{
    [SerializeField, Range(1.1f, 1.5f)] private float jumpMultiplier;

    protected override void PowerUpEffect()
    {
        DisableCollection();
        StartCoroutine(JumpDuration());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        Collect();
    }

    private IEnumerator JumpDuration()
    {
        PlayerMovement player = FindObjectOfType<PlayerMovement>();

        player.JumpForce *= jumpMultiplier;

        yield return new WaitForSeconds(duration);

        player.JumpForce /= jumpMultiplier;
    }
}
