using UnityEngine;

[CreateAssetMenu(fileName = "EnnemyData", menuName = "Ennemy/EnnemyData")]
public class EnnemyData : ScriptableObject
{
    public int ennemyLife;
    public float ennemySpeed;
    public int ennemyDamage;
    public int ennemyScore;
    public Material ennemyColor;
}
