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
    public int bulletPerShot;
    public float spreadDegres;
    public float recoilForce;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public int bulletDamage;
    public float lifeSpan;

}
public class Weapon : MonoBehaviour
{
    public WeaponType weaponType;
    private Movment movement;
    private void Start()
    {
        movement = GetComponent<Movment>();
    }
    public void Shoot()
    {
        Vector2 direction = movement.GetBulletDirection();

        //float halfSpread = weaponType.spreadDegres / 2;

        for (int i = 0; i < weaponType.bulletPerShot; i++) 
        {
            GameObject bulletObj = Instantiate(weaponType.bulletPrefab);
            Projectile bullet = bulletObj.GetComponent<Projectile>();
            bullet.Init(weaponType.bulletSpeed, direction, weaponType.bulletDamage, weaponType.lifeSpan);
        }
        
    }

}
