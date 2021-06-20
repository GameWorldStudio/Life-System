using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int timeBetweenWawe = 10;
    public static bool waweTransition = false;

    [Header("Vague croissante")]
    public WaweData[] waweDatas;
    private WaweData currentWaweData;

    private int currentWawe = 1;
    public static int ennemyLeft;

    private int CurrentWawe
    {
        get { return currentWawe; }
        set
        {
            this.currentWawe = value;
            onChange.Invoke(currentWawe) ; 
        }
    }

    public delegate void OnChangeWave(int wawe);
    public event OnChangeWave onChange;

    public int GetCurrentWave()
    {
        return currentWawe;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentWaweData = waweDatas[CurrentWawe - 1];
        onChange += OnChangeHandler;
        onChange.Invoke(currentWawe);
    }

    private void OnChangeHandler(int wawe)
    {
        currentWaweData = waweDatas[wawe-1];
        ennemyLeft = currentWaweData.ennemyNumber;
        GetComponent<SpwanerManager>().UpdateEnnemyProperties(currentWaweData.allEnnemyType);

    }

    public void UpdateEnnemyNumber()
    {
        ennemyLeft--;

        if(ennemyLeft == 0)
        {
            waweTransition = true;
            StartCoroutine(ChangeWawe());

        }
    }

    private IEnumerator ChangeWawe()
    {
        yield return new WaitForSeconds(timeBetweenWawe);
        waweTransition = false;
        CurrentWawe++;
        FindObjectOfType<UIManager>().UpdateWaveUI();
    }
}
