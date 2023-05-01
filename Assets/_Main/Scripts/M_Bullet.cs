using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class M_Bullet : MonoBehaviour
{
    public float moveSpeed;
    protected Rigidbody rb;
    protected Vector3 direction;
    protected LayerMask layer_Environment;
    public LineRenderer lr;

    public void Initialize_Bullet()
    {
        //设置初始射击方向
        direction = transform.forward;
        //添加刚体组件
        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.constraints = RigidbodyConstraints.FreezePositionY;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        //设置碰撞的环境Layer
        layer_Environment = LayerMask.NameToLayer("Environment");
    }

    public void OnHitWallReflectBullet(Collision collision)
    {
        //当与Layer为Environment的物体碰撞时，弹射自身
        if (collision.gameObject.layer == layer_Environment)
        {
            rb.velocity = Vector3.zero;
            direction = Vector3.Reflect(direction, collision.contacts[0].normal).normalized;
            direction = new Vector3(direction.x, 0, direction.z);
            transform.forward = direction;
        }
    }

    protected void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.red);
    }
}
