using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Objects/Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    public float moveSpeed;
    public int scoreOnKill;
}
