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
        DrawPredictionTrajectory();
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

    private void DrawPredictionTrajectory()
    {
        List<Vector3> linePositions = GetHitPoints();

        lr.positionCount = linePositions.Count;
        for (int i = 0; i < linePositions.Count; i++)
        {
            lr.SetPosition(i, linePositions[i]);
        }
    }

    private List<Vector3> GetHitPoints()
    {
        RaycastHit hit;
        int hitPointCount = 0;
        Vector3 start = transform.position;
        Vector3 direction = transform.TransformDirection(Vector3.forward);
        List<Vector3> linePositions = new List<Vector3>();
        linePositions.Add(start);

        for (int i = 0; i < 10; i++)
        {
            if (Physics.Raycast(start, direction, out hit, Mathf.Infinity, 1 << layer_Environment | 1 << LayerMask.NameToLayer("Bound")))
                if (hit.collider.gameObject.layer == layer_Environment)
                {
                    linePositions.Add(hit.point);
                    start = hit.point;
                    direction = Vector3.Reflect(direction, hit.normal).normalized;
                    direction = new Vector3(direction.x, 0, direction.z);
                    hitPointCount++;
                }
                else
                {
                    linePositions.Add(hit.point);
                    break;
                }
        }
        return linePositions;
    }
}
