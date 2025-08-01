using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private Transform body;
    private Vector2 rotationDir;
    public Vector2 inputDirection;
    public Vector3 mousePos;

    
    public void Move(Vector2 inputDirection)
    {
        transform.Translate(inputDirection * speed * Time.deltaTime);
    }
    
    public void RotateToMousePos(Vector3 mousePos)
    {

        rotationDir = (mousePos - transform.position).normalized;
       
        float angle = Mathf.Atan2(rotationDir.y, rotationDir.x) * Mathf.Rad2Deg;
       
        body.rotation = Quaternion.Euler(0f, 0f, angle + 180);
    }

    public Vector2 GetBarrelDirection()
    {
        return rotationDir;
    }

    private static void PlayerMousePos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
    }
}
