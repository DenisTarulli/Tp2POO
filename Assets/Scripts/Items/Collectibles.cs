using System;
using UnityEngine;

public class Collectibles : MonoBehaviour, ICollectItem
{
    [SerializeField] private CollectibleScriptableObject collectible;

    public static event Action<int> OnItemCollected;

    public void Collect()
    {
        OnItemCollected?.Invoke(collectible.scoreValue);
        GameObject collectedVfx = Instantiate(collectible.collectAnimation, transform.position, Quaternion.identity);

        Destroy(collectedVfx, 1.5f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        Collect();
    }
}
