using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;

[CreateAssetMenu(fileName = "ZombieTraitData", menuName = "Scriptable Objects/ZombieTraitData")]
public class ZombieTraitData : ScriptableObject
{
    public string Name;
    public string Description;

    [Header("Data Changes")]
    public ZombieDataTypes EffectedData;
    public float ChangeAmt;
    public bool Multiply; 
}
