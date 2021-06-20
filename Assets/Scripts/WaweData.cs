using UnityEngine;

[CreateAssetMenu(fileName = "Wawedata", menuName = "WaweData/waweData")]
public class WaweData : ScriptableObject
{
    public int ennemyNumber;
    public int shootNumber;
    public EnnemyData[] allEnnemyType;

}
