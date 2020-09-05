using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoVirusSplitter : MonoBehaviour
{
    public bool splitTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (splitTrigger)
        {
            splitTrigger = false;
            Slicer.SplitMesh(gameObject, transform);
        }
    }
}
