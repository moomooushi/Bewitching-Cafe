using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteButton : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject generalManager;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100);
            if (hit && hit.transform.name.Contains(gameObject.name))
            {
                panel.SetActive(true);
                generalManager.GetComponent<Tutorial>().NextStage();
            }
        }
    }
}
