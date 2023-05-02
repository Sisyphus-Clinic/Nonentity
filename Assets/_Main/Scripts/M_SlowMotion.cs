using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using System;

public class M_SlowMotion : MonoBehaviour
{
    public float slowMotionScale;
    private bool isSlowMotion = false;
    public Action EnterSlowMotion;
    public Action ExitSlowMotion;
    public MMF_Player mmf_EnterSM;
    public MMF_Player mmf_ExitSM;

    private void Start()
    {
        EnterSlowMotion += TimeScaleEnterSlowMotion;
        EnterSlowMotion += mmf_EnterSM.PlayFeedbacks;

        ExitSlowMotion += TimeScaleExitSlowMotion;
        ExitSlowMotion += mmf_ExitSM.PlayFeedbacks;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isSlowMotion) EnterSlowMotion();
        }
    }

    void TimeScaleEnterSlowMotion()
    {
        Time.timeScale = slowMotionScale;
        isSlowMotion = true;
    }


    void TimeScaleExitSlowMotion()
    {
        Time.timeScale = 1f;
        isSlowMotion = false;
    }
}
