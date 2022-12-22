using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoramameScript : MonoBehaviour
{
    public Rigidbody2D SoramameBody;
    private float time;
    public float HopTimeMultiplier;
    public float HopStrengthMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 10*HopTimeMultiplier){
            Hop();
            time = 0f;
            HopTimeMultiplier = Random.Range(0f,1f);
        }

    }

    void Hop(){
        int LeftOrRight = Random.Range(0,2)*2-1;
        Debug.Log(LeftOrRight);
        SoramameBody.velocity = new Vector2(Random.Range(0f,1f)*LeftOrRight*HopStrengthMultiplier,Random.Range(0f,1f)*HopStrengthMultiplier);
    }
}
