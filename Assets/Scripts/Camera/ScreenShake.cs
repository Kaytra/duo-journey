﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public static ScreenShake instance;

    private float shakeTimeRemaining, shakePower, shakeFadeTime, shakeRotation;

    public float rotationMultiplier = 15f;

     void Start()
    {
        instance = this;
    }
    //public IEnumerator Shake (float duration, float strength)
    //{
    //Vector3 originalPos = transform.localPosition;

    //float elapsed = 0.0f;

    //while(elapsed < duration)
    //{
    //float x = Random.Range(-1f, 1f) * strength;
    //float y = Random.Range(-1f, 1f) * strength;

    //transform.localPosition = new Vector3(x, y, originalPos.z);

    //elapsed += Time.deltaTime;

    //yield return null;
    //}

    //transform.localPosition = originalPos;
    // }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            StartShake(.5f, 1f); 
        }
    }

    private void LateUpdate()
    {
        if (shakeTimeRemaining > 0)
        {

            shakeTimeRemaining -= Time.deltaTime;

            float xAmount = Random.Range(-1f, 1f) * shakePower;
            float yAmount = Random.Range(-1f, 1f) * shakePower;

            transform.position += new Vector3(xAmount, yAmount, 0f);

            shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFadeTime * Time.deltaTime);

            shakeRotation = Mathf.MoveTowards(shakeRotation, 0f, shakeFadeTime * rotationMultiplier * Time.deltaTime);
        }

        transform.rotation = Quaternion.Euler(0f, 0f, shakeRotation * Random.Range(-1f, 1f));
    }
    public void StartShake(float length, float power)
    {
        shakeTimeRemaining = length;
        shakePower = power;

        shakeFadeTime = power / length;

        shakeRotation = power * rotationMultiplier;
    }
}
