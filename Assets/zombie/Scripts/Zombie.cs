using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

[Serializable]
public class Zombie 
{
    public ZombieData ZombieDataSO;

    //movement var
    public float _speed { get; private set; }

    //combat var
    public float _health { get; private set; }
    public float _dmg { get; private set; }

    public void Awake() { }
    public void Start()
    { 
        if(ZombieDataSO == null)
        {
            _speed = 10;

            _health = 10;
            _dmg = 1;
        }
        else
        {
            //get all base var first
            _speed = ZombieDataSO.BaseSpeed;
            
            _health = ZombieDataSO.BaseHealth;
            _dmg = ZombieDataSO.BaseDmg;

            //take traits into account
            foreach (ZombieTraitData trait in ZombieDataSO.Traits)
            {
                switch (trait.EffectedData)
                {
                    case ZombieDataTypes.SPEED:
                        _speed = trait.Multiply ? _speed * trait.ChangeAmt : _speed + trait.ChangeAmt;
                        break;

                    case ZombieDataTypes.HEALTH:

                        _health = trait.Multiply ? _health *  trait.ChangeAmt: _health + trait.ChangeAmt;
                        break;

                    case ZombieDataTypes.DAMAGE:

                        _dmg = trait.Multiply ? _dmg * trait.ChangeAmt : _dmg + trait.ChangeAmt;
                        break;
                }
            }

        }
    }
}

public enum ZombieDataTypes
{
    SPEED,
    HEALTH,
    DAMAGE,
}

