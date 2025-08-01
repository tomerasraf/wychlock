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



public class WeaponType : ScriptableObject
{
    WeaponTypes weaponType;
    int damage;
    float spreadDegree;
    
}
public class Weapon : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
