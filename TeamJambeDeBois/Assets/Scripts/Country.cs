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
    public TurretContainer turretContainer;
    
	// Use this for initialization
	void OnEnable () {
        
        //if the country is at war, create a random number of turrets when the player enters the country
        if (isAtWar)
        {
            Instantiate(turretContainer);
        }
	}

    private void OnDisable()
    {
        if (isAtWar)
        {
            Destroy(FindObjectOfType<TurretContainer>().gameObject);
        }
    }

}
