﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;

    private void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);


            //reference applepicker
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            //call public appledestoryed method
            apScript.AppleDestroyed();
        }
    }
}