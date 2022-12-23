using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoramameScript : MonoBehaviour
{
    public Rigidbody2D soramameBody;
    public SpriteRenderer soramameSprite;
    private float time;
    [SerializeField] float hopTimeMultiplier;
    [SerializeField] float hopStrengthMultiplier;

    public bool isDead = false;
    public bool playedWith = false;
    public bool playEnabled = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 10*hopTimeMultiplier && isDead == false){
            Hop();
        }

    }

    void Hop(){
        int LeftOrRight = Random.Range(0,2)*2-1;
        Debug.Log(LeftOrRight);
        soramameBody.velocity = new Vector2(Random.Range(0f,1f)*LeftOrRight*hopStrengthMultiplier,Random.Range(0f,1f)*hopStrengthMultiplier+0.5f);
        time = 0f;
        hopTimeMultiplier = Random.Range(0f,1f);
    }

    public void Flip(){
        soramameSprite.flipY = true;
    }

    public void OnMouseDown(){
        if(!isDead){
            if(playEnabled){
                Hop();
                playedWith = true;
            }
        }
    }

}
