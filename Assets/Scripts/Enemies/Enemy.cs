using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, ITakeDamage
{
    [SerializeField] protected EnemyScriptableObject enemy;

    protected virtual void Movement()
    {

    }

    protected abstract void Attack();


    public void TakeDamage(float damageToTake)
    {
        
    }
}
