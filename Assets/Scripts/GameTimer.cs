using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{

    [SerializeField] private float totalTime;

    private IEnumerator Timer()
    {
        while (!GameManager.gameFinish)
        {
            if (!WaveManager.waweTransition)
            {
                yield return new WaitForSeconds(1);
                totalTime += 1;
            }
            yield return null;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }
}
