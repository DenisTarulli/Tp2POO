using System.Collections;
using UnityEngine;

public class SpeedPowerUp : PowerUps
{
    [SerializeField, Range(1.1f, 1.5f)] private float speedMultiplier;

    protected override void PowerUpEffect()
    {
        DisableCollection();
        StartCoroutine(SpeedBuff());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        Collect();
    }

    private IEnumerator SpeedBuff()
    {
        PlayerMovement player = FindObjectOfType<PlayerMovement>();

        player.MoveSpeed *= speedMultiplier;

        yield return new WaitForSeconds(duration);

        player.MoveSpeed /= speedMultiplier;
    }
}
