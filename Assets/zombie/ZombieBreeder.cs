using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieBreeder : MonoBehaviour
{
    public static ZombieBreeder Instance;
    public Zombie ParentZombieA;
    public Zombie ParentZombieB;
    public bool ParentAAdded;
    public bool ParentBAdded;

    [SerializeField] private GameObject _zombiePrefab;

    void Awake()
    {
        ParentAAdded = ParentBAdded = false;
    }

    public void Update()
    {
        ParentZombieA.SetTargetPosition(transform.position - new Vector3(0.5f, -0.5f, 0f));
        ParentZombieB.SetTargetPosition(transform.position - new Vector3(-0.5f, -0.5f, 0f));
    }

    public void AddParent(Zombie parent)
    {
        if(!ParentAAdded)
        {
            if(ParentZombieB == parent)
                return;

            ParentZombieA = parent;
            ParentAAdded = true;
        }
        else if(!ParentBAdded)
        {
            if(ParentZombieA == parent)
                return;

            ParentZombieB = parent;
            ParentBAdded = true;
        }
    }

    public void RemoveParent()
    {
        if(ParentAAdded)
        {
            ParentZombieA = null;
            ParentAAdded = false;
        }

        if(ParentBAdded)
        {
            ParentZombieB = null;
            ParentBAdded = false;
        }

    }

    public void BreedParents()
    {
        if(ParentZombieA == null || ParentZombieB == null)
        {
            return;
        }

        List<ZombieTraitData> zombieTraits = new List<ZombieTraitData>();

        zombieTraits.AddRange(ParentZombieA.ZombieDataSO.Traits);
        zombieTraits.AddRange(ParentZombieB.ZombieDataSO.Traits);

        Zombie child = ZombieFactory.CreateZombie(ZombieType.NORMAL);

        ZombieTrainer.Instance.AddRandomTrait(child);
        ZombieTrainer.Instance.AddRandomSpecialisedTrait(child, zombieTraits);

        GameObject newZombie = Instantiate(_zombiePrefab);

        newZombie.GetComponent<ZombieUpdater>().SetZombie(child);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<ZombieUpdater>(out ZombieUpdater zombieUpdater))
        {
            AddParent(zombieUpdater._zombie);
        }
    }
}
