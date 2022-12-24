using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoramameScript : MonoBehaviour
{
    public Rigidbody2D soramameBody;
    public SpriteRenderer soramameSprite;
    private AudioSource audioSource;
    private float time;
    [SerializeField] float hopTimeMultiplier;
    [SerializeField] float hopStrengthMultiplier;
    [SerializeField] AudioClip deathSound;

    public bool isDead = false;
    public bool playedWith = false;
    public bool playEnabled = true;

    Vector3 minScreenBounds;
    Vector3 maxScreenBounds;

    float halfWidth;
    // Start is called before the first frame update
    void Start()
    {
        minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width*-1, Screen.height*-1, 0));
        maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        halfWidth = soramameSprite.bounds.size.x/2;
        Debug.Log(maxScreenBounds);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 10*hopTimeMultiplier && isDead == false){
            Hop();
        }
        ClampPosition();
    }

    void Hop(){
        int LeftOrRight = Random.Range(0,2)*2-1;;
        Debug.Log(LeftOrRight);
        soramameBody.velocity = new Vector2(Random.Range(0f,1f)*LeftOrRight*hopStrengthMultiplier,Random.Range(0f,1f)*hopStrengthMultiplier+0.5f);
        time = 0f;
        hopTimeMultiplier = Random.Range(0f,1f);
        audioSource.Play();
    }

    public void Flip(){
        soramameSprite.flipY = true;
        audioSource.PlayOneShot(deathSound);
    }

    public void OnMouseDown(){
        if(!isDead){
            if(playEnabled){
                Hop();
                playedWith = true;
            }
        }
    }

    void ClampPosition(){
        soramameBody.transform.position = new Vector3(Mathf.Clamp(soramameBody.transform.position.x, -7, 7), Mathf.Clamp(soramameBody.transform.position.y, -5, 5), 0);
    }

}
