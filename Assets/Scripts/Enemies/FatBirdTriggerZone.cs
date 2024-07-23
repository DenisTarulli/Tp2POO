using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatBirdTriggerZone : MonoBehaviour
{
    [SerializeField] private FatBird enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        enemy.TriggerAttack();
    }
}
