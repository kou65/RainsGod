using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class pirceBase : MonoBehaviour
{
    
    public Attribute land_attribute = Attribute.GRASS;
    public Building land_building = Building.NONE;
    public Status land_status = Status.NONE;
    public int land_water = 100;
    public bool reverse = false;

    float span = 1.0f;
    float delta = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.land_status == Status.WET)
        {
            Wet();
        }
        else
        {
            Wither();
        }
    }

    public void Wet()
    {
        delta += Time.deltaTime;

        if (delta > span)
        {
            delta = 0;

            if (this.land_water < 100)
            {
                this.land_water++;
            }

        }
    }

    public void Wither()
    {

        delta += Time.deltaTime;

        if (delta > span)
        {
            delta = 0;

            if(this.land_water > 0)
            {
                this.land_water--;
            }

        }
    }

    public bool GetReverse()
    {
        return reverse;
    }
}
