using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public List<ZombieTraitData> ZombieTraitDataList = new List<ZombieTraitData>();

    [SerializeField] private GameObject ZombiePrefab;

    public void Awake()
    {
    }
    public void SpawnNormal()
    {
        GameObject newZombie = Instantiate(ZombiePrefab);

        Zombie z = ZombieFactory.CreateZombie(ZombieType.NORMAL);
        newZombie.GetComponent<ZombieUpdater>().SetZombie(z);


    }
    public void SpawnNormalWithFast()
    {
        GameObject newZombie = Instantiate(ZombiePrefab);

        Zombie z = ZombieFactory.CreateZombie(ZombieType.NORMAL);
        z.ZombieDataSO.Traits.Add(ZombieTraitDataList[0]);
        newZombie.GetComponent<ZombieUpdater>().SetZombie(z);


    }
}
