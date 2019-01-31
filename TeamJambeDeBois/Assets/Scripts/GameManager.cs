﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public List<Country> listCountry;

    [HideInInspector]
    public int currentCountry = 0;



    private void Start()
    {
        for(int i=1; i<listCountry.Count; i++)
        {
            listCountry[i].gameObject.SetActive(false);
        }
    }

    private void OnMouseDown()
    {

    }

    // Update is called once per frame
    void Update () {
        //To modify to use Oculus input instead of mouse left click on
        if (Input.GetMouseButtonDown(0))
        {
            listCountry[currentCountry].gameObject.SetActive(false);
            currentCountry++;
            if (currentCountry >= listCountry.Count)
            {
                currentCountry = 0;
            }
            listCountry[currentCountry].gameObject.SetActive(true);
        }
	}
}