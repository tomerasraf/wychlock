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
    [SerializeField] WeaponType weaponType;
    [SerializeField] Movment movement;
    [SerializeField] Transform bulletSpawnPoint;
    private void Start()
    {
        movement = GetComponent<Movment>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        Vector2 direction = movement.GetBulletDirection();
        GameObject bulletObj = Instantiate(weaponType.bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        Projectile bullet = bulletObj.GetComponent<Projectile>();
        bullet.Init(weaponType.bulletSpeed, direction, weaponType.bulletDamage, weaponType.lifeSpan);
        
        //float halfSpread = weaponType.spreadDegres / 2;

        /*for (int i = 0; i < weaponType.bulletPerShot; i++) 
        {
            GameObject bulletObj = Instantiate(weaponType.bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            Projectile bullet = bulletObj.GetComponent<Projectile>();
            bullet.Init(weaponType.bulletSpeed, direction, weaponType.bulletDamage, weaponType.lifeSpan);
        }*/
        
    }

}
