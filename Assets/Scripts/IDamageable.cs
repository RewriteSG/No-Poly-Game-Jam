using UnityEngine;

public interface IDamageable
{
    public void TakeDmg(float dmg);

    public void Heal(float heal);

    public void Die();
}
