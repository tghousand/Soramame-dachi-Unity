using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WaterButtonScript : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]GameObject logicManager;
    [SerializeField]float waterTimer;
    [SerializeField]Button button;
    float time = 0f;
    LogicScript logicScript;
    // Start is called before the first frame update
    void Start()
    {
        logicScript = logicManager.GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(button.interactable == false){
            if(time > waterTimer){
                time = 0f;
                button.interactable = true;
            } else time += Time.deltaTime;
        }
    }

    public void OnPointerDown(PointerEventData eventData){
        if(button.interactable == true){
            logicScript.SpawnWater();
            button.interactable = false;
        }
        
    }
}
