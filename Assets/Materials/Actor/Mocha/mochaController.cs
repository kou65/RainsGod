using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mochaController : MonoBehaviour
{
    public GameObject planet;
    public bool hasRain = false;

    void Start()
    {
        this.planet = GameObject.Find("en");
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void ChangeHasRain(bool on_)
    {
        this.hasRain = on_;
    }

}
