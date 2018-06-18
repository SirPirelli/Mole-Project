using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleManager : MonoBehaviour {

    int numOfMoles;
    public MoleBox[] locations;
    

	// Use this for initialization
	void Start () {
        // retorna todos os components do tipo MoleBox (se existirem)
        locations = gameObject.GetComponentsInChildren<MoleBox>();
        if(locations == null) Debug.LogError("CANT FIND MOLE BOXES");
        // o numero de moles e igual ao numero de comp MoleBox que encontra
        else numOfMoles = locations.Length;
        Debug.Log(numOfMoles);
        

    }

    // Update is called once per frame
    void Update () {
		
	}

}
