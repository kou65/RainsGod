using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassArc : pirceBase
{

    // Start is called before the first frame update
    void Start()
    {

        land_attribute = Attribute.GRASS;
    }

    // Update is called once per frame
    void Update()
    {
        WitherArc();

        //Destroy();
    }
}
