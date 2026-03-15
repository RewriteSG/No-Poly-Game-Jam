using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public int StarterZombies;

    [SerializeField] private GameObject _zombiePrefab;

    private Draggable _draggable;

    public void Awake()
    {

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

    public Zombie SpawnNormal()
    {
        GameObject newZombie = Instantiate(_zombiePrefab);

        Zombie z = ZombieFactory.CreateZombie(ZombieType.NORMAL);
        newZombie.GetComponent<ZombieUpdater>().SetZombie(z);
        z.isAlive = true;
        z.isActive = true;

        return z;
    }

    public void SpawnRandom()
    {
        GameObject newZombie = Instantiate(_zombiePrefab);

        ZombieType type = (ZombieType) Random.Range(0, (int)ZombieType.TOTAL -1);
        Zombie z = ZombieFactory.CreateZombie(type);
        
        ZombieTrainer.Instance.AddRandomTrait(z);

        newZombie.GetComponent<ZombieUpdater>().SetZombie(z);
    }

}
