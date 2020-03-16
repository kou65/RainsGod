using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mochaController : MonoBehaviour
{
    public GameObject planet;
    public bool hasRain = false;

    public Attribute attribute_state = Attribute.ETC;

    void Start()
    {
        this.planet = GameObject.Find("en");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 axis = new Vector3(0, 0, 1);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(planet.transform.position, axis, gameData.MAP_SPEED);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(planet.transform.position, axis, -gameData.MAP_SPEED);
        }

    }


    private void OnTriggerStay2D(Collider2D collision_)
    {
        if (collision_.tag == "grass")
        {
            attribute_state = Attribute.GRASS;
        } 
        if (collision_.tag == "solid")
        {
            attribute_state = Attribute.SOLID;
        } 
    }

    public void ChangeHasRain(bool on_)
    {
        this.hasRain = on_;
    }

    public Attribute CurrAttributeState()
    {
        return attribute_state;
    }

}
