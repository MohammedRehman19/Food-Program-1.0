using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class forward : MonoBehaviour
{
    public List<Sprite> images;
    public int count = 0;
    public Image MainSource;
    public TextMeshProUGUI CurrentTxt,CountTxt;
    int textcounter = 1;
    public float FireRate = 10;  // The number of bullets fired per second
    public float lastfired;     // The value of Time.time at the last firing moment
    private bool _AutoSwitching = false;
    private bool _isStartingAuto = false;
    private bool _isNext, _isPrevious;
    public float startSwitching = 2f;
    float Storestarting;
    public void Start()
    {
        Storestarting = startSwitching;
        count = 0;
        MainSource.sprite = images[count];
        CurrentTxt.text = MainSource.sprite.name; ;
        textcounter = count + 1;
        CountTxt.text = (textcounter).ToString() + "/" + images.Count.ToString();

    }

    private void Update()
    {
        if (_AutoSwitching)
        {
            if (Time.time - lastfired > 1 / FireRate)
            {
                if (_isNext)
                {
                    nexts();
                }
                else if (_isPrevious)
                {
                    previous();
                }
                lastfired = Time.time;
               
            }
        }
        if (_isStartingAuto)
        {
            if (startSwitching < 0)
            {
                _AutoSwitching = true;

            }
            else
            {
                startSwitching -= Time.deltaTime;
            }
        }
    }

    public void nexts()
    {

        if (count < images.Count-1)
        {
            count += 1;
            

        }
        else
        {
            count = 0;
           
        }
       
        MainSource.sprite = images[count];
        CurrentTxt.text = MainSource.sprite.name;
        textcounter = count + 1;
        CountTxt.text = (textcounter).ToString() + "/" + images.Count.ToString();
        _isNext = true;
        _isStartingAuto = true;
    }
    public void nextsUp()
    {
        _AutoSwitching = false;
        _isStartingAuto = false;
        _isNext = false;
        _isPrevious = false;
        startSwitching = Storestarting;
    }

    public void previous()
    {
        if (count > 0)
        {
            count -= 1;
           

        }
        else
        {
            count = images.Count - 1;
          
        }
        
        MainSource.sprite = images[count];
        CurrentTxt.text = MainSource.sprite.name;
        textcounter = count + 1;
        CountTxt.text = (textcounter).ToString() + "/" + images.Count.ToString();
        _isPrevious = true;
        _isStartingAuto = true;
    }

}
