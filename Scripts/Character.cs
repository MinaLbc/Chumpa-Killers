using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
	public float RunSpeed;
	public float TurnSpeed;
	public GameObject RockPrefab;
    public Transform RockSpawn; 
    public GameObject TowerPrefab;
    public Transform TowerSpaw;


	private float Timer;
	private GameObject rock;
	private GameObject carotte;


	private int RCount;
	private int CCount;
	public Text RCountText;
	public Text CCountText;


    void Start()
    {
    	Timer = 0;
        RCount = 0;
        CCount = 0;


        SetRCountText();
        SetCCountText();
    }




    void Update()
    {

    	var x = Input.GetAxis("Horizontal") * Time.deltaTime * TurnSpeed;
    	var z = Input.GetAxis("Vertical") * Time.deltaTime * RunSpeed;

    	transform.Rotate(0, x, 0);
    	transform.Translate(0, 0, z);

    	Timer -= Time.deltaTime;

    	if(Input.GetKeyDown("x") && RCount > 0 ){
			LaunchProjectile();
		}

		if(Input.GetKeyDown("c") && CCount > 2 ){
			BuildTower();
		}

    }




    void OnTriggerEnter(Collider other){

    	if(other.gameObject.CompareTag("Carotte")){
    		other.gameObject.SetActive(false);
    		Debug.Log("carotte");
    		carotte = other.gameObject;
    		Destroy(carotte.gameObject);
    		CCount = CCount + 1;

	       	SetCCountText();
	   	}

    	if(Timer <= 0){
	  	  	if(other.gameObject.CompareTag("Bullet")){
	    		other.gameObject.SetActive(false);

	    		rock = other.gameObject;
	    		Destroy(rock.gameObject);
	    		RCount = RCount + 1;

	        	SetRCountText();
	        }
    	}



    	if(other.gameObject.CompareTag("Chumpa")){
    		Destroy(this.gameObject);
    	}
    }


    

    void LaunchProjectile()
    {
    	Debug.Log("pioupiou");
    	Timer = 0.5f;
        GameObject RockPrefab_o = Instantiate (RockPrefab, RockSpawn.position, RockSpawn.rotation) as GameObject;

        RockPrefab_o.GetComponent<Rigidbody>().velocity = RockPrefab_o.transform.forward * 6;

        Destroy(RockPrefab_o, 2.0f);


        if(RCount>0){
        	Debug.Log("-1");
    		RCount = RCount - 1;
    		SetRCountText();
    	}
    }

    void BuildTower(){

    	Debug.Log("build tower");
    	GameObject TowerPrefab_o = Instantiate (TowerPrefab, TowerSpaw.position, Quaternion.identity) as GameObject;

    	CCount = CCount - 3;
    	SetCCountText();
    }

    
    void SetRCountText(){

    	RCountText.text = "Rocks:" + RCount.ToString();
    }

    void SetCCountText(){

    	CCountText.text = "Carottes:" + CCount.ToString();
    }

}
