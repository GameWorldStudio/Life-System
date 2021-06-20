using UnityEngine;

public class EnnemyLife : Life, IDamageable
{
    public int Damage { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    WaveManager waveManager;

    private int ennemyScore;

    private void OnEnable()
    {
        waveManager = FindObjectOfType<WaveManager>();
    }

    public void SetEnnemyScore(int score)
    {
        ennemyScore = score;
    }

    public void TakeDamage(int damage)
    {
        life -= damage;

        if (life <= 0)
        {
            waveManager.UpdateEnnemyNumber();

            GameManager.AddPlayerScore(ennemyScore);

            Destroy(gameObject);
        }
        else
        {
            GetComponent<Animator>().Play("Damaged", -1, 0f);
        }
    }

    /// <summary>
    ///             TEST
    /// </summary>
    private void OnMouseDown()
    {
        if (gameObject.CompareTag("Ennemy"))
        {
            TakeDamage(1);
        }
    }
}
