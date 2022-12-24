using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    public GameObject logicManager;
    LogicScript logicScript;

    private AudioSource slurpSound;
    private SpriteRenderer waterRenderer;
    private bool drank = false;
    // Start is called before the first frame update
    void Awake()
    {
        logicManager = GameObject.Find("LogicManager");
        logicScript = logicManager.GetComponent<LogicScript>();
        slurpSound = gameObject.GetComponent<AudioSource>();
        waterRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        if(Input.GetMouseButtonUp(0) && !drank){
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Soramame"){
            slurpSound.Play();
            drank = true;
            waterRenderer.enabled = false;
            Destroy(gameObject, 3);
            logicScript.Water();
        }
        Debug.Log("COLLISION!");
    }
}
