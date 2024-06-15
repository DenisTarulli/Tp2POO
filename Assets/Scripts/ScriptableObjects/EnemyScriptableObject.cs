using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Objects/Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    public float moveSpeed;
    public float attackDamage;
    public float maxHealth;
}
