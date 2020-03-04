using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public GameObject[] arc_base = new GameObject[4];

    public GameObject camera_controller;
    public GameObject planet;


    // Start is called before the first frame update
    void Start()
    {
        camera_controller = GameObject.Find("Main Camera");
        planet = GameObject.Find("en");
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 axis = new Vector3(0, 0, 1);

        transform.RotateAround(planet.transform.position, axis, gameData.speed);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        

        GameObject mocha = GameObject.Find("mocha");


        if (collision.tag == "mocha")
        {
            mocha.GetComponent<mochaController>().ChangeHasRain(true);
        }
        if (collision.tag == "base_arc1")
        {
            arc_base[0].GetComponent<pirceBase>().land_status = Status.WET;
        }

        if (collision.tag == "base_arc2")
        {
            arc_base[1].GetComponent<pirceBase>().land_status = Status.WET;
        }

        if (collision.tag == "base_arc3")
        {
            arc_base[2].GetComponent<pirceBase>().land_status = Status.WET;
        }

        if (collision.tag == "base_arc4")
        {
            arc_base[3].GetComponent<pirceBase>().land_status = Status.WET;
        }


    }

    private void OnTriggerExit2D(Collider2D collision_)
    {
        GameObject mocha = GameObject.Find("mocha");
        GameObject grass = GameObject.Find("green_arcPrefab(Clone)");
        GameObject solid = GameObject.Find("red_arcPrefab(Clone)");

        if (collision_.tag == "mocha")
        {
            mocha.GetComponent<mochaController>().ChangeHasRain(false);
            Debug.Log("雨が当たってません");

        }
        if (collision_.tag == "base_arc1")
        {
            arc_base[0].GetComponent<pirceBase>().land_status = Status.PEACE;
        }

        if (collision_.tag == "base_arc2")
        {
            arc_base[1].GetComponent<pirceBase>().land_status = Status.PEACE;
        }

        if (collision_.tag == "base_arc3")
        {
            arc_base[2].GetComponent<pirceBase>().land_status = Status.PEACE;
        }

        if (collision_.tag == "base_arc4")
        {
            arc_base[3].GetComponent<pirceBase>().land_status = Status.PEACE;
        }
    }

}
