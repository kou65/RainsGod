using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class himoController : MonoBehaviour
{

    public bool has_event = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DataBank.GetCurrScene() == Scene.TITLE){ return; }


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d)
            {
                if (hit2d.collider.gameObject.CompareTag("himo"))
                {
                    has_event = true;

                }
            }
        }

        if (has_event)
        {
            if (InitEvent.InitPlanet())
            {
                has_event = false;
            }
        }

    }



}
