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

        life.Value = maxLife;

        life.onValueChange += OnChange;

    }

    public void OnChange(int value)
    {
        UIManager.UpdateLifeUi(value, shield);

        if (life.Value <= 0)
        {
            OnDie.Invoke();
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        int inter = (shield -= damage); // 2-1

        if (inter < 0)
        {
            life.Value -= -inter;
        }

        if (shield <= 0)
        {
            shield = 0;
        }

         GetComponent<Animator>().Play("Damaged", -1, 0f);
        
    }

    public void TakeHealth(HealthData healthAttributs)
    {
        life.Value += healthAttributs.healthPoint;
        shield += healthAttributs.shieldPoint;

        if(life.Value > maxLife)
        {
            life.Value = maxLife;
        }

        if(shield > maxShield)
        {
            shield = maxShield;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Health") && life.Value < maxLife) || (other.CompareTag("Shield") && shield < maxShield))
        {
            HealthData healthAttributs = other.GetComponent<HealthProperties>().GetHealthAttributs();

            TakeHealth(healthAttributs);
            Destroy(other.gameObject);
        }
    }

}
