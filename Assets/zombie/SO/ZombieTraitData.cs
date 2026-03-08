using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;

[CreateAssetMenu(fileName = "ZombieTraitData", menuName = "Scriptable Objects/ZombieTraitData")]
public class ZombieTraitData : ScriptableObject
{
    public string name;
    public string description;

    public ZombieDataTypes effectedData;
    public float changeAmt;

}
