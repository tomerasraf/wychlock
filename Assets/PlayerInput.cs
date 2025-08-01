using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Movment movement;

    private void Start()
    {
        movement = GetComponent<Movment>();    
    }
    private void Update()
    {
        movement.RotateToMousePos(PlayerMousePos());
        movement.Move(PlayerMovement());
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement.Dash(PlayerMovement());
        }
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
}
