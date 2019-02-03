using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WalkBack : MonoBehaviour {



    public void walkback()
    {
        Debug.Log("clicked");
        SceneManager.LoadScene("Room");

    }
}
