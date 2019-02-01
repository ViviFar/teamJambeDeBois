using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private cursorBehavior cursor;

    public List<Country> listCountry;

    [HideInInspector]
    public int currentCountry = 0;

    public TextMesh countdown;

    private float timer = 30;



    private void Start()
    {
        for (int i = 1; i < listCountry.Count; i++)
        {
            listCountry[i].gameObject.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
        float roundTimer = Mathf.Round(timer * 10) / 10;
        countdown.text = roundTimer.ToString();
        if (timer <= 0)
        {
            listCountry[currentCountry].gameObject.SetActive(false);
            currentCountry++;
            if (currentCountry >= listCountry.Count)
            {
                currentCountry = 0;
            }
            listCountry[currentCountry].gameObject.SetActive(true);
            timer = 30;
        }

        if (cursor.cursor_d.localPosition.z >= 5 || cursor.cursor_d.localPosition.z <= -5
            || cursor.cursor_t.localPosition.z >= 5 || cursor.cursor_t.localPosition.z <= -5
            || cursor.cursor_p.localPosition.z >= 5 || cursor.cursor_p.localPosition.z <= -5
            || cursor.cursor_h.localScale.z <= 0 || cursor.cursor_h.localScale.z >= 0.05)
        {
            DontDestroyOnLoad(this.gameObject);
            DontDestroyOnLoad(cursor.gameObject);
            SceneManager.LoadScene("Game over");
        }
    }
}
