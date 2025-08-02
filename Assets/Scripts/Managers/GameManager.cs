using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;
public enum GAME_STATE
{
    Battle,
    Dialog,
    Transition
}
public class GameManager : MonoBehaviour
{
    private List<PlayerInputFrame> recordedFrames = new List<PlayerInputFrame>();
    public static GameManager Instance;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform enemySpawnPoint;
    [SerializeField] private Transform playerSpawnPoint;
    
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        player.GetComponent<PlayerInput>().enabled = false;
        player.transform.position = playerSpawnPoint.position;
        player.transform.DOMoveX(-8, 1.8f).OnComplete(() =>
        {
            player.GetComponent<PlayerInput>().enabled = true;
        });
    }

    public void setRecordedFrames(List<PlayerInputFrame> recordedFrames)
    {
        this.recordedFrames = recordedFrames;
    }

    public List<PlayerInputFrame> getRecordedFrames()
    {
        return recordedFrames;
    }

    public void StartNewRun()
    {
        boss.transform.position = enemySpawnPoint.position;
        boss.GetComponent<Health>().Heal(100);
        boss.SetActive(true);

    }

}
