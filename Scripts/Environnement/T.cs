using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T : MonoBehaviour
{
	public float speed;

	private GameObject m_target;
	Vector3 m_Last_p = Vector3.zero;
	Quaternion m_lookAtRotation;

	public float FireRate;
	private float FireRate_p;
	public GameObject BulletPrefab;
	public Transform BulletSpawn;
    // Start is called before the first frame update
    void Start()
    {

        FireRate_p = 0;  
    }

    // Update is called once per frame
    void Update()
    {
    	FireRate_p += Time.deltaTime;

        if (m_target != null){

        	

        		if(FireRate_p >= FireRate){
        			Shoot(m_target);
        		}


            if(m_Last_p != m_target.transform.position)
            {   
                m_Last_p = m_target.transform.position;
 
                m_lookAtRotation = Quaternion.LookRotation(m_Last_p - transform.position, Vector3.up);
            }

            Quaternion new_rotation = Quaternion.Euler(this.transform.rotation.eulerAngles.x,m_lookAtRotation.eulerAngles.y,this.transform.rotation.eulerAngles.z);
            
            transform.rotation = Quaternion.RotateTowards(transform.rotation, new_rotation, speed * Time.deltaTime);
        }
    }

/*    public bool SetTarget(GameObject target){
    	m_target = target;

    	return true;
    }
*/
    void OnTriggerEnter(Collider other){
    	if(other.gameObject.CompareTag("Chumpa")){
    		m_target = other.gameObject;
        	Debug.Log("ok");
        	Shoot(other.gameObject);
        }


    }

    void Shoot(GameObject Chumpa_o){
    	GameObject BulletPrefab_o = Instantiate (BulletPrefab, BulletSpawn.position, BulletSpawn.rotation) as GameObject;
    	FireRate_p = 0;


    	BulletPrefab_o.GetComponent<Bullet>().C_Target = Chumpa_o;
        //BulletPrefab_o.GetComponent<Rigidbody>().velocity = BulletPrefab_o.transform.forward * 6;

        //Bullet Bullet = BulletPrefab_o.GetComponent<Bullet>();
    }

/*
    GameObject Closest_Chumpa(string Chumpa){
    	Vector3 position = transform.position;
    	retrun GameObject.FindGameObjectsWithTag(Chumpa);
    		.OrderBy(0 => (o.transform.position - position).srqMagnitude)
    		.FistOrDefault();
    }
    */
}