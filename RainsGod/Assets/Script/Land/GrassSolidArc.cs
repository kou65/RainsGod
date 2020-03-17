using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSolidArc : pirceBase
{
    // Start is called before the first frame update
    void Start()
    {
        land_attribute = Attribute.GRASS_SOLID;
    }

    // Update is called once per frame
    void Update()
    {
        WitherArc();

        //Destroy();
    }
}
