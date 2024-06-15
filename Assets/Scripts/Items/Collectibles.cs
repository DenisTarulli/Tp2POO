using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour, ICollectItem
{
    [SerializeField] private CollectibleScriptableObject collectible;

    public static event Action<int> OnItemCollected;

    public void Collect()
    {
        OnItemCollected?.Invoke(collectible.scoreValue);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
