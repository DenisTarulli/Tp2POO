using UnityEngine;

[CreateAssetMenu(fileName = "Collectible", menuName = "Objects/Collectible")]
public class CollectibleScriptableObject : ScriptableObject
{
    public int scoreValue;
    public GameObject collectAnimation;
}
