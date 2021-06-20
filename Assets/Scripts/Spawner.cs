using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static EnnemyData[] ennemyData;
    public GameObject ennemyPrefab;

    public delegate void SpawnEnnemy();
    public event SpawnEnnemy spawnEnnemy;

    public Transform spawnerTransform;

    void Start()
    {
        spawnEnnemy += SpawnHandler;
    }

    public void SpawnHandler()
    {
        GameObject ennemy = GameObject.Instantiate(ennemyPrefab, spawnerTransform.position, spawnerTransform.rotation);
        ennemy.GetComponent<IAController>().SetEnnemyProperties(ennemyData[Random.Range(0, ennemyData.Length)]);
    }
}
