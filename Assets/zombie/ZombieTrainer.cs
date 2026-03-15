using System.Collections.Generic;
using System.Linq;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.LowLevelPhysics;
using UnityEngine.Rendering;

public class ZombieTrainer : MonoBehaviour
{
    public static ZombieTrainer Instance;

    public List<ZombieTraitData> ZombieTraitList = new List<ZombieTraitData>();

    public void Awake()
    {
        Instance = this;
    }
    public void AddTrait(Zombie zombie, ZombieTraitData trait)
    {
        if(zombie == null) return;

        zombie.ZombieDataSO.Traits.Add(trait);
        zombie.UpdateTraitData();
    }

    public void AddRandomTrait(Zombie zombie)
    {
        int traitAdded = 0;

        foreach(ZombieTraitData trait in ZombieTraitList)
        {
              if(traitChance(trait, traitAdded))
           {
                AddTrait(zombie, trait);
                traitAdded++;
            }
        }
    }

    public void AddRandomSpecialisedTrait(Zombie zombie, List<ZombieTraitData> zombieTraits)
    {
        if(zombieTraits.Count() == 0)
            return;

        int traitAdded = zombie.ZombieDataSO.Traits.Count;

        foreach(ZombieTraitData trait in zombieTraits)
        {
           if(zombie.ZombieDataSO.Traits.Contains(trait))
           continue;
           
           if(traitChance(trait, traitAdded))
           {
                AddTrait(zombie, trait);
                traitAdded++;
            }
        }        
    }
    public bool traitChance(ZombieTraitData trait, int traitAdded)
    {
          //trait raity determines initial chance, no. of trait added is secondary e.g 0 trait common -> 100 , 1 trait common 105
            float traitChance = Mathf.Pow(10, (int)trait.Rarity + 1) + 5 * traitAdded; 

            //1 make it 1 / traitChance e.g : 1/10 -> commom 
            if(Random.Range(0, traitChance) < 1)
            {
                return true;
            }
        return false;
    }
}
