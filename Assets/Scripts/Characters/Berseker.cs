using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berseker : Enemy
{
    [SerializeField] private int agressionGain = 5;
    
    public override int Attack()
    {
        aggresion += agressionGain;
        return Weapon.GetDamage()+ aggresion / 10;
    }
}
