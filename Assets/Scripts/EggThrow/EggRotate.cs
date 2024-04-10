using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EggRotate : MonoBehaviour
{
    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 eggPosition = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - eggPosition.x;
        mousePos.y = mousePos.y - eggPosition.y;

        float eggAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(new Vector3(180f, 0f, -eggAngle));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, eggAngle));
        }

    }
}