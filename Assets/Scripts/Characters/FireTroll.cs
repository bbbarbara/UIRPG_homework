using UnityEngine;

public class FireTroll : Enemy
{
    [SerializeField] private int burn = 10;
    
    public override int Attack()
    {
        return Weapon.GetDamage()+ aggresion / 10+ burn ;
    }
}
