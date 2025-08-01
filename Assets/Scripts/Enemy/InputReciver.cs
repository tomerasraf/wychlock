using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReciver : MonoBehaviour
{
    private List<PlayerInputFrame> recordedFrames = new List<PlayerInputFrame>();
    int currentFrame = 0;
    private Movment movment;
    private Weapon weapon;

    void ReciveRecording()
    {
        recordedFrames = GameManager.Instance.getRecordedFrames();
    }

    void PlayRecordedFrame()
    {
        for (int i = 0; i < recordedFrames.Count; i++)
        {
            if (currentFrame < recordedFrames.Count)
            {
                movment.RotateToMousePos(recordedFrames[i].mousePos);
                movment.Move(recordedFrames[i].moveDir);
                if (recordedFrames[i].shoot)
                {
                    weapon.Shoot();
                }

                currentFrame++;
            }
        }
    }

    IEnumerator Start()
    {
        ReciveRecording();
        movment = GetComponent<Movment>();
        weapon = GetComponent<Weapon>();

        yield return new WaitForSeconds(1f);
        PlayRecordedFrame();
    }
}