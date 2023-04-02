using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAnim : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] AudioSource boing;
    private float coolDown;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && coolDown <= 0)
        {
            coolDown = 1;
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100);
            if (hit && hit.transform.name.Contains("Slime"))
            {
                _animator.Play("Slime");
                boing.Play();
            }
        }
        if (coolDown > -1)
        {
            coolDown -= 1 * Time.deltaTime;
        }
    }
}
