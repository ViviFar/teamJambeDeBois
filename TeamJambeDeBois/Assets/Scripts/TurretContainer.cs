using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretContainer : MonoBehaviour {

    public GameObject turrets;
    private Transform player;

    // Use this for initialization
    void Start () {
        int nbTurret = Random.Range(1, 5);
        for (int i = 0; i < nbTurret; i++)
        {
            GameObject turret = Instantiate(turrets, transform);
            turret.transform.position = new Vector3(Random.Range(20, 40), 1, Random.Range(-40, 40));
            turret.transform.rotation = Quaternion.LookRotation(new Vector3(), new Vector3(0, 1, 0));
        }
	}
	
}
