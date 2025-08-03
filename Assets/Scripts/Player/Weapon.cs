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
public class Weapon : MonoBehaviour
{
    [SerializeField] WeaponType[] allWeapons;
    [SerializeField] WeaponType weaponType;
    [SerializeField] Movment movement;
    [SerializeField] Transform bulletSpawnPoint;

    public AudioClip cantShoot_SFX;

    public SpriteRenderer weaponSprite;



    public bool canShoot = true;
    private void Start()
    {
        canShoot = true;
    }
    public void Shoot()
    {
        if (!canShoot)
        {
            AudioManager.Instance.PlaySFX(cantShoot_SFX, 1);
            return;
        }
        
        Vector2 barrelDirection= movement.GetBarrelDirection();
        
        for (int i = 0; i < weaponType.bulletPerShot; i++)
        {
            GameObject bulletObj = Instantiate(weaponType.bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            Projectile bullet = bulletObj.GetComponent<Projectile>();
            Vector2 direction = RandomSpreadOffset(barrelDirection);
            bullet.Init(weaponType.bulletSpeed, direction, weaponType.bulletDamage, weaponType.lifeSpan, this.gameObject);
        }
        
        if (this.gameObject.CompareTag("Enemy"))
        {
            
        }

        //Vector3 recoilDirection = Quaternion.Euler(0, 0, 180) * direction;
        //transform.position += recoilDirection * weaponType.recoilForce;

        AudioManager.Instance.PlaySFX(weaponType.bulletSound, 1);

        canShoot = false;
        StartCoroutine(FireRatePause());
    }

    private Vector2 RandomSpreadOffset(Vector2 barrelDirection)
    {
        float halfCone = weaponType.spreadDeegres / 2;
        float randomAngle = Random.Range(-halfCone, halfCone);
        Quaternion randomSpree = Quaternion.Euler(0, 0, randomAngle);
        Vector2 direction = randomSpree * (Vector3)barrelDirection;
        return direction;
    }

    private IEnumerator FireRatePause()
    {
        yield return new WaitForSeconds(weaponType.fireRate);
        canShoot = true;
    }
    private void OnEnable()
    {
        weaponType = allWeapons[Random.Range(0, allWeapons.Length)];
        weaponSprite.sprite = weaponType.weaponSprite;
    }
}
