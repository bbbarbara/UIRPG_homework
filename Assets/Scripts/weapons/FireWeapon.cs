using UnityEngine;

public class FireWeapon : Weapon
{
    [SerializeField] private int fireDamage = 7;
    public override void ApplyEffect(Character target)
    {
        Debug.Log(target.name + "poisoned for" + fireDamage);
        target.GetHit(fireDamage);
    }
}
