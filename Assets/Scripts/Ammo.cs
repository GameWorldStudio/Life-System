using UnityEngine;

public class Ammo : MonoBehaviour
{
    private int damage;

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemy"))
        {
            other.GetComponent<EnnemyLife>().TakeDamage(damage);
        }
    }
}
