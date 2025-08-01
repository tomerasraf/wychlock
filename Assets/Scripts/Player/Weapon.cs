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
    [Tooltip("Time between Shots")]
    public float fireRate;
    public int bulletPerShot;
    public float spreadDeegres;
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

    private bool canShoot = true;
    private void Start()
    {
        movement = GetComponent<Movment>();
        canShoot = true;
    }
    public void Shoot()
    {
        if (!canShoot)
        {
            return;
        }
        
        Vector2 barrelDirection= movement.GetBarrelDirection();

        float halfCone = weaponType.spreadDeegres / 2;
        float randomAngle = Random.Range(-halfCone, halfCone);
        Quaternion randomSpree = Quaternion.Euler(0,0,randomAngle);
        Vector2 direction = randomSpree * (Vector3)barrelDirection;

        for (int i = 0; i < weaponType.bulletPerShot; i++)
        {
            print(bulletSpawnPoint.position);
            GameObject bulletObj = Instantiate(weaponType.bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            Projectile bullet = bulletObj.GetComponent<Projectile>();
            bullet.Init(weaponType.bulletSpeed, direction, weaponType.bulletDamage, weaponType.lifeSpan);
        }

        //Vector3 recoilDirection = Quaternion.Euler(0, 0, 180) * direction;
        //transform.position += recoilDirection * weaponType.recoilForce;

        canShoot = false;
        StartCoroutine(FireRatePause());

    }
    private IEnumerator FireRatePause()
    {
        yield return new WaitForSeconds(weaponType.fireRate);
        canShoot = true;
    }
}
