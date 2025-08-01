using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int hp {get; private set;}
    [SerializeField] int maxHp;
    public static Action playerDeath;
    public Slider healthSlider;

    private void Start()
    {
        healthSlider.maxValue = maxHp;
        healthSlider.value = hp;
        Heal(maxHp);
    }
    public void Damage(int damage)
    {
        hp -= damage;
        healthSlider.value=hp;

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