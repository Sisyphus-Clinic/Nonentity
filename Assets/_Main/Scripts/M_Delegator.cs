using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class M_Delegator : Singleton<M_Delegator>
{
    public Action EnterSlowMotion;
    public Action ExitSlowMotion;

    void Start()
    {
        EnterSlowMotion += M_SlowMotion.Instance.TimeScaleEnterSlowMotion;
        EnterSlowMotion += M_MMFCollection.Instance.mmf_EnterSlowMotion.PlayFeedbacks;
        EnterSlowMotion += FindObjectOfType<M_B_Player>().EnterSlowMotionState;

        ExitSlowMotion += M_SlowMotion.Instance.TimeScaleExitSlowMotion;
        ExitSlowMotion += M_MMFCollection.Instance.mmf_ExitSlowMotion.PlayFeedbacks;
        ExitSlowMotion += FindObjectOfType<M_B_Player>().ExitSlowMotionState;
    }

    void Update()
    {
    
    }
}
