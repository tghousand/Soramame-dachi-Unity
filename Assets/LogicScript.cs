using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    [SerializeField] GameObject soramame;
    [SerializeField] GameObject foodSpawner;
    [SerializeField] GameObject waterSpawner;
    [SerializeField] Image foodBar;
    [SerializeField] Image waterBar;
    [SerializeField] Image funBar;
    [SerializeField] Button restartButton;
    SoramameScript soramameScript;
    FoodSpawnerScript foodSpawnerScript;
    WaterSpawnerScript waterSpawnerScript;
    public float foodPeriod;
    private float foodTimer;
    public float waterPeriod;
    private float waterTimer;
    public float funPeriod;
    private float funTimer;

    private float playTimer;
    public float playPeriod;
    private bool isDead = false;



    // Start is called before the first frame update
    void Awake()
    {
        soramameScript = soramame.GetComponent<SoramameScript>();
        foodSpawnerScript = foodSpawner.GetComponent<FoodSpawnerScript>();
        waterSpawnerScript = waterSpawner.GetComponent<WaterSpawnerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead){
            foodTimer += Time.deltaTime;
            waterTimer += Time.deltaTime;
            funTimer += Time.deltaTime;
            if(foodTimer > foodPeriod){
                foodTimer = 0.0f;
                foodBar.fillAmount -= 0.1f;
                DeathCheck();
            }
            if(waterTimer > waterPeriod){
                waterTimer = 0.0f;
                waterBar.fillAmount -= 0.1f;
                DeathCheck();
            }
            if(funTimer > funPeriod){
                funTimer = 0.0f;
                funBar.fillAmount -= 0.1f;
                DeathCheck();
            }
            if(soramameScript.playedWith == true){
                funBar.fillAmount += 0.1f;
                funTimer = 0f;
                soramameScript.playedWith = false;
                soramameScript.playEnabled = false;
            }
            if(!soramameScript.playEnabled){
                playTimer += Time.deltaTime;
                if(playTimer > playPeriod){
                    soramameScript.playEnabled = true;
                    playTimer = 0f;
                }
            }
        }
        if(Input.GetKey(KeyCode.Escape)){
            Application.Quit();
        }
        
    }

    void DeathCheck(){
        if(foodBar.fillAmount == 0 || waterBar.fillAmount == 0 || funBar.fillAmount == 0){
            Die();
        }
    }

    void Die(){
        foodBar.fillAmount = 0;
        waterBar.fillAmount = 0;
        funBar.fillAmount = 0;
        restartButton.gameObject.SetActive(true);
        soramameScript.Flip();
        soramameScript.isDead = true;
        isDead = true;
    }

    public void SpawnFood(){
        foodSpawnerScript.SpawnFood();
        Debug.Log("Food Spawned");
    }

    public void SpawnWater(){
        waterSpawnerScript.SpawnWater();
    }

    public void Feed(){
        foodBar.fillAmount += .1f;
    }

    public void Water(){
        waterBar.fillAmount += .1f;
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
