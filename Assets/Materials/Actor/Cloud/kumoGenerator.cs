using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kumoGenerator : MonoBehaviour
{
    public GameObject cloud;
    public GameObject planet;


    // Start is called before the first frame update
    void Start()
    {
        this.planet = GameObject.Find("en");

        GameObject[] clouds = new GameObject[20];


        for (int i = 0; i < 20; i++)
        {
            clouds[i] = Instantiate(cloud) as GameObject;
        }

        const int DEGREE = 18;

        Vector3 axis = new Vector3(0, 0, 1);


        for (int i = 0; i < 20; i++)
        {
            float random = Random.Range(-2.0f, 2.0f);
            clouds[i].transform.Translate(random,random,0);

            clouds[i].transform.RotateAround(planet.transform.position, axis, DEGREE * i);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
