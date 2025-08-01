using UnityEngine;

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