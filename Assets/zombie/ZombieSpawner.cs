using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public int StarterZombies;

    [SerializeField] private GameObject _zombiePrefab;

    private ZombieTrainer _zombieTrainer;

    private Draggable _draggable;

    public void Awake()
    {
        _zombieTrainer = GetComponent<ZombieTrainer>();

        _draggable = new Draggable();
    }

    public void Start()
    {
        _draggable.Init(1f);

        for (int i = 0;i < StarterZombies; i++)
        {
            SpawnNormal();
        }
    }

    public void Update()
    {
        _draggable.Dragging(transform);
    }

    public void SpawnNormal()
    {
        GameObject newZombie = Instantiate(_zombiePrefab);

        Zombie z = ZombieFactory.CreateZombie(ZombieType.NORMAL);
        newZombie.GetComponent<ZombieUpdater>().SetZombie(z);
        z.isAlive = true;
        z.isActive = true;
    }

    public void SpawnRandom()
    {
        GameObject newZombie = Instantiate(_zombiePrefab);

        Zombie z = ZombieFactory.CreateZombie(ZombieType.NORMAL);

        int traitAdded = 0;

        foreach(ZombieTraitData trait in _zombieTrainer.ZombieTraitList)
        {
            //trait raity determines initial chance, no. of trait added is secondary e.g 0 trait common -> 100 , 1 trait common 105
            float traitChance = Mathf.Pow(10, ((int)trait.Rarity + 1)) + 5 * traitAdded; 

            //1 make it 1 / traitChance e.g : 1/10 -> commom 
            if(Random.Range(0, traitChance) < 1)
            {
                _zombieTrainer.AddTrait(z, trait);
                traitAdded++;
            }
        }

        newZombie.GetComponent<ZombieUpdater>().SetZombie(z);
    }
}
