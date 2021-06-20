using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Life")]
    public GameObject heartContainer;
    public GameObject shieldContainer;
    [SerializeField] Image[] allHeart;
    public Sprite[] heartStatus;
    Image[] allShield;
    public Sprite[] shieldStatus;

    [SerializeField] Text waveNumber = null;

    public Transform scoreSpawn;
    [SerializeField] private GameObject scorePrefab = null;


    public void InitializeUIContainer()
    {
        allHeart = new Image[heartContainer.transform.childCount-1];
        allShield = new Image[shieldContainer.transform.childCount-1];


        for (int i = 0; i < heartContainer.transform.childCount-1; i++)
        {
            allHeart[i] = heartContainer.transform.GetChild(i).gameObject.GetComponent<Image>();
        }


        for (int i = 0; i < shieldContainer.transform.childCount-1; i++)
        {
            allShield[i] = shieldContainer.transform.GetChild(i).gameObject.GetComponent<Image>();
        }
    }

    public int GetHeartLength()
    {
        return allHeart.Length;
    }

    public int GetShieldLength()
    {
        return allShield.Length;
    }

    public void UpdateLifeUi(int pLife, int pShield)
    {
        for (int i = 0; i < allHeart.Length; i++)
        {
            if(i < pLife)
            {
                allHeart[i].sprite = heartStatus[0];
            }
            else
            {
                allHeart[i].sprite = heartStatus[1];
            }
        }

        for (int i = 0; i < allShield.Length; i++)
        {
            if (i < pShield)
            {
                allShield[i].sprite = shieldStatus[0];
            }
            else
            {
                allShield[i].sprite = shieldStatus[1];
            }
        }
    }

    public void UpdateWaveUI()
    {
        GetComponent<Animator>().Play("ChangeWave", -1,0f);
    }

    private void SetWaveNumber()
    {
        waveNumber.text = FindObjectOfType<WaveManager>().GetCurrentWave().ToString();
    }

    public void ShowScore(int score)
    {
        Debug.Log("Ici");
       GameObject scoreUI =  Instantiate(scorePrefab, scoreSpawn.position, scoreSpawn.rotation, this.transform);

       scoreUI.GetComponent<Text>().text = score.ToString();
    }
}
