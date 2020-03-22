using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class himoController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(-7,8,10);
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
                    EventDirector.StartPlanetInitEvent();
                }
            }
        }



    }

    public static void CreateHimo(GameObject obj_)
    {
        if (GameObject.Find("himo")) { return; }
        PrefabGenerator.CreateChild(obj_, "Prefab/UI/himoPrefab", "himo");
    }

}
