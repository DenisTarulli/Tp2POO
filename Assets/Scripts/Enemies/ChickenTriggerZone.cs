using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenTriggerZone : MonoBehaviour
{
    [SerializeField] private Chicken enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        if (enemy != null)
            enemy.TriggerAttack(collision.transform);
    }
}
