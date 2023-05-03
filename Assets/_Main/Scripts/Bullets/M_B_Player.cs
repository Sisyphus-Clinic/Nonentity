using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class M_B_Player : M_Bullet
{
    public static M_B_Player Instance;
    public float turnRatio;
    private bool isInSlowMotion = false;
    private bool isSMStartInput = false;

    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        EnvironmentHitted += M_MMFCollection.Instance.mmf_BulletHitReflection.PlayFeedbacks;
        Initialize_Bullet();
        SetLineState(false);
    }

    void FixedUpdate()
    {
        rb.velocity = direction * moveSpeed;
        if (isInSlowMotion) TurnBulletInSlowMotion();
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnHitWallReflectBullet(collision);
    }

    private void EnterDrawBulletCurve()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity,1<< layer_Environment))
        {
            SetLineState(true);
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, hit.point);
        }
    }

    private void ExitDrawCurveMode()
    {
        SetLineState(false);
    }

    private void SetLineState(bool targetState)
    {
        lr.enabled = targetState;
    }

    private void TurnBulletInSlowMotion()
    {
        float directionInterfere = Input.GetAxisRaw("Horizontal");
        if (directionInterfere != 0)
        {
            if (directionInterfere > 0) transform.Rotate(transform.up, turnRatio);
            else transform.Rotate(transform.up, -turnRatio);
            direction = transform.forward;
            EnterDrawBulletCurve();
            isSMStartInput = true;
        }

        if (isSMStartInput && directionInterfere == 0)
        {
            M_Delegator.Instance.ExitSlowMotion();
        }
    }

    public void EnterSlowMotionState()
    {
        isInSlowMotion = true;
    }

    public void ExitSlowMotionState()
    {
        ExitDrawCurveMode();
        isInSlowMotion = false;
        isSMStartInput = false;
    }
}
