using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ZombieData", menuName = "Scriptable Objects/ZombieData")]
public class ZombieData : ScriptableObject
{
    [Header("Type and Trait")]
    public ZombieType Type;
    public List<ZombieTraitData> Traits = new List<ZombieTraitData>();

    //Movement Var

    [SerializeField] private float _baseSpeed = 10;

    //Combat Var

    [SerializeField] private float _baseDmg = 1;
    [SerializeField] private float _baseHealth = 10;

    #region public getters

    public float BaseSpeed => _baseSpeed;
    public float BaseDmg => _baseDmg;
    public float BaseHealth => _baseHealth;

    #endregion

    public void Init()
    {
        _baseSpeed = 10;
        _baseDmg = 1;
        _baseHealth = 10;
    }

}

public enum ZombieType
{
    NORMAL,
    TANK,
}




