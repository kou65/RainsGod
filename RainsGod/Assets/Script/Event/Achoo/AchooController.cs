using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchooController : MonoBehaviour
{


    float update_scale = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
        Vector3 scale = new Vector3(update_scale,update_scale,update_scale);

        this.transform.localScale = scale;

        update_scale += 0.03f;

        if (update_scale > 1.0f)
        {
            update_scale = 1.0f;
        }
    }
}
