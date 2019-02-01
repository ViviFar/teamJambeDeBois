using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    public float fireRate;
    public GameObject projectile;
    public GameObject launcher;
    public GameObject target;

    private float n = 0;
    private void Update()
    {
        n+=Time.deltaTime;
        if (n >= 1)
        {
            SpawnProjectiles(launcher, target);
            n = 0;
        }
    }


    void SpawnProjectiles(GameObject turret, GameObject Target)
    {
        if (projectile)
        {
            Vector3 direction=(turret.transform.position- Target.transform.position).normalized;
            GameObject proj;
            
            proj =Instantiate(projectile, launcher.transform.position + new Vector3(0,0,2),  Quaternion.LookRotation(Target.transform.position + new Vector3(0, 0, 2), Target.transform.up));
            proj.GetComponent<Rigidbody>().AddForce(-1*direction*projectile.GetComponent<projectile>().speed*10);
            Destroy(proj, 10);
        }

    }
}