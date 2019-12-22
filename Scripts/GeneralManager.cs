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

    public Vector3 spawnValues;
    public float starWait;
    public float spawnWait;
    public GameObject RockPrefab;


    void Start()
    {   
        StartCoroutine(RessourcesSpawn());

        InvokeRepeating("SpawnChumpas", delay_c, interval_c);
        //2.0f = le temps avant le lancement de la 1ere wave
        //4.0f = le temps entre chaque wave
    }

    IEnumerator RessourcesSpawn()
    {
        yield return new WaitForSeconds(starWait);
        while (true)
        {

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), -130, Random.Range(-spawnValues.z, spawnValues.z));
            //ShootNuage();
            GameObject Ressource_object = Instantiate(RockPrefab, spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            yield return new WaitForSeconds(spawnWait);
        }
    }


    IEnumerator ChumpasSpawn()
    {
        yield return new WaitForSeconds(starWait);
        while (true)
        {
            for(int i=0; i<number_c; i++)
            {
                GameObject ChumpaPrefab_o = Instantiate(ChumpaPrefab, Centre, Quaternion.identity);
                ChumpaPrefab_o.transform.RotateAround(this.transform.position, Vector3.up, Random.Range(0.0f, 360.0f));
            }

            yield return new WaitForSeconds(spawnWait);
        }
    }


    /*public void SpawnChumpas()
    {
        for(int i=0; i<number_c; i++)
        {
            GameObject ChumpaPrefab_o = Instantiate(ChumpaPrefab, Centre, Quaternion.identity);
            ChumpaPrefab_o.transform.RotateAround(this.transform.position, Vector3.up, Random.Range(0.0f, 360.0f));

        }
    }*/


}

