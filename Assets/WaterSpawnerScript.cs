using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawnerScript : MonoBehaviour
{
    public GameObject water;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnWater(){
        Instantiate(water, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), transform.rotation);
    }
}
