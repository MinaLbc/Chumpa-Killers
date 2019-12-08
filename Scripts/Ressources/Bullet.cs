using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed;
    private Vector3 m_target;

    
    // Update is called once per frame
    public void Update()
    {   
         if(m_target == null){
            Destroy(this.gameObject);
            return;
        }

        m_target = GameObject.FindGameObjectWithTag("Chumpa").transform.position;

        if(m_target != null){
            transform.position += transform.forward * Time.deltaTime * Speed;
            transform.LookAt(m_target);
        }
       
    }

    public void OnTriggererEnter(Collider other){
        if(other.gameObject.CompareTag("Chumpa")){
            Destroy(this.gameObject);
        }
    }
}
