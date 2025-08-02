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
    public Slider healthSlider;
    private bool isPlayer = true;

    private void Start()
    {
        Heal(maxHp);
        healthSlider.maxValue = maxHp;
        healthSlider.value = hp;
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

        healthSlider.value = hp;

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

        playerDeath.Invoke(isPlayer);
    }

    private void Update()
    {
        healthSlider.transform.position = new Vector3(this.transform.position.x, this.transform.position.y+1, this.transform.position.z);
    }

    public void ResetHealth()
    {
        hp = maxHp;
    }

    /*void OnDisable()
    {
        gameObject.SetActive(true);
        transform.position = new Vector3(0,0,0);
    }*/
}