using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chumpa : MonoBehaviour
{
	public float Speed;
	public Vector3 position_c;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	position_c = GameObject.FindGameObjectWithTag("Character").transform.position;


        transform.position += transform.forward * Time.deltaTime * Speed;
        transform.LookAt(position_c);
    }
    void OnTriggerEnter(Collider other){
    	if(other.gameObject.CompareTag("Bullet")){
    		Destroy(this.gameObject);
    	}
    }
}
