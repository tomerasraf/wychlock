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

    public AudioClip hurt_sfx;
    public AudioClip health_sfx;
    public AudioClip die_sfx;

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
        AudioManager.Instance.PlaySFX(die_sfx, 1);
        playerDeath.Invoke(isPlayer);
    }

    private void Update()
    {
        healthSlider.transform.position = new Vector3(this.transform.position.x, this.transform.position.y+1, this.transform.position.z);
    }

    /*void OnDisable()
    {
        gameObject.SetActive(true);
        transform.position = new Vector3(0,0,0);
    }*/
}