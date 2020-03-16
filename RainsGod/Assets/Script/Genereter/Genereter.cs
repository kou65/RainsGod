using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genereter : MonoBehaviour
{

    GameObject m_fruit;


    // Start is called before the first frame update
    void Start()
    {
        m_fruit = (GameObject)Resources.Load("Prehub/Fruit");
    }

    void CreateFruit(Vector3 pos)
    {
        Instantiate(m_fruit, pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
