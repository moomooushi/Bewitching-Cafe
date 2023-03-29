using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverAnimation : MonoBehaviour
{
    [SerializeField] AudioSource sparkleAudio;
    [SerializeField] bool scaleUp;
    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] float rate;
    [SerializeField] bool hasStarted;//fix it starting small bug
    [SerializeField] float maxSize;

    void OnMouseEnter()
    {
        scaleUp = true;
        sparkleAudio.Play();
        transform.GetChild(0).gameObject.SetActive(true);
        hasStarted = true;
    }
    void OnMouseExit()
    {
        sparkleAudio.Stop();
        transform.GetChild(0).gameObject.SetActive(false);
        scaleUp = false;
    }
    private void Update()
    {
        if(scaleUp == true && transform.localScale.x < (x + maxSize))
        {
            transform.localScale = new Vector2(transform.localScale.x + rate * Time.deltaTime, transform.localScale.y + rate * Time.deltaTime) ;
        }
        else if (scaleUp == false && transform.localScale.x > (x - maxSize) && hasStarted == true)
        {
            transform.localScale = new Vector2(transform.localScale.x - rate * Time.deltaTime, transform.localScale.y - rate * Time.deltaTime);
        }
    }
}
