using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mochaController : MonoBehaviour
{
    public GameObject planet;
    GameObject map_controller;
    public bool hasRain = false;

    // Start is called before the first frame update
    void Start()
    {
        this.planet = GameObject.Find("en");
        this.map_controller = GameObject.Find("baseController");
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 axis = new Vector3(0, 0, 1);

        //transform.RotateAround(planet.transform.position, axis, gameData.MAP_SPEED * Time.deltaTime);


        transform.RotateAround(planet.transform.position, axis, this.map_controller.GetComponent<baseController>().speed);


    }

    public void ChangeHasRain(bool on_)
    {
        this.hasRain = on_;
    }

}
