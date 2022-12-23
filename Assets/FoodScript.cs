using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    public bool feed = false;
    public GameObject logicManager;
    LogicScript logicScript;
    // Start is called before the first frame update
    void Awake()
    {
        logicManager = GameObject.Find("LogicManager");
        logicScript = logicManager.GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        if(Input.GetMouseButtonUp(0)){
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Soramame"){
            feed = true;
            Destroy(gameObject);
            logicScript.Feed();
        }
        Debug.Log("COLLISION!");
    }


}
