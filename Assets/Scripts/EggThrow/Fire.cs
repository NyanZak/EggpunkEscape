using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float throwSpeed;


    private void Update()
    {
        transform.Translate(Vector2.right * throwSpeed * Time.deltaTime, Space.Self);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, .5f);
    }
}
