using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAction : BaseAction
{
    public delegate void SpinCompleteDelegate();

    private float totalSpinAmount;
    private SpinCompleteDelegate onSpinComplete;

    private void Update() 
    {
        if (!isActive)
        {
            return;
        }

        float spinAddAmount = 360f * Time.deltaTime;
        transform.eulerAngles += new Vector3(0f, spinAddAmount, 0f);

        totalSpinAmount += spinAddAmount;

        if (totalSpinAmount >= 360f)
        {
            isActive = false;
            onSpinComplete();
        }
    }

    public void Spin(SpinCompleteDelegate onSpinComplete)
    {
        this.onSpinComplete = onSpinComplete;
        isActive = true;
        totalSpinAmount = 0f;
    }
}