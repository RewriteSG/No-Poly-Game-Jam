using System.Collections.Generic;
using UnityEngine;

public class ZombieTrainer : MonoBehaviour
{
    public List<ZombieTraitData> ZombieTraitList = new List<ZombieTraitData>();

    public Dictionary<string, ZombieTraitData> ZombieTraitDictionary = new Dictionary<string, ZombieTraitData>();

    private void Awake()
    {
        ZombieTraitDictionary.Clear();

        foreach (ZombieTraitData trait in ZombieTraitList)
        {
            ZombieTraitDictionary.Add(trait.Name, trait);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddTrait(Zombie zombie, ZombieTraitData trait)
    {
        if(zombie == null) return;

        zombie.ZombieDataSO.Traits.Add(trait);
    }
}
