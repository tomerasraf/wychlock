using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<PlayerInputFrame> recordedFrames = new List<PlayerInputFrame>();
    public static GameManager Instance;

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
    
}
