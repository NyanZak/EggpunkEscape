using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public GameObject egg;
    public Transform start;


    private void Update()
    {
        Vector3 eggPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (eggPos.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
        }
        else
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Throwing();
        }
    }


    void Throwing()
    {
        GameObject throwEgg = Instantiate(egg, start.transform.position, start.transform.rotation);
        Destroy(throwEgg, .5f);
    }
}
