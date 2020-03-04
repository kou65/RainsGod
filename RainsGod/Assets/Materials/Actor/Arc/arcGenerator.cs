using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static pirceBase;

public class arcGenerator : MonoBehaviour
{
    
    public GameObject grass_solidPrefab;
    public GameObject solid_grassPrefab;
    public GameObject grassPrefab;
    public GameObject solidPrefab;

    public GameObject[] arc_slot = new GameObject[4];
    public GameObject[] arc_base = new GameObject[4];
     

    public bool[] Reverse = { false, false, false, false };

    // Start is called before the first frame update
    void Start()
    {

        int randam_generate = 0;
        randam_generate = Random.Range(0,(int)Attribute.ETC);

        this.arc_base[0] = GameObject.Find("base_arc1");
        this.arc_base[1] = GameObject.Find("base_arc2");
        this.arc_base[2] = GameObject.Find("base_arc3");
        this.arc_base[3] = GameObject.Find("base_arc4");

        for (int i = 0; i < 4; i++)
        {
            if (arc_base[i].GetComponent<pirceBase>().land_attribute == Attribute.GRASS)
            {
                arc_slot[i] = Instantiate(grassPrefab) as GameObject;
            }
        }



        //arc_slot[0] = Instantiate(grassPrefab) as GameObject;
        //arc_slot[1] = Instantiate(solidPrefab) as GameObject;
        //arc_slot[2] = Instantiate(solid_grassPrefab) as GameObject;
        //arc_slot[3] = Instantiate(grass_solidPrefab) as GameObject;



        //arc_slot[0].transform.Rotate(0, 0, 0);
        //arc_slot[1].transform.Rotate(0, 0, 90);
        //arc_slot[2].transform.Rotate(0, 0, 180);
        //arc_slot[3].transform.Rotate(0, 0, 270);


    }


    // Update is called once per frame
    void Update()
    {
        arc_slot[0].transform.rotation = arc_base[0].transform.rotation;
        arc_slot[1].transform.rotation = arc_base[1].transform.rotation;
        arc_slot[2].transform.rotation = arc_base[2].transform.rotation;
        arc_slot[3].transform.rotation = arc_base[3].transform.rotation;
    }
}
