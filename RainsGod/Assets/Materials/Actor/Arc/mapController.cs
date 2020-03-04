using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mapController : MonoBehaviour
{
    public GameObject base_controller;

    // Start is called before the first frame update
    void Start()
    {
        base_controller = GameObject.Find("baseController");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 0, base_controller.GetComponent<baseController>().speed);
    }
}
