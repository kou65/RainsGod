using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kumoController : MonoBehaviour
{
    public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        Vector3 axis = new Vector3(0,0,1);

        parent = transform.root.gameObject;


        transform.RotateAround(parent.transform.position, axis, gameData.MAP_SPEED * Time.deltaTime);


    }

     void Destroy()
     {
        Destroy(this.gameObject);
     }
}
