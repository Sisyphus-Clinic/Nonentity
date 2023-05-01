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
        //���ó�ʼ�������
        direction = transform.forward;
        //��Ӹ������
        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.constraints = RigidbodyConstraints.FreezePositionY;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        //������ײ�Ļ���Layer
        layer_Environment = LayerMask.NameToLayer("Environment");
    }

    public void OnHitWallReflectBullet(Collision collision)
    {
        //����LayerΪEnvironment��������ײʱ����������
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
