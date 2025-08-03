using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed;
    private Vector2 direction;
    private int damage = 20;
    private float lifeTime = 2f;
    private Sprite sprite;

    private SpriteRenderer spriteRenderer;

    private float lifeTimer = 0;
    
    private GameObject shooter;

    public void Init(float speed, Vector2 direction, int damage, float lifeTime, GameObject shooter)
    {
        this.speed = speed;
        this.direction = direction;
        this.damage = damage;
        this.lifeTime = lifeTime;
        this.shooter = shooter;

        UpdateRotation();

    }
    private void OnEnable()
    {
        lifeTimer = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        lifeTimer += Time.deltaTime;
        if (lifeTimer < lifeTime)
        {
            transform.position += speed * Time.deltaTime * (Vector3)direction;
            return;
        }
        Destroy(gameObject);
    }
    private void UpdateRotation()
    {
        // Check to avoid errors if direction is zero
        if (direction != Vector2.zero)
        {
            // Calculate the angle in degrees
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            // Set the rotation of the projectile's transform
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
    public void ChangeDirectionWAllBounce(bool isSideWall)
    {
        if (isSideWall)
        {
            direction.x *= -1;
        }
        else
        {
            direction.y *= -1;
        }
        UpdateRotation();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject == shooter)
            return;
        
        Health health = other.GetComponent<Health>();
                
        if (health != null)
        {
            health.Damage(damage);
            Destroy(gameObject);
        }
    }
}
