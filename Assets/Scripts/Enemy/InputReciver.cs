using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class InputReciver : MonoBehaviour
{
    private List<PlayerInputFrame> recordedFrames = new List<PlayerInputFrame>();
    int currentFrame = 0;
    private Movment movment;
    private Weapon weapon;
    public bool isPlaying = false;
    public bool isResetting = false;

    void ReciveRecording()
    {
        recordedFrames = GameManager.Instance.getRecordedFrames();
        currentFrame = 0; 
    }

    void PlayRecordedFrame()
    {
        if (!isPlaying || recordedFrames == null || recordedFrames.Count == 0
            || isResetting)
            return;

        if (currentFrame < recordedFrames.Count)
        {
            var frame = recordedFrames[currentFrame];

            movment.RotateToMousePos(frame.mousePos);
            movment.Move(frame.moveDir);
            if (frame.shoot)
                weapon.Shoot();

            currentFrame++;
        }
        else
        {
            isResetting = true;

            transform.DOMove(GameManager.Instance.GetBossSpawnPoint().position, 0.5f).OnComplete(() =>
            {
                currentFrame = 0;
                isResetting = false ;
            });
        }
    }

    void Start()
    {           
        movment = GetComponent<Movment>();
        weapon = GetComponent<Weapon>();
    }

    private void OnEnable()
    {
        ReciveRecording();
        isPlaying = true;
        isResetting = false;
    }

    private void Update()
    {
        PlayRecordedFrame();
    }
}