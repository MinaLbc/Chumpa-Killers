using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
	public static int FCount;
    public TextMesh FCountText;

    public GameObject[] Fields;

    void Start()
    {
        FCount = 0;
        SetFCountText();
    }


    void Update()
    {

        for (int i=0; i< Fields.Length; i++){

            if (Fields[i].GetComponent<Flower>().FlowerOn == true){

                Fields[i].GetComponent<Flower>().FlowerOn = false;
                FCount += 1;

                SetFCountText();
            }
        }
    }


    void SetFCountText(){
        FCountText.text = FCount.ToString();
        Debug.Log("floweeeer");
    }
}
