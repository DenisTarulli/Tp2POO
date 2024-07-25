using UnityEngine;

public class PlayerFeet : MonoBehaviour
{
    [SerializeField] private float stompRecoil;
    [SerializeField] private float invulnerabilityGrantedDuration;
    private Rigidbody2D rb;
    private PlayerCombat player;

    private void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        player = GetComponentInParent<PlayerCombat>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("WeakPoint")) return;

        player.TriggerInvulnerability(invulnerabilityGrantedDuration, false);

        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * stompRecoil, ForceMode2D.Impulse);
        Destroy(collision.transform.parent.gameObject);
    }
}
