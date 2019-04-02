using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PermissionManager :  MonoBehaviour
{
    void Update()
    {
        RequestPermissionSMS();
        RequestPermissionCall();
    }

    public void RequestPermissionSMS()
    {
        if (UniAndroidPermission.IsPermitted (AndroidPermission.SEND_SMS)) 
        {
            return;
        }

        UniAndroidPermission.RequestPermission(AndroidPermission.SEND_SMS);
    }

    public void RequestPermissionCall()
    {
        if (UniAndroidPermission.IsPermitted (AndroidPermission.CALL_PHONE)) 
        {
            return;
        }

        UniAndroidPermission.RequestPermission(AndroidPermission.CALL_PHONE);
    }
}
