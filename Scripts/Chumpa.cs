using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chumpa : MonoBehaviour
{
	public float Speed;
	public Vector3 position_c;
    public GameObject SeedPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	position_c = GameObject.FindGameObjectWithTag("Chump_pos").transform.position;


        transform.position += transform.forward * Time.deltaTime * Speed;
        transform.LookAt(position_c);
    }

    void OnTriggerEnter(Collider other){
    	if(other.gameObject.CompareTag("Bullet")){
    		
            if (other.gameObject != null){
                Destroy(other.gameObject);    
            }

            Destroy(this.gameObject);
            GameObject SeedPrefab_o = Instantiate (SeedPrefab, this.transform.position, Quaternion.identity) as GameObject;
            var tp = transform.position;
            tp.y = 1;
            SeedPrefab_o.transform.position = tp;
    	}
    }
}
