using UnityEngine;

public class ZombieUpdater : MonoBehaviour
{
    [SerializeField] private Zombie _zombie;

    public void SetZombie(Zombie zombie)
    {
        _zombie = zombie;
    }

    public void Awake()
    {
    }

    public void Start()
    {
        this.name = _zombie.ZombieDataSO.Type.ToString() + " zombie ";

        if (_zombie.ZombieDataSO.Traits.Count > 0)
        {
            this.name += " with ";
            foreach (ZombieTraitData trait in _zombie.ZombieDataSO.Traits)
            {
                this.name += trait.Name + " | ";
            }
        }
    }

    private void Update()
    {
        if (_zombie != null)
        {
            _zombie.Update(Time.deltaTime);
        }
    }
}
