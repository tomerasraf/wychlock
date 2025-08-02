using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject wallhit_VFX;

    public bool isSideWall;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.TryGetComponent<Projectile>(out Projectile projectile);
        if (projectile != null)
        {
            projectile.ChangeDirectionWAllBounce(isSideWall);
            StartCoroutine(WallHit_VFX(collision));
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
