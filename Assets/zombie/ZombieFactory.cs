using System.Collections.Generic;
using UnityEngine;

public static class ZombieFactory 
{
    public static Zombie CreateZombie(ZombieType type)
    {
        //create new zombie
        Zombie z = new Zombie();

        //create SO instance
        ZombieData zombieData = ScriptableObject.CreateInstance("ZombieData") as ZombieData;

        //set type 
        zombieData.Type = type;
        zombieData.Traits.Clear();

        //init
        zombieData.Init();

        z.ZombieDataSO = zombieData;
 
        return z;
    }
}
