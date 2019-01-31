using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Country : MonoBehaviour {

    public int humidity=25;
    public float temperature = 25;
    public int healthyCountry = 50;
    public int pollution = 30;
    public GameObject paysage;
    public bool isAtWar;
    public GameObject turrets;
    public Transform player;

    List<GameObject> turretList = new List<GameObject>();
	// Use this for initialization
	void OnEnable () {

        //if the country is at war, create a random number of turrets when the player enters the country
        if (isAtWar)
        {
            //TODO : permettre plus que une seule tourelle à créer (actuellement, une seule toureelle est détruite à chaque fois que l'on sort de la 
            //scène.
            int nbTurret = 1; //Random.Range(1, 5);
            Debug.Log("je créé " + nbTurret + "tourelles");
            for (int i = 0; i<nbTurret; i++)
            {
                //TODO: comprendre pourquoi elle se créé à des positions en dehors des endroits spécifiés.
                GameObject turret =  Instantiate(turrets, new Vector3(Random.Range(20, 40), 1, Random.Range(-40, 40)), Quaternion.LookRotation(player.position, new Vector3(0,1,0)), transform);
                turretList.Add(turret);
            }
        }
	}

    private void OnDisable()
    {
        int nbTurret = turretList.Count;
        Debug.Log("nobre de tourelle" + nbTurret);
        for(int i= 0; i < nbTurret; i++)
        {
            Debug.Log("Tourelle numero " + i + "détruite");
            Destroy(GetComponentInChildren<turrets>().gameObject);
        }
        turretList.Clear();
    }

}
