using UnityEngine;

[CreateAssetMenu(fileName = "HealthData", menuName = "Health/HealthData")]
public class HealthData : ScriptableObject
{
    public int healthPoint;
    public int shieldPoint;
}
