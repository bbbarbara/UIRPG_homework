using UnityEngine;

public class IceTroll : Enemy
{
    [SerializeField] private int frostBite = 10;
    
    public override int Attack()
    {
        return Weapon.GetDamage()+ aggresion / 10 + frostBite;
    }
}
