using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterBehavior : MonoBehaviour
{

    //public declarations
    public GameManager gm;

    public Transform water;
    public Transform seau;
    public Transform spawnZone;

    public GameObject rainPrefab1;
    public GameObject rainPrefab2;
    public GameObject rainPrefab3;
    public GameObject rainPrefab4;
    public GameObject rainPrefab5;
    public GameObject waterBucket;

    private Country country;

    private float dryness;
    private float waterTimer=0.0f;
    private float waterLevel;
    private float bucketTimer = 0.0f;
    private float waterDespawnTimer = 0.0f;

    private Vector3 rainScale = new Vector3(4, 4, 4);

    private bool countryChange;
    private bool isAboveWater=false;
    private bool isEmpty=true;
    private bool isWaterSpawned = false;


    // Use this for initialization
    void Start()
    {
        //On récupère le pays courant et on initialise les variables nécessaires.
        country = gm.listCountry[gm.currentCountry];

        Vector3 waterCubeScale = new Vector3(5,water.localScale.y,5);
        Vector3 waterCubePosition = new Vector3(0, water.localScale.y / 2, 0);
        Vector3 seauPosition = new Vector3(seau.localPosition.x, seau.localPosition.y, seau.localPosition.z);
        Vector3 waterSpawnZone = new Vector3();

        waterLevel = water.localPosition.y + water.localScale.y/2;
        dryness = country.humidity;

    }

    // Update is called once per frame
    void Update()
    {
        //Détecte si l'on change de pays
        countryChange = (country != gm.listCountry[gm.currentCountry]);

        country = gm.listCountry[gm.currentCountry];

        dryness = country.humidity;

        //Spawn de la pluie (plus ou moins forte selon l'humidité)
        if (dryness<25 && dryness >= 20)
        {
            GameObject rain = Instantiate(rainPrefab1, spawnZone);
            Vector3 posRain = new Vector3(0,0,0);
            rain.transform.localPosition = posRain;
            rain.transform.localScale = rainScale;
            Vector3 newLevelWater = new Vector3(water.localScale.x, water.localScale.y + 0.01f, water.localScale.z);
            water.localScale = newLevelWater;
            if (countryChange)
            {
                Destroy(rain);
            }
        }
        else if (dryness < 20 && dryness >= 15){
            GameObject rain = Instantiate(rainPrefab2, spawnZone);
            Vector3 posRain = new Vector3(0, 0, 0);
            rain.transform.localPosition = posRain;
            rain.transform.localScale = rainScale;
            Vector3 newLevelWater = new Vector3(water.localScale.x, water.localScale.y + 0.015f, water.localScale.z);
            water.localScale = newLevelWater;
            if (countryChange)
            {
                Destroy(rain);
            }
        }
        else if (dryness < 15 && dryness >= 10)
        {
            GameObject rain = Instantiate(rainPrefab3, spawnZone);
            Vector3 posRain = new Vector3(0, 0, 0);
            rain.transform.localPosition = posRain;
            rain.transform.localScale = rainScale;
            Vector3 newLevelWater = new Vector3(water.localScale.x, water.localScale.y + 0.02f, water.localScale.z);
            water.localScale = newLevelWater;
            if (countryChange)
            {
                Destroy(rain);
            }
        }
        else if (dryness < 10 && dryness >= 5)
        {
            GameObject rain = Instantiate(rainPrefab4, spawnZone);
            Vector3 posRain = new Vector3(0, 0, 0);
            rain.transform.localPosition = posRain;
            rain.transform.localScale = rainScale;
            Vector3 newLevelWater = new Vector3(water.localScale.x, water.localScale.y + 0.025f, water.localScale.z);
            water.localScale = newLevelWater;
            if (countryChange)
            {
                Destroy(rain);
            }
        }
        else if (dryness < 5 && dryness >= 0)
        {
            GameObject rain = Instantiate(rainPrefab5, spawnZone);
            Vector3 posRain = new Vector3(0, 0, 0);
            rain.transform.localPosition = posRain;
            rain.transform.localScale = rainScale;
            Vector3 newLevelWater = new Vector3(water.localScale.x, water.localScale.y + 0.03f, water.localScale.z);
            water.localScale = newLevelWater;
            if (countryChange)
            {
                Destroy(rain);
            }
        }

        //Gestion de l'interaction entre le seau et l'eau (seulement si le seau est tenu par le joueur)
        //On teste si le seau est immergé
        isAboveWater = seau.localPosition.y < waterLevel;
        if (!isAboveWater)
        {
            //On teste si le seau est rempli
            if (isEmpty) {
                //On fait baisser le niveau de l'eau
                Vector3 newWaterPos = new Vector3(water.localPosition.x, water.localPosition.y - 0.2f, water.localPosition.z);
                water.localPosition = newWaterPos;
                isEmpty = false;
                //On remplit le seau
                GameObject bucket = Instantiate(waterBucket, seau);
                Vector3 waterPos = new Vector3(0, -0.1f, 0);
                bucket.transform.localPosition = waterPos;
                isWaterSpawned = true;
            }
        }
        if(isAboveWater && !isEmpty)
        {
            bucketTimer += Time.deltaTime;
            if (bucketTimer >= 2)
            {
                isEmpty = true;
                bucketTimer = 0;
            }
        }
        if (isWaterSpawned && isEmpty)
        {
            waterDespawnTimer += Time.deltaTime;
            if (waterDespawnTimer > 3.0f)
            {
                Destroy(waterBucket);
                isWaterSpawned = false;
            }
        }
    }
}
