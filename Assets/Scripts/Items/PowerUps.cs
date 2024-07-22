using System;
using UnityEngine;

public abstract class PowerUps : MonoBehaviour, ICollectItem
{
    protected abstract void PowerUpEffect();

    [SerializeField] protected GameObject collectEffect;
    [SerializeField] protected float duration;


    public static event Action OnPowerUpCollected;

    public void Collect()
    {
        OnPowerUpCollected?.Invoke();

        PowerUpEffect();

        GameObject collectedVfx = Instantiate(collectEffect, transform.position, Quaternion.identity);

        Destroy(collectedVfx, 1.5f);
    }

    protected void DisableCollection()
    {
        transform.localScale = Vector3.zero;
        GetComponent<CircleCollider2D>().enabled = false;
    }
}
