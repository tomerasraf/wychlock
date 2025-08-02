using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoAnimation : MonoBehaviour
{
    [SerializeField] private bool isPlayer;

    private void Start()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            isPlayer = false;
        }
        else
        {
            isPlayer = true;
        }
        Health.playerDeath += EndRoundAnimation;
    }
    void EndRoundAnimation(bool playerDied)
    {
        if (playerDied)
        {
            if (isPlayer)
            {
                
            }

            if (!isPlayer)
            {
                
            }
        }
        if(!playerDied)//boss dead
        {
            if (isPlayer)
            {
                
            }

            if (!isPlayer)
            {
                
            }
        }
/*
        isPlayer
        enemyReciver.transform.DOPunchScale(Vector3.one * 0.2f, 0.2f).OnComplete(() =>
        {
            transform.DOScale(1.5f, 2f).OnComplete(() =>
            {
                transform.DOScale(0, 1f);
            });
                
            transform.GetComponent<SpriteRenderer>().DOFade(0.5f, 1f);
                
            transform.DOMoveY(3, 2).OnComplete(() =>
            {
                transform.DOMove(enemyReciver.transform.position, 0.2f).OnComplete(() =>
                {
                    enemyReciver.transform.DOShakeRotation(1f, Vector3.forward * 15, 7);
                });
            });
                
                
                
            enemyReciver.gameObject.SetActive(false);
            GameManager.Instance.StartNewRun();
        });*/
    }
}
