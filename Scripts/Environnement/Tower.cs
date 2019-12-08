using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform Chumpa;
    Vector3 Chumpa_Last_p = Vector3.zero;

    public Transform BulletSpawn;
    public GameObject BulletPrefab;
    public float FireRate;
    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("Shoot", 0.0f, FireRate);  
    }


    public void Shoot(){

         GameObject BulletPrefab_o = Instantiate (BulletPrefab, BulletSpawn.position, BulletSpawn.rotation) as GameObject;

        BulletPrefab_o.GetComponent<Rigidbody>().velocity = BulletPrefab_o.transform.forward * 6;

        Bullet Bullet = BulletPrefab_o.GetComponent<Bullet>();

/*        if(BulletPrefab != null){
            BulletPrefab.Chase(Target);
            }*/
        }
    // Update is called once per frame
    void Update()
    {   
        if (Chumpa != null){

                Vector3 Chumpa_p = new Vector3( Chumpa.position.x, this.transform.position.y, Chumpa.position.z);
                this.transform.LookAt(Chumpa_p);
                        
        }
        
        //transform.LookAt(Chumpa);
        //transform.LookAt(Chumpa, Vector3.left);
        
    }
    /*
    private Transform Target;
    public float range = 15.0f;

    public string enemyTag = "Chumpa";

    public float FireRate;
    public GameObject BulletPrefab;
    public Transform BulletSpawn; 


    void Start()
    {	
    	InvokeRepeating("UpdateTarget", 0.0f, 0.5f);
        InvokeRepeating("LaunchProjectile", 0.0f, FireRate);
    }

    void UpdateTarget(){
    	//check the closest enemy in range


    	//finding all enemies in range
    	GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
    	//store the shortest enemy
    	float shortestDistance = Mathf.Infinity;
    	GameObject nearestEnemy = null;

    	foreach(GameObject enemy in enemies){

    		float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
    		if(distanceToEnemy < shortestDistance){
    			shortestDistance = distanceToEnemy;
    			nearestEnemy = enemy;
    		}
    	}

    	if(nearestEnemy != null && shortestDistance <=range){
    		Target = nearestEnemy.transform;
    	} else{

    		Target = null;
    	}
    }


    void Update(){
    	if (Target == null)
    		return;


    	
    }



    void LaunchProjectile()
    {
        GameObject BulletPrefab_o = Instantiate (BulletPrefab, BulletSpawn.position, BulletSpawn.rotation) as GameObject;

        BulletPrefab_o.GetComponent<Rigidbody>().velocity = BulletPrefab_o.transform.forward * 6;

        Bullet Bullet = BulletPrefab_o.GetComponent<Bullet>();*/

/*        if(BulletPrefab != null){
        	BulletPrefab.Chase(Target);
        }*/
   /* }


    void OnDrawGizmosSelected(){
    	
    	Gizmos.color = Color.red;
    	Gizmos.DrawWireSphere(transform.position, range);
    }*/

}


