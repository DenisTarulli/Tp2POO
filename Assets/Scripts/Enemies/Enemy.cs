using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;

    protected virtual void Movement()
    {

    }

    protected abstract void Attack();    

    protected void TakeDamage()
    {

    }
}
