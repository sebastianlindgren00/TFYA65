using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(db);
       if (db == 0)
       {
                         transform.Translate(Vector3.up * 5 * Time.deltaTime, Space.World);
       } 
        transform.Translate(0.005f,0,0);
    }
}
