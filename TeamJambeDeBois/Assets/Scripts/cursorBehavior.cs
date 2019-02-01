using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorBehavior : MonoBehaviour
{
    public GameManager gm;
    public Transform cursor_t;
    public Transform cursor_d;
    public Transform cursor_p;
    public Transform cursor_h;
    public GameObject prefabMedikit;
    public Transform spawnZone;

    private Country country;

    //Paramètres du pays
    private float temperature;
    private float dryness;
    private float pollution;
    private float healthy;

    //Paramètres de déplacements du curseur
    private float timer = 0.0f;
    private float waitTimer = 0.0f;
    private float deltaPos;
    private float speedCursor;
    private float waitMedipak;

    private float oldHealthScale = 0.025f;


    // Start is called before the first frame update
    void Start()
    {
        //Get le country où on est
        country = gm.listCountry[gm.currentCountry];

        //Initialisation des positions
            //Température
            Vector3 pos = new Vector3(cursor_t.position.x, cursor_t.position.y, 0);
            cursor_t.localPosition = pos;

            //Dryness
            pos = new Vector3(cursor_d.position.x, cursor_d.position.y, 0);
            cursor_d.localPosition = pos;

            //Pollution
            pos = new Vector3(cursor_p.position.x, cursor_p.position.y, 0);
            cursor_p.localPosition = pos;


        // Initialisation des conditions
        temperature = country.temperature;
        dryness = country.humidity;
        pollution = country.pollution;
        healthy = country.healthyCountry;

    }

    // Update is called once per frame
    void Update()
    {

        //Get le country où on est
        country = gm.listCountry[gm.currentCountry];


        temperature = country.temperature;
        dryness = country.humidity;
        pollution = country.pollution;
        healthy = country.healthyCountry;

        timer += Time.deltaTime;
        waitTimer += Time.deltaTime;

        //TEMPERATURE
        if (temperature > 20)
        {
            speedCursor = 0.00625f * temperature + -0.125f;    //vitesse
            deltaPos = speedCursor * timer; //dx = v.dt

            cursor_t.localPosition = new Vector3(0.0f, 0.0f, cursor_t.localPosition.z + deltaPos);
        }

        else if (temperature < 10)
        {
            speedCursor = 0.00625f * temperature + -0.0625f; ;
            deltaPos = speedCursor * timer; 

            cursor_t.localPosition = new Vector3(0.0f, 0.0f, cursor_t.localPosition.z + deltaPos);
        }

        //DRYNESS
        if (dryness > 50)
        {
            speedCursor = 0.005f * dryness - 0.25f; ;    
            deltaPos = speedCursor * timer; 

            cursor_d.localPosition = new Vector3(0.0f, 0.0f, cursor_d.localPosition.z + deltaPos);
        }

        else if (dryness < 25)
        {
            speedCursor = 0.01f * temperature - 0.25f; ;
            deltaPos = speedCursor * timer; 

            cursor_d.localPosition = new Vector3(0.0f, 0.0f, cursor_d.localPosition.z + deltaPos);
        }

        //POLLUTION
        if (pollution > 60)
        {
            speedCursor = 0.00625f * dryness - 0.375f; ;
            deltaPos = speedCursor * timer;

            cursor_p.localPosition = new Vector3(0.0f, 0.0f, cursor_p.localPosition.z + deltaPos);
        }

        else if (pollution < 40)
        {
            speedCursor = 0.00625f * temperature - 0.25f; ;
            deltaPos = speedCursor * timer;

            cursor_p.localPosition = new Vector3(0.0f, 0.0f, cursor_p.localPosition.z + deltaPos);
        }

        //HEALTH
        waitMedipak = 1/(0.002f * healthy);
        if(waitTimer>=waitMedipak)
        {
            GameObject mediPak = Instantiate(prefabMedikit, spawnZone);
            float randX = Random.Range(-4, 4);
            float randZ = Random.Range(-4, 4);
            Vector3 posMed = new Vector3(randX, -1.0f, randZ);
            mediPak.transform.localPosition = posMed;
            waitTimer = 0.0f;
            Destroy(mediPak, 5.0f);
        }
        timer = 0.0f;
    }

    public void takeDamage(float healthChanger)
    {
        oldHealthScale += healthChanger;
        Vector3 scale = new Vector3(10.0f, 0.2f,oldHealthScale);
        cursor_h.localScale = scale;
    }
}
