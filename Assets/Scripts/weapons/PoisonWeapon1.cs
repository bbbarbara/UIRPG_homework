using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonWeapon : Weapon
{
    [SerializeField] private int poisonStrenght = 3;

    public override void ApplyEffect(Character target)
    {
        Debug.Log(target.name + "poisoned for" + poisonStrenght);
        target.GetHit(poisonStrenght);
    }
}
