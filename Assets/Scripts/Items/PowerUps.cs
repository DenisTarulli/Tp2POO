using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUps : MonoBehaviour, ICollectItem
{
    protected abstract void PowerUpEffect();

    public static event Action OnPowerUpCollected;

    public void Collect()
    {
        OnPowerUpCollected?.Invoke();
    }
}
