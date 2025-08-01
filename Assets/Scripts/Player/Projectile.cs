using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed;
    private Vector2 direction = Vector2.zero;
    private float damage = 20;
    private float lifeTime = 2f;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Health>() != null)
        {
            Destroy(gameObject);
        }
    }
}
