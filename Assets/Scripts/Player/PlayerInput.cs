using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PlayerInputFrame
{
    public Vector2 moveDir;
    public Vector2 mousePos;
    public bool shoot;
    public bool dash;
}

public class PlayerInput : MonoBehaviour
{
    private List<PlayerInputFrame> recordedFrames = new List<PlayerInputFrame>();
    [SerializeField] private InputReciver enemyReciver;

    private Movment movement;
    private Weapon weapon;
    private PlayerInputFrame currentFrame;

    private void Start()
    {
        currentFrame = new PlayerInputFrame();
        movement = GetComponent<Movment>();
        weapon = GetComponent<Weapon>();
        Health.playerDeath += decideRecording;
    }
    private void Update()
    {
        movement.RotateToMousePos(PlayerMousePos());
        movement.Move(PlayerMovement());
        
        if (Input.GetMouseButtonDown(0))
        {
            weapon.Shoot();
        }
        RecordFrames();

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movement.Dash(PlayerMovement());
        }
    }

    void RecordFrames()
    {
        currentFrame.moveDir = PlayerMovement();
        currentFrame.moveDir.x *= -1;
        currentFrame.mousePos = PlayerMousePos();
        currentFrame.mousePos .x *= -1;
        currentFrame.shoot = Input.GetMouseButtonDown(0);
        recordedFrames.Add(currentFrame);
    }
    
    private static Vector3 PlayerMousePos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        return mousePos;
    }
    private static Vector2 PlayerMovement()
    {
        Vector2 inputDirection;
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        inputDirection = new Vector2(xAxis, yAxis).normalized;
        return inputDirection;
    }

    void decideRecording(bool isPlayer)
    { 
        if (isPlayer)
        {
            recordedFrames.Clear();
        }
        else
        {
            GameManager.Instance.setRecordedFrames(recordedFrames);
            enemyReciver.gameObject.SetActive(false);
            GameManager.Instance.StartNewRun();
        }
    }
    public List<PlayerInputFrame> GetInputFrameRecord()
    {
        return recordedFrames;
    }
}
