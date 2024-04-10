using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrolling_background : MonoBehaviour
{
    [SerializeField] float backgroundScrollSpeed = 0.5f;
    Material myMaterial;
    Vector2 offsetX;

    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        offsetX = new Vector2(backgroundScrollSpeed, 0f);
        
    }


    void Update()
    {
        myMaterial.mainTextureOffset += offsetX * Time.deltaTime;
    }
}
