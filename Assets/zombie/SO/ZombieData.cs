using UnityEngine;

[CreateAssetMenu(fileName = "ZombieData", menuName = "Scriptable Objects/ZombieData")]
public class ZombieData : ScriptableObject
{
    public ZombieType type;

    public ZombieTraitData[] traits;

}

public enum ZombieType
{
    NORMAL,
    TANK,
}

public enum ZombieDataTypes
{
    Health,
    Speed,
    Attack,
}



