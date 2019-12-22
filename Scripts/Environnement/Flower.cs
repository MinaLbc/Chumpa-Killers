using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
	public GameObject SeedPrefab;
    public GameObject TigePrefab;
    public GameObject FlowerPrefab;

	private GameObject Seed;

    public float Timer;
    public float Grow_C;
    public float Bloom_C;
    public float CollectF_C;

    public bool FlowerOn;

    //public int FCount;
    //public TextMesh FCountText;


    void Start()
    {
    	Seed = null;
        FlowerOn = false;
        //FCount = 0;


        //SetFCountText();
        
    }

    // Update is called once per frame
    void Update()
    {

       if (Seed != null){
            Timer += Time.deltaTime;
            

            if(Timer > Grow_C){
                Grow();

                if(Timer > Bloom_C){
                    Bloom();

                    if(Timer > CollectF_C){
                        CollectF();
                    }
                }
            }
        }
    }


    //IEnumerator Plant(){}

    public bool PlantSeed(){

        bool has_seeded = false;

    	if(Seed == null){
	    	Seed = Instantiate(SeedPrefab, this.transform.position, Quaternion.identity) as GameObject;
	    	Seed.transform.parent = this.transform;

            Timer = 0;

            Debug.Log("PlantSeed");

            has_seeded = true;    
    	}

        return has_seeded;
    }


    public void Grow(){
        Debug.Log("Destroy seed");
        Destroy(Seed);
        
        Seed = Instantiate (TigePrefab, this.transform.position, Quaternion.identity) as GameObject;
        var tp = transform.position;
        tp.y = 0.8f;
        Seed.transform.position = tp;
        Seed.transform.parent = this.transform;
        
    }

    public void Bloom(){
        Debug.Log("bloom");
        Destroy(Seed);

        Seed = Instantiate(FlowerPrefab, this.transform.position, Quaternion.identity) as GameObject;
        var tp = transform.position;
        tp.y = 0.8f;
        Seed.transform.position = tp;
        Seed.transform.parent = this.transform;
    }

    public void CollectF(){
        Debug.Log("collect flower");
        Destroy(Seed);

        //FCount = FCount + 1;
        //SetFCountText();

        Seed = null;
        FlowerOn = true;
    }

    /*void SetFCountText(){
        FCountText.text = FCount.ToString();
        Debug.Log("floweeeer");
    }*/
}