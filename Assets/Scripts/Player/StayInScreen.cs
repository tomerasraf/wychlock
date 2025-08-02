using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInScreen : MonoBehaviour
{
    [SerializeField] float x_limit;
    [SerializeField] float minx_limit;

    [SerializeField] float y_limit;
    private void Update()
    {
        if (transform.position.x > x_limit)
            transform.position = new Vector3(Mathf.Sign(transform.position.x) * x_limit, transform.position.y);
        if (transform.position.x < minx_limit)
            transform.position = new Vector3(minx_limit, transform.position.y);
        if (Mathf.Abs(transform.position.y) > y_limit)
            transform.position = new Vector3(transform.position.x, Mathf.Sign(transform.position.y) * y_limit);
    }
}
