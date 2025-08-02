using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int hp {get; private set;}
    [SerializeField] int maxHp;
    public static Action<bool> playerDeath;
    public Image healthUI;
    private bool isPlayer = true;

    public AudioClip hurt_sfx;
    public AudioClip health_sfx;
    public AudioClip die_sfx;

    private void Start()
    {
        Heal(maxHp);
        UIUpdate();
    }
    public void Damage(int damage)
    {
        hp -= damage;
        UIUpdate();

        if (hp < 0)
        {
            KillPlayer();
        }
        AudioManager.Instance.PlaySFX(hurt_sfx, 1);
    }
    public void Heal(int amount)
    {
        hp += amount;
        if (hp > maxHp)
        {
            hp = maxHp;
        }
        AudioManager.Instance.PlaySFX(health_sfx, 1);
        UIUpdate();
    }
    private void KillPlayer()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            isPlayer = false;
        }
        else
        {
            isPlayer = true;
        }
        AudioManager.Instance.PlaySFX(die_sfx, 1);
        playerDeath.Invoke(isPlayer);
    }

    private void UIUpdate()
    {
        print(gameObject.name + " hp: " + hp);
        print(gameObject.name + " maxhp: " + maxHp);
        print(gameObject.name + " fill: " + (float)hp / (float)maxHp);
        healthUI.fillAmount = (float)hp / (float)maxHp;
    }
}