using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InputReciver : MonoBehaviour
{
    private List<PlayerInputFrame> recordedFrames = new List<PlayerInputFrame>();
    int currentFrame = 0;
    private Movment movment;
    private Weapon weapon;
    private bool isPlaying = false;
    void ReciveRecording()
    {
        recordedFrames = GameManager.Instance.getRecordedFrames();
        currentFrame = 0; 
    }

    void PlayRecordedFrame()
    {
        if (!isPlaying || recordedFrames == null || recordedFrames.Count == 0)
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
            transform.DOMove(GameManager.Instance.GetBossSpawnPoint().position, 0.5f).OnComplete(() =>
            {
                currentFrame = 0;
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
    }

    private void Update()
    {
        PlayRecordedFrame();
    }
}