using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private cursorBehavior cursor;

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

        if(cursor.cursor_d.localPosition.z>=5 || cursor.cursor_d.localPosition.z <= -5
            || cursor.cursor_t.localPosition.z >= 5 || cursor.cursor_t.localPosition.z <= -5
            || cursor.cursor_p.localPosition.z >= 5 || cursor.cursor_p.localPosition.z <= -5
            || cursor.cursor_h.localScale.z <= 0 || cursor.cursor_h.localScale.z>=0.05)
        {
            DontDestroyOnLoad(this.gameObject);
            DontDestroyOnLoad(cursor.gameObject);
            SceneManager.LoadScene("Game over");
        }
	}
}
