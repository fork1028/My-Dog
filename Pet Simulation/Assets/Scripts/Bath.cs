using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bath : MonoBehaviour
{

    public Dog dog;

    public void bath()
    {
        dog.updateCleanness(20);
        Debug.Log(dog.cleaness);
        dog.saveDog();
        SceneManager.LoadScene("Bathroom");


    }



}
