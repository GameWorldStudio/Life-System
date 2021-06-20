using System.Collections;
using System.Linq;
using UnityEngine;

public class SpwanerManager : MonoBehaviour
{
    public float minTimeBetweenSpawn;
    public float maxTimeBetweenSpawn;

    private static int ennemyNumber;
    private int EnnemyNumber
    {
        get { return ennemyNumber; }
        set
        {
            ennemyNumber = value;
            if (EnnemyNumber != 0)
            {
                StartCoroutine(WaitForNextSpawn());
            }
        }
    }
    static Spawner[] allSpawner;

    private void Awake()
    {
        allSpawner = FindObjectsOfType<Spawner>();

        if(minTimeBetweenSpawn > maxTimeBetweenSpawn)
        {
            Debug.LogWarning("Le temps min des spawn est supérieur au temps max des spawn");
            minTimeBetweenSpawn = maxTimeBetweenSpawn;
        }
    }

    private IEnumerator WaitForNextSpawn()
    {
        yield return new WaitForSeconds(Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn));
        allSpawner[Random.Range(0, allSpawner.Length-1)].Invoke("SpawnHandler",0f);
        EnnemyNumber--;
    }

    public void UpdateEnnemyProperties(EnnemyData[] ennemyDatas)
    {
        EnnemyNumber = WaveManager.ennemyLeft;
        Spawner.ennemyData = ennemyDatas;

    } 
}
