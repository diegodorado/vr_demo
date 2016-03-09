﻿using UnityEngine;

public class MobileCamera : MonoBehaviour
{
    public float pitchSensitivity = 2f;
    public float yawSensitivity = 4f;

    public float minAccelerationX = -0.5f;
    public float maxAccelerationX = 0.5f;
    public float minAccelerationY = -0.5f;
    public float maxAccelerationY = 0.5f;


    public float pitchAngle;
    public float minPitchAngle = -30f;
    public float maxPitchAngle = 30f;
    public float yawAngle;



    void Update()
    {
        float pitchAdd, yawAdd;

#if UNITY_EDITOR
        pitchAdd = -Input.GetAxis("Mouse Y") * 0.5f;
        yawAdd = -Input.GetAxis("Mouse X") * 0.5f;
#endif
#if !UNITY_EDITOR && UNITY_ANDROID
        pitchAdd = Mathf.InverseLerp(minAccelerationY, maxAccelerationY, Input.acceleration.y) - 0.5f; // inverse lerp midpoint
        yawAdd = Mathf.InverseLerp(minAccelerationX, maxAccelerationX, Input.acceleration.x) - 0.5f; // inverse lerp midpoint
#endif

        pitchAngle += pitchAdd * pitchSensitivity;
        pitchAngle = Mathf.Clamp(pitchAngle, minPitchAngle, maxPitchAngle);

        yawAngle -= yawAdd * yawSensitivity;

        transform.localRotation = Quaternion.Euler(pitchAngle, yawAngle, 0);
    }


}