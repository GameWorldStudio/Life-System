using UnityEngine;

public class PlayerLife : Life, IDamageable, IHealthable
{

    [SerializeField] public int shield = 0;
    private int maxLife;
    private int maxShield;

    public int HealthPoint { get; set; }
    public int Damage { get; set; }
    public int ShieldhPoint { get; set; }

    public static bool playerDeath = false;

    public delegate void OnPlayerDie();

    public event OnPlayerDie OnDie;

    UIManager UIManager;

    public void PlayerDie()
    {
        playerDeath = true;

        //GameOver stat etc
    }

    private void Start()
    {
        UIManager = FindObjectOfType<UIManager>();

        OnDie += PlayerDie;

        UIManager.InitializeUIContainer();
        maxLife = UIManager.GetHeartLength();
        maxShield = UIManager.GetShieldLength();

        life = maxLife;

    }

    public void TakeDamage(int damage)
    {
        int inter = (shield -= damage); // 2-1

        if (inter < 0)
        {
            life -= -inter;
        }

        if (shield <= 0)
        {
            shield = 0;
        }

        if (life <= 0)
        {
            Destroy(gameObject);
            OnDie.Invoke();
        }

            UIManager.UpdateLifeUi(life, shield);
            GetComponent<Animator>().Play("Damaged", -1, 0f);
        
    }

    public void TakeHealth(HealthData healthAttributs)
    {
        life += healthAttributs.healthPoint;
        shield += healthAttributs.shieldPoint;

        if(life > maxLife)
        {
            life = maxLife;
        }

        if(shield > maxShield)
        {
            shield = maxShield;
        }

        UIManager.UpdateLifeUi(life, shield);
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Health") && life < 3) || (other.CompareTag("Shield") && shield < 2))
        {
            HealthData healthAttributs = other.GetComponent<HealthProperties>().GetHealthAttributs();

            TakeHealth(healthAttributs);
            Destroy(other.gameObject);
        }
    }

}
