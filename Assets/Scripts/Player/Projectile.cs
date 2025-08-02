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

    public void Init(float speed, Vector2 direction, int damage, float lifeTime, Sprite sprite)
    {
        this.speed = speed;
        this.direction = direction;
        this.damage = damage;
        this.lifeTime = lifeTime;
        this.sprite = sprite;
    }
    private void OnEnable()
    {
        lifeTimer = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
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

    public void ChangeDirectionWAllBounce(WallSide wallThatProjectileHit)
    {
        switch (wallThatProjectileHit)
        {
            case WallSide.Left:
                direction.x *= -1;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Health health = other.GetComponent<Health>();
                
        if (health != null)
        {
            health.Damage(damage);
            Destroy(gameObject);
        }
    }
}
