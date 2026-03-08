using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class Zombie 
{
    public ZombieData ZombieDataSO;

    //movement var
    private float _speed;
    public float DEBUG_SPEED => _speed;

    //combat var
    private float _health;
    private float _dmg;

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
                    case ZombieDataTypes.Speed:
                        _speed = trait.Multiply ? _speed * trait.ChangeAmt : _speed + trait.ChangeAmt;
                        break;

                    case ZombieDataTypes.Health:

                        _health = trait.Multiply ? _health *  trait.ChangeAmt: _health + trait.ChangeAmt;
                        break;

                    case ZombieDataTypes.Damage:

                        _dmg = trait.Multiply ? _dmg * trait.ChangeAmt : _dmg + trait.ChangeAmt;
                        break;
                }
            }

        }
    }

    public void Update(float dt)
    {

    }
}

public enum ZombieDataTypes
{
    Speed,
    Health,
    Damage,
}
