using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class IAController : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Vector3 playerPos;
    private NavMeshAgent navMeshAgent;
    public int damage;
    private bool canAttack = true;
    private int ennemyScore;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void SetEnnemyProperties(EnnemyData ennemy)
    {
        navMeshAgent.speed = ennemy.ennemySpeed;
        damage = ennemy.ennemyDamage;
        GetComponent<EnnemyLife>().life = ennemy.ennemyLife;
        ennemyScore = ennemy.ennemyScore;
        transform.GetChild(0).GetComponent<MeshRenderer>().material = ennemy.ennemyColor;

        GetComponent<EnnemyLife>().SetEnnemyScore(ennemyScore);
    }

    private void FixedUpdate()
    {
        if (!PlayerLife.playerDeath)
        {
            playerPos = player.transform.position;
            navMeshAgent.SetDestination(playerPos);

            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (canAttack &&navMeshAgent.velocity.sqrMagnitude == 0f)
                {
                    StartCoroutine(Attack());
                    canAttack = false;
                }
            }
            else
            {
                StopCoroutine(Attack());
                canAttack = false;
            }
        }
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(2);

        if(canAttack)
            GiveDamage();
        
    }

    public void GiveDamage()
    {
        player.GetComponent<PlayerLife>().TakeDamage(damage);
        StartCoroutine(ReloadAttack());
    }

    IEnumerator ReloadAttack()
    {
        yield return new WaitForSeconds(3);
        canAttack = true;
    }
}
