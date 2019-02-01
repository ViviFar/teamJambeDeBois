using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileBehavior : MonoBehaviour
{
    public float healthChanger;
    [HideInInspector]
    public cursorBehavior cursor;

    private void Start()
    {
        cursor = GameObject.FindGameObjectsWithTag("cursorBehavior")[0].GetComponent<cursorBehavior>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            cursor.takeDamage(healthChanger);
            Destroy(this.gameObject);
        }
    }


}