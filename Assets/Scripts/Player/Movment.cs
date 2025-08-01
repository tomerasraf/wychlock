using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private Transform body;
    private Vector2 rotationDir = Vector2.zero;
    private Vector2 inputDirection = Vector2.zero;


    void playerMovement()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        
        inputDirection = new Vector2(xAxis, yAxis).normalized;
        
        transform.Translate(inputDirection * speed * Time.deltaTime);
    }

    void PlayerRotation()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        
        Vector2 direction = (mousePos - transform.position).normalized;
       
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
       
        body.rotation = Quaternion.Euler(0f, 0f, angle + 180);
    }

    public Vector2 GetBulletDirection()
    {
        return rotationDir;
    }
    
    private void Update()
    {
        playerMovement();
        PlayerRotation();
    }
}
