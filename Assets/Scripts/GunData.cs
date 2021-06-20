using UnityEngine;

[CreateAssetMenu(fileName = "GunData", menuName = "Gun/GunData")]
public class GunData : ScriptableObject
{
    public GameObject gunModel;
    public int damage;
    public Sprite gunSprite;
    public int cadency;
    public int recquieredWawe;
}
