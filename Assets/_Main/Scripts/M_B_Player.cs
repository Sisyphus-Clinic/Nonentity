using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MoreMountains.Feedbacks;

public class M_B_Player : M_Bullet
{
    private float decelerateRate;
    public float turnRatio;
    private bool isSlowMotion = false;
    public Transform panelTranse;

    public MMFeedback hitfeedback;

    void Start()
    {
        Initialize_Bullet();
        SetLineState(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = isSlowMotion ? 1f : 0.1f;
            isSlowMotion = !isSlowMotion;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            panelTranse.DOScale(1, 0.4f);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = direction * moveSpeed * decelerateRate;
        float directionInterfere = Input.GetAxisRaw("Horizontal");



        if (directionInterfere != 0)
        {
            if (directionInterfere > 0) transform.Rotate(transform.up, turnRatio);
            else transform.Rotate(transform.up, -turnRatio);
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
        OnHitWallReflectBullet(collision);
        //hitfeedback.FeedbackPlaying = true;
    }

    private void EnterDrawBulletCurve()
    {
        decelerateRate = 0.1f;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity,1<< layer_Environment))
        {
            Debug.Log("asdasdasdas");
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
