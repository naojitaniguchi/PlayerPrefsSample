using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefManager : MonoBehaviour
{
    public GameObject TextA;
    public GameObject TextB;

    bool flagA;
    bool flagB;

    // Start is called before the first frame update
    void Start()
    {
        int prefValue = PlayerPrefs.GetInt("FlagA");
        if ( prefValue == 0)
        {
            flagA = false;
        }else if ( prefValue == 1)
        {
            flagA = true;
        }
        GlobalVariables.flagA = flagA;

        prefValue = PlayerPrefs.GetInt("FlagB");
        if (prefValue == 0)
        {
            flagB = false;
        }
        else if (prefValue == 1)
        {
            flagB = true;
        }
        GlobalVariables.flagB = flagB;

        setFlagToText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if ( GlobalVariables.flagA == true)
            {
                GlobalVariables.flagA = false;
                PlayerPrefs.SetInt("FlagA", 0);
            }
            else
            {
                GlobalVariables.flagA = true;
                PlayerPrefs.SetInt("FlagA", 1);
            }

            setFlagToText();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (GlobalVariables.flagB == true)
            {
                GlobalVariables.flagB = false;
                PlayerPrefs.SetInt("FlagB", 0);
            }
            else
            {
                GlobalVariables.flagB = true;
                PlayerPrefs.SetInt("FlagB", 1);
            }
            setFlagToText();
        }
    }

    void setFlagToText()
    {
        if ( GlobalVariables.flagA)
        {
            TextA.GetComponent<Text>().text = "On";
        }
        else
        {
            TextA.GetComponent<Text>().text = "Off";
        }

        if (GlobalVariables.flagB)
        {
            TextB.GetComponent<Text>().text = "On";
        }
        else
        {
            TextB.GetComponent<Text>().text = "Off";
        }
    }

    public void saveFlags()
    {
        if (GlobalVariables.flagA == true)
        {
            PlayerPrefs.SetInt("FlagA", 1);
        }
        else
        {
            PlayerPrefs.SetInt("FlagA", 0);
        }

        if (GlobalVariables.flagB == true)
        {
            GlobalVariables.flagB = false;
            PlayerPrefs.SetInt("FlagB", 0);
        }
        else
        {
            GlobalVariables.flagB = true;
            PlayerPrefs.SetInt("FlagB", 1);
        }
    }

    public void loadFlags()
    {
        int prefValue = PlayerPrefs.GetInt("FlagA");
        bool flagValue = false ;
        if (prefValue == 0)
        {
            flagValue = false;
        }
        else if (prefValue == 1)
        {
            flagValue = true;
        }
        GlobalVariables.flagA = flagValue;

        prefValue = PlayerPrefs.GetInt("FlagB");
        flagValue = false;
        if (prefValue == 0)
        {
            flagValue = false;
        }
        else if (prefValue == 1)
        {
            flagValue = true;
        }
        GlobalVariables.flagB = flagValue;
    }

    public void clearFlags()
    {
        PlayerPrefs.DeleteAll();
    }
}
