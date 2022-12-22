using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public float foodPeriod;
    private float foodTimer;
    public float waterPeriod;
    private float waterTimer;
    public float funPeriod;
    private float funTimer;

    public Image foodBar;
    public Image waterBar;
    public Image funBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foodTimer += Time.deltaTime;
        waterTimer += Time.deltaTime;
        funTimer += Time.deltaTime;
        if(foodTimer > foodPeriod){
            foodTimer = 0.0f;
            foodBar.fillAmount -= 0.1f;
        }
        if(waterTimer > waterPeriod){
            waterTimer = 0.0f;
            waterBar.fillAmount -= 0.1f;
        }
        if(funTimer > funPeriod){
            funTimer = 0.0f;
            funBar.fillAmount -= 0.1f;
        }
    }
}
