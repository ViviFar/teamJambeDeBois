using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {


    public float speed = 3.0f;
    Vector3 m_direction;
    bool m_fired;

       
	// Update is called once per frame
	void Update () {
		if (m_fired)
        {
            transform.position += m_direction * (speed*Time.deltaTime) ;
        }
        
	}

    //lancement d'un projectile
    void FireProjectile(GameObject launcher, GameObject target, int damage)
    {
        
        if (launcher && target)
        {
            m_direction = (target.transform.position - launcher.transform.position).normalized;
            m_fired = true;

        }
    }
}
