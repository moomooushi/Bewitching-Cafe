using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantTilting : MonoBehaviour
{
    public bool rotateRight;
    public float timer;
    void Update()
    {
        timer -= 1 * Time.deltaTime;
        if (timer >= 8)
        {
            rotateRight = true;
        }
        if (timer <= 8)
        {
            rotateRight = false;
        if (timer <= 0)
        {
            timer = 16;
        }
        }
        if (rotateRight == true)
        {
            transform.localRotation = Quaternion.Euler(0, 0, transform.eulerAngles.z - 2 * Time.deltaTime);
        }
        if (rotateRight == false)
        {
            transform.localRotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + 2 * Time.deltaTime);
        }
    }
}
