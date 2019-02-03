using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField]
    private int _hunger;
    [SerializeField]
    private int _cleaness;
    [SerializeField]
    private int _happiness;
    [SerializeField]
    private string _name;

    private bool _serverTime;
    private int _clickCount;

    // Use this for initialization
    void Start()
    {
        updateStatus();
        //testing
        //PlayerPrefs.SetString("then", "02/02/2019 06:29:12");
        if (!PlayerPrefs.HasKey("name"))
            PlayerPrefs.SetString("name", "Dog");
        _name = PlayerPrefs.GetString("name");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Clicked");
            Vector2 v = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(v), Vector2.zero);
            if (hit)
            {
                Debug.Log(hit.transform.gameObject.name);
                if (hit.transform.gameObject.tag == "Dog")
                {
                    _clickCount++;
                    if (_clickCount >= 3)
                    {
                        _clickCount = 0;
                        updateHappiness(1);
                    }
                }
            }
        }


    }

    void updateStatus()
    {
        // check if there is a hunger value
        if (!PlayerPrefs.HasKey("_hunger"))
        {
            _hunger = 100;
            PlayerPrefs.SetInt("_hunger", _hunger);
        }
        else
        {
            _hunger = PlayerPrefs.GetInt("_hunger");
        }

        // check if there is a cleaness value
        if (!PlayerPrefs.HasKey("_cleaness"))
        {
            _cleaness = 100;
            PlayerPrefs.SetInt("_cleaness", _cleaness);
        }
        else
        {
            _cleaness = PlayerPrefs.GetInt("_cleaness");
        }

        // check if there is a happiness value
        if (!PlayerPrefs.HasKey("_happiness"))
        {
            _happiness = 100;
            PlayerPrefs.SetInt("_happiness", _happiness);
        }
        else
        {
            _happiness = PlayerPrefs.GetInt("_happiness");
        }


        // check if there is a "then"
        if (!PlayerPrefs.HasKey("then"))
            PlayerPrefs.SetString("then", getStringTime());

        // altering hunger and so on
        TimeSpan ts = getTimeSpan();
        _hunger -= (int)(ts.TotalHours) * 2;
        if (_hunger < 0)
            _hunger = 0;

        _cleaness -= (int)(ts.TotalHours) * 2;
        if (_cleaness < 0)
            _cleaness = 0;

        //_happiness -= (int)(ts.TotalHours) * 2;
        //if (_happiness < 0)
        //_happiness = 0;

        _happiness -= (int)((100 - (_hunger + _cleaness) / 2) / 10 * ((ts.TotalHours) / 5));
        if (_happiness < 0)
            _happiness = 0;

        // debug'
        Debug.Log(getTimeSpan().ToString());
        Debug.Log(getTimeSpan().TotalHours);


        // update time
        if (_serverTime)
            updateServer();
        else
            InvokeRepeating("updateDevice", 0f, 30f);
    }

    void updateServer()
    {
    }

    void updateDevice()
    {
        PlayerPrefs.SetString("then", getStringTime());
        //PlayerPrefs.SetString("then", "02/01/2019 16:00:12");
    }

    TimeSpan getTimeSpan()
    {
        if (_serverTime)
            return new TimeSpan();
        else
            return DateTime.Now - Convert.ToDateTime(PlayerPrefs.GetString("then"));
    }

    string getStringTime()
    {
        DateTime now = DateTime.Now;
        return now.Month + "/" + now.Day + "/" + now.Year + " " + now.Hour + ":" + now.Minute + ":" + now.Second;
    }

    public int hunger
    {
        get { return _hunger; }
        set { _hunger = value; }
    }
    public int cleaness
    {
        get { return _cleaness; }
        set { _cleaness = value; }
    }

    public int happiness
    {
        get { return _happiness; }
        set { _happiness = value; }
    }

    public string name
    {
        get { return _name; }
        set { _name = value; }
    }

    public void updateHappiness(int i)
    {
        _happiness += i;
        if (_happiness >= 100)
            _happiness = 100;
    }

    public void updateHunger(int i)
    {
        _hunger += i;
        if (_hunger >= 100)
            _hunger = 100;
    }

    public void updateCleanness(int i)
    {
        _cleaness += i;
        if (_cleaness >= 100)
            _cleaness = 100;
    }

    public void walkDog()
    {
        updateHunger(-5);
        updateCleanness(-10);
        updateHappiness(20);
    }

    // save at once
    public void saveDog()
    {
        if (!_serverTime)
        {
            updateDevice();
        }
        PlayerPrefs.SetInt("_hunger", _hunger);
        PlayerPrefs.SetInt("_happiness", _happiness);
        PlayerPrefs.SetInt("_cleaness", _cleaness);
    }
}


