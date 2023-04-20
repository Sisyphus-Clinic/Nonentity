using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_B_Enemy : M_Bullet
{
    void Start()
    {
        Initialize_Bullet();
    }

    void FixedUpdate()
    {
        rb.velocity = direction * moveSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnHitWallReflectBullet(collision);
        if (collision.gameObject.tag == "Player")
        {
            transform.rotation = Quaternion.Euler(90, transform.rotation.y, 0);
            direction = Vector3.up;
            moveSpeed = 5;
            GetComponent<CapsuleCollider>().isTrigger = true;
        }
    }
}
