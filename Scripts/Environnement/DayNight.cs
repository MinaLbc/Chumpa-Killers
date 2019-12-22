using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
	public float Speed;
    private float Rotation;
    private bool Jour;

    public GameObject ChumpaPrefab;
    public int number_c;
    public Vector3 Centre = new Vector3(0.0f, 1.0f, 40.0f);

    public float Timer_N;
    private float Timer_J;
    public float Timer_JJ;
    public float Timer_NN;

    public Vector3 spawnValues;
    public GameObject RockPrefab;

    public int IncR;
    public int IncC;
    public int JCount;


    void Start()
    {
        //Night = 116- (-56) degrés
        Jour = true;
        Timer_J = 0.0f;
        Timer_N = 0.0f;
        
        JCount = 0;
        
        

    }




    void Update()
    {
        this.transform.Rotate(Vector3.right * Time.deltaTime * Speed);

        Rotation = (this.transform.rotation.eulerAngles.x);

        //if (Rotation = 80){
          //  JCount = JCount + 1;
        //}


        if(Rotation < 80 && Rotation > -20){
            Jour = true;
            
            Debug.Log("Jour");
            Timer_J = Timer_J + Time.deltaTime;

            if(Timer_J >= Timer_JJ){
                RessourcesSpawn();
            }
        }

        if(Rotation > 80 || Rotation < -20){
            Jour = false;
            Debug.Log("Nuit");

            Timer_N = Timer_N + Time.deltaTime;
            if(Timer_N >= Timer_NN){
                ChumpasSpawn();
            }
        }
    }





    public void RessourcesSpawn()
    {

        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), -130, Random.Range(-spawnValues.z, spawnValues.z));
        GameObject Ressource_object = Instantiate(RockPrefab, spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
        Timer_J = 0.0f;
    }

    public void ChumpasSpawn()
    {
        Debug.Log("chumpa spawn");


        for(int i=0; i<number_c; i++)
        {
            GameObject ChumpaPrefab_o = Instantiate(ChumpaPrefab, Centre, Quaternion.identity);
            ChumpaPrefab_o.transform.RotateAround(this.transform.position, Vector3.up, Random.Range(0.0f, 360.0f));
        }

        Timer_N = 0.0f;

    }
}



    

    


