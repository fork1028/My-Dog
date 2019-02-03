using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject hungerText;
    public GameObject cleanessText;
    public GameObject happinessText;
    public GameObject nameText;

    public GameObject namePanel;
    public GameObject nameInput;

    public GameObject dog;

    // Update is called once per frame
    void Update()
    {
        hungerText.GetComponent<Text>().text = "" + dog.GetComponent<Dog>().hunger;
        cleanessText.GetComponent<Text>().text = "" + dog.GetComponent<Dog>().cleaness;
        happinessText.GetComponent<Text>().text = "" + dog.GetComponent<Dog>().happiness;
        nameText.GetComponent<Text>().text = dog.GetComponent<Dog>().name;
    }

    public void triggerNamePanel(bool b)
    {
        namePanel.SetActive(!namePanel.activeInHierarchy);
        if (b)
        {
            dog.GetComponent<Dog>().name = nameInput.GetComponent<InputField>().text;
            // save the name we just input
            PlayerPrefs.SetString("name", dog.GetComponent<Dog>().name);
        }
    }


    public void back()
    {
        dog.GetComponent<Dog>().saveDog();
        SceneManager.LoadScene("Menu");
    }

    public void walk()
    {
        DateTime now = DateTime.Now;
        if (now.Hour > 06 && now.Hour < 12)
        {
            SceneManager.LoadScene("Morning");
        }
        else if (now.Hour >= 12 && now.Hour < 18)
        {
            SceneManager.LoadScene("Afternoon");
        }
        else if (now.Hour >= 18 || now.Hour <= 6)
        {
            SceneManager.LoadScene("Night");
        }
        dog.GetComponent<Dog>().walkDog();
        dog.GetComponent<Dog>().saveDog();
    }
}

