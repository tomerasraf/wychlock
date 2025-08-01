using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hp {get; private set;}
    [SerializeField] int maxHp;
    public static Action playerDeath;

    private void Start()
    {
        Heal(maxHp);
    }
    public void Damage(int damage)
    {
        hp -= damage;

        if (hp < 0)
        {
            KillPlayer();
        }
    }
    public void Heal(int amount)
    {
        hp += amount;
        if (hp > maxHp)
        {
            hp = maxHp;
        }
    }
    private void KillPlayer()
    {
        playerDeath.Invoke();
    }
}