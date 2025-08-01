using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponTypes
{
    Pistol,
    Shotgun,
    Sniper,
    GrenadeLauncher
}
[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapons")]
public class WeaponType : ScriptableObject
{
    public WeaponTypes weaponType;
    public GameObject bulletPrefab;
    public int bulletPerShot;
    public int bulletDamage;
    public float spreadDegres;
    public float lifeSpan;
    public float recoilForce;
    
}
public class Weapon : MonoBehaviour
{
    public void Shoot()
    {
    }

}
