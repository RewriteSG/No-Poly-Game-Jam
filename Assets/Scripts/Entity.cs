using UnityEngine;

public class Entity : IDamageable
{
    public bool isActive;

    public bool isAlive;

    public float Health;
    public float MaxHealth;


    public void Heal(float heal)
    {
        Health += heal;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
    }

    public void TakeDmg(float dmg)
    {
        Health -= dmg;
        Health = Mathf.Clamp(Health, 0, MaxHealth);

        if(Health == 0)
        {
            Die();
        }
    }
    public void Die()
    {
        isAlive = false;
    }
}
