using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Heart : MonoBehaviour {

    public GameObject heart;

    void hide(){
        heart.SetActive(false);
    }
}
