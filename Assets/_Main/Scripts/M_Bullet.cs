using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class M_Bullet : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody rb;
    public LineRenderer lr;
    private Vector3 direction;
    public LayerMask environmentLayer;
    private float decelerateRate;
    public TMPro.TMP_Text t_Score;
    private int score = 0;
    public float turnRatio;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        direction = transform.forward;
        SetLineState(false);
        t_Score.text = score.ToString();
    }

    void FixedUpdate()
    {
        rb.velocity = direction * moveSpeed * decelerateRate;
        float directionInterfere = Input.GetAxisRaw("Horizontal");

        if (directionInterfere != 0)
        {
            if (directionInterfere > 0)
            {
                transform.Rotate(transform.up, turnRatio);
            
            }
            else
            {
                transform.Rotate(transform.up, -turnRatio);
            }
            direction = transform.forward;
            EnterDrawBulletCurve();
        }
        else
        {
            ExitDrawCurveMode();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            rb.velocity = Vector3.zero;
            direction = Vector3.Reflect(direction, collision.contacts[0].normal).normalized;
            direction = new Vector3(direction.x, 0, direction.z);
            transform.forward = direction;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Danger"))
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            Destroy(other.gameObject);
            score++;
            t_Score.text = score.ToString();
        }

    }

    private void EnterDrawBulletCurve()
    {
        decelerateRate = 0.1f;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, environmentLayer))
        {
            SetLineState(true);
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, hit.point);
        }
    }

    private void ExitDrawCurveMode()
    {
        decelerateRate = 1;
        SetLineState(false);
    }

    private void SetLineState(bool targetState)
    {
        lr.enabled = targetState;
    }
}
