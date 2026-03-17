using UnityEngine;

[CreateAssetMenu]

public class ItemDataSO : ScriptableObject
{
    [SerializeField] public Sprite sprite;
    [SerializeField] public GameObject dropPrefab;
    public string itemName;
    public int damage;
    public bool isStackable;
    public int attackSpeed;
    public int energyCost;
}
