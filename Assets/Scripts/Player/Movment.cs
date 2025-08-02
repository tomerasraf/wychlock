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

    [SerializeField] private float dashMult = 2f;
    [SerializeField] private float timeOfdash = 2f;
    bool canDash = true;



    public void Move(Vector2 inputDirection)
    {
        transform.Translate(inputDirection * speed * Time.deltaTime);
    }

    public void Dash(Vector2 inputDirection)
    {
        if (inputDirection != Vector2.zero && canDash)
        {
            canDash = false;
            StartCoroutine(DashSeq(inputDirection));
        }
    }

    IEnumerator DashSeq(Vector2 inputDirection)
    {
        float timer = 0f;

        while (timer < timeOfdash)
        {
            transform.Translate(inputDirection * speed * dashMult * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }

        
        canDash = true;
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
