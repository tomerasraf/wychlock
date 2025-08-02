using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject wallhit_VFX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Projectile>() != null)
        {
            StartCoroutine(WallHit_VFX(collision));
            Destroy(collision.gameObject);
        }
    }

    IEnumerator WallHit_VFX(Collider2D collision)
    {
        wallhit_VFX.SetActive(true);
        wallhit_VFX.transform.position = collision.transform.position;

        yield return new WaitForSeconds(.3f);
        wallhit_VFX.SetActive(false);
    }
}
