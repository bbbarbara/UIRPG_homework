using UnityEngine;

public class IceWeapon : Weapon
{
    [SerializeField] private int coldDamage =4;
    public override void ApplyEffect(Character target)
    {
        Debug.Log(target.name + "poisoned for" + coldDamage);
        target.GetHit(coldDamage);
    }
}
