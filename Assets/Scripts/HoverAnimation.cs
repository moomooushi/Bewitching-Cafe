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
    [SerializeField] LayerMask sparkleLayers;



    void OnMouseEnter()
    {//sparklesmanager make script like miningmanager
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100, sparkleLayers);
        if (hit)
        {
            scaleUp = true;
            //sparkleAudio.Play();
            transform.GetChild(0).gameObject.SetActive(true);
            hasStarted = true;
        }
        else
        {
            print("Barrier");
            scaleUp = true;
            //sparkleAudio.Play();
            transform.GetChild(0).gameObject.SetActive(true);
            hasStarted = true;
        }
    }
    void OnMouseExit()
    {
        if (name == "Barrier")
        {
            print("Barrier");
        }
        else
        {
            //sparkleAudio.Stop();
            transform.GetChild(0).gameObject.SetActive(false);
            scaleUp = false;
        }
    }
    private void Update()
    {
        if(scaleUp == true && transform.localScale.x < (x + maxSize))
        {
            transform.localScale = new Vector2(transform.localScale.x + rate * Time.deltaTime, transform.localScale.y + rate * Time.deltaTime) ;
        }
        else if (scaleUp == false && transform.localScale.x > (x) && hasStarted == true)
        {
            transform.localScale = new Vector2(transform.localScale.x - rate * Time.deltaTime, transform.localScale.y - rate * Time.deltaTime);
        }
    }
}
