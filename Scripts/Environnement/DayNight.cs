using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{

	public Light Sun;
	public Light Moon;
	public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        //Night = 116- (-56) degrés
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.right * Time.deltaTime * Speed);
    }
}
