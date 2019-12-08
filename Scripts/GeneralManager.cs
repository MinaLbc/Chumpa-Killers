using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : MonoBehaviour
{
	
    public GameObject ChumpaPrefab;
    public int number_c;
    public Vector3 Centre = new Vector3(0.0f, 1.0f, 40.0f);
    public float delay_c;
    public float interval_c;


    void Start()
    {
        InvokeRepeating("SpawnChumpas", delay_c, interval_c);
        //2.0f = le temps avant le lancement de la 1ere wave
        //4.0f = le temps entre chaque wave
    }

    void SpawnChumpas()
    {
        for(int i=0; i<number_c; i++)
        {
            GameObject ChumpaPrefab_o = Instantiate(ChumpaPrefab, Centre, Quaternion.identity);
            ChumpaPrefab_o.transform.RotateAround(this.transform.position, Vector3.up, Random.Range(0.0f, 360.0f));
        }
    }


}
