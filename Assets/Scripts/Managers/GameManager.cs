using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        boss.GetComponent<Health>().ResetHealth();
        boss.SetActive(true);
       
    }
    
}
