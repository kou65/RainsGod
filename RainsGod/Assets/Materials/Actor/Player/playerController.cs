using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    GameObject arc_obj = GameObject.Find("ArcGenerator");
    public GameObject[] arc_base = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
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
