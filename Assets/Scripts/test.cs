using System.Collections;
using System.Collections.Generic;
using DanielLochner.Assets.SimpleScrollSnap;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<DynamicContentController>().AddToFront();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
