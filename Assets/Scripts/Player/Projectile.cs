using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed;
    private Vector2 direction;
    private float damage = 20;
    private float lifeTime = 2f;

    public void Init(float speed, Vector2 direction, float damage, float lifeTime)
    {
        this.speed = speed;
        this.direction = direction;
        this.damage = damage;
        this.lifeTime = lifeTime;
    }

    private void Update()
    {
        transform.position += speed * Time.deltaTime * (Vector3)direction;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Health>() != null)
        {
            Destroy(gameObject);
        }
    }
}
