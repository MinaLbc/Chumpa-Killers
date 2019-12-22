using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed;
    private Vector3 m_target;
    public GameObject C_Target;

    
    // Update is called once per frame
    

    public void Update()
    {   
         if(C_Target == null){
            Destroy(this.gameObject);
            return;
        }

        m_target = C_Target.transform.position;

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
