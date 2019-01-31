using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorBehavior : MonoBehaviour
{ 
    private float temperature;
    private float dryness;
    private float pollution;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, 0);
        transform.localPosition = pos;
    }

    // Update is called once per frame
    void Update()
    {
        if(temperature>20)
        {
            float speedCursor = 0.00625f * temperature - 0.125f;    //

        }
    }
}
