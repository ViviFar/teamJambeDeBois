using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textManager : MonoBehaviour
{
    public TextMesh tempText;
    public TextMesh dryText;
    public TextMesh pollutionText;
    public TextMesh atWar;

    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        Country country = gm.listCountry[gm.currentCountry];
        tempText.text = country.temperature.ToString();
        dryText.text = country.humidity.ToString();
        pollutionText.text = country.pollution.ToString();

        if(country.isAtWar)
        {
            atWar.text = "En guerre";
        }
        else
        {
            atWar.text = "En paix";
        }
    }

    // Update is called once per frame
    void Update()
    {
        Country country = gm.listCountry[gm.currentCountry];
        tempText.text = country.temperature.ToString();
        dryText.text = country.humidity.ToString();
        pollutionText.text = country.pollution.ToString();

        if (country.isAtWar)
        {
            atWar.text = "En guerre";
        }
        else
        {
            atWar.text = "En paix";
        }
    }
}
