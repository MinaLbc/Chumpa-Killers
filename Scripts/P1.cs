using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1 : MonoBehaviour
{
	
    public string Horizontal;
    public string Vertical;


    public float RunSpeed;
	public float TurnSpeed;
	public float BulletSpeed;

	public GameObject RockPrefab;
    public Transform RockSpawn;
    public GameObject TowerPrefab;
    public Transform TowerSpaw;
    public GameObject BarricadePrefab;
    public Transform BarricadeSpaw;
    public GameObject BuchePrefab;


	public float Timer_p;
	public float Timer;

	private GameObject rock;
	private GameObject buche;
	private GameObject seed;
	private GameObject Seed;
	private GameObject tree;
	private GameObject ressource;
	private GameObject tower;


	private int RCount;
	private int BCount;
	private int SCount;
	public int FCount;


	public Text RCountText;
	public Text BCountText;
	public Text SCountText;
    public TextMesh FCountText;

    public GameObject[] Fields;
	 



    void Start()
    {
    	Timer = 0;
    	Timer_p = 0;
        RCount = 0;
        BCount = 0;
        SCount = 0;
        FCount = 0;


        SetRCountText();
        SetBCountText();
        SetSCountText();
        SetFCountText();
    }




    void Update()
    {

    	var x = Input.GetAxis(Horizontal) * Time.deltaTime * TurnSpeed;
    	var z = Input.GetAxis(Vertical) * Time.deltaTime * RunSpeed;

    	transform.Rotate(0, x, 0);
    	transform.Translate(0, 0, z);

    	Timer_p -= Time.deltaTime;

    	if(Seed != null){
   			Timer -= Time.deltaTime;
    	}

    	if(Input.GetKeyDown("space") && RCount > 0 ){
			LaunchProjectile();
		}

		if(Input.GetKeyDown("v") && BCount >= 3){
			BuildBarricade();
		}

		if(Input.GetKeyDown("c") && FCount >= 3 ){
			BuildTower();
		}


		if(Input.GetKeyDown("x")){
    		Debug.Log("CanPickUpRessources");

    		CanChop();
    	}

    	if(Input.GetKeyDown("g")){
    		Debug.Log("CanEvolve");

    		CanEvolve();
    	}


    	for (int i=0; i< Fields.Length; i++){

            if (Fields[i].GetComponent<Flower>().FlowerOn == true){

                Fields[i].GetComponent<Flower>().FlowerOn = false;
                FCount += 1;

                SetFCountText();
            }
        }

    }




    void OnTriggerEnter(Collider other){
    	
    	if(other.gameObject.CompareTag("field")){
    		//Seed = other.gameObject;

	   		if (SCount > 0){
	   			if (other.gameObject.GetComponent<Flower>().PlantSeed() == true){
	   				
	   				SCount = SCount - 1;
	   				SetSCountText();
	   			}	   			
	   			// pour appeler à une fonction dans un autre script
	   			//Destroy(Seed);
	   		}
	    }


	    if (other.gameObject.CompareTag("Tower")){
	    	Debug.Log("tower");

	    }

	    if(other.gameObject.CompareTag("Tree")){
	    	tree = other.gameObject;

	    }




       	if(other.gameObject.CompareTag("Buche")){
    		other.gameObject.SetActive(false);
    		Debug.Log("Buche");
    		buche = other.gameObject;
    		Destroy(buche.gameObject);
    		BCount = BCount + 1;

	       	SetBCountText();
	   	}

    	if(Timer_p <= 0){
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


    	if(other.gameObject.CompareTag("Seed")){
    		Debug.Log("seed");
    		seed = other.gameObject;
    		Destroy(seed.gameObject);
    		SCount = SCount + 1;

    		SetSCountText();
    	}


    	if(other.gameObject.CompareTag("Champ")){
    		Debug.Log("champ");
    	}
    }




    

    void LaunchProjectile()
    {
    	Debug.Log("pioupiou");
    	Timer_p = 0.2f;
        GameObject RockPrefab_o = Instantiate (RockPrefab, RockSpawn.position, RockSpawn.rotation) as GameObject;

        RockPrefab_o.GetComponent<Rigidbody>().velocity = RockPrefab_o.transform.forward * BulletSpeed;

        Destroy(RockPrefab_o, 2.0f);


        if(RCount > 0){
        	Debug.Log("-1");
    		RCount = RCount - 1;
    		SetRCountText();
    	}
    }





    void CanChop(){
    	Debug.Log("CanPickUp");

    	if(tree != null){
    		Debug.Log("CanPickUpRock");
    		Destroy(tree.gameObject);
            GameObject BuchePrefab_o = Instantiate(BuchePrefab, tree.transform.position, tree.transform.rotation) as GameObject;
    		//RCount = RCount + 1;

        	//SetRCountText();
    	}
    }

    void CanEvolve(){
    	Debug.Log("EVOLVE");

    	if(tower != null){
    		Debug.Log("EVOLVE TOWER");
    		//NewTower_o = Instantiate(NewTowerPrefab,);
    		Destroy(ressource.gameObject);
    		//RCount = RCount + 1;

        	//SetRCountText();
    	}
    }


    void BuildTower(){

    	Debug.Log("build tower");
    	GameObject TowerPrefab_o = Instantiate (TowerPrefab, TowerSpaw.position, Quaternion.identity) as GameObject;

    	FCount = FCount - 3;
    	SetFCountText();
    }


    void BuildBarricade(){

    	Debug.Log("build tower");
    	GameObject TowerBarricade_o = Instantiate (BarricadePrefab, BarricadeSpaw.position, Quaternion.identity) as GameObject;

    	BCount = BCount - 3;
    	SetBCountText();
    }

    



    void SetRCountText(){

    	RCountText.text = "Rocks:" + RCount.ToString();
    }

    void SetBCountText(){

    	BCountText.text = "Buches:" + BCount.ToString();
    }

    void SetSCountText(){
    	SCountText.text = "Graines:" + SCount.ToString();
    }

    void SetFCountText(){
        FCountText.text = FCount.ToString();
        Debug.Log("floweeeer");
    }
}
