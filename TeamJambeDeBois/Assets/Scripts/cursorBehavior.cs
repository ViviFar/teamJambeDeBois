using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorBehavior : MonoBehaviour
{ 
    //Paramètres du pays
    private float temperature;
    private float dryness;
    private float pollution;

    //Paramètres de déplacements du curseur
    private float timer = 0.0f;
    private float deltaPos;
    private float speedCursor;

    public float a; // coefficient directeur de la fonction de vitesse du curseur
    public float bpos; // ordonnée à l'origine dans le cas où Température > 20
    public float bneg; // ordonnée à l'origine dans le cas où Température > 10

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, 0);
        transform.localPosition = pos;

        a = 0.00625f;
        bpos = -0.125f;
        bneg = -0.0625f;

        temperature = 5.0f;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(temperature>20)
        {
            speedCursor = a * temperature + bpos;    //vitesse
            deltaPos = speedCursor * timer; //dx = v.dt

            transform.localPosition = new Vector3(0.0f, 0.0f, transform.localPosition.z + deltaPos);
        }

       else if(temperature < 10)
       {
            speedCursor =    a * temperature + bneg;
            deltaPos = speedCursor * timer; //dx = v.dt

            transform.localPosition = new Vector3(0.0f, 0.0f, transform.localPosition.z + deltaPos);
        }

        timer = 0.0f;
    }
}
