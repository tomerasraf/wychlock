using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    private Vector2 direction = Vector2.zero;


    private void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        
        direction = new Vector2(xAxis, yAxis).normalized;
        
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
