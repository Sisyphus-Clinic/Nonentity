using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using System;

public class M_SlowMotion : Singleton<M_SlowMotion>
{
    public float slowMotionScale;
    private bool isSlowMotion = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isSlowMotion) M_Delegator.Instance.EnterSlowMotion();
        }
    }

    public void TimeScaleEnterSlowMotion()
    {
        Time.timeScale = slowMotionScale;
        isSlowMotion = true;
    }

    public void TimeScaleExitSlowMotion()
    {
        Time.timeScale = 1f;
        isSlowMotion = false;
    }
}
