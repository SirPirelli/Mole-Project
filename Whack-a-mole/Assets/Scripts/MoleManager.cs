using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleManager : MonoBehaviour {

    int numOfMoles;
    public MoleBox[] locations;
    List<MoleBox> activeLocationsList;
    int numOfActiveMoles;

    bool coroutineHasStarted;

	// Use this for initialization
	void Start ()
    {
       
        // retorna todos os components do tipo MoleBox (se existirem)
        locations = gameObject.GetComponentsInChildren<MoleBox>();
        if(locations == null) Debug.LogError("CANT FIND MOLE BOXES");
        // o numero de moles e igual ao numero de comp MoleBox que encontra
        else numOfMoles = locations.Length;

        numOfActiveMoles = 0;
        activeLocationsList = new List<MoleBox>();

        //flag to check if coroutine has started
        coroutineHasStarted = false;

    }

    // Update is called once per frame
    void Update ()
    {
        if(!coroutineHasStarted)
        {
            StartCoroutine("ChooseBoxToActivate");
            coroutineHasStarted = true;
        }


    }

    IEnumerator ChooseBoxToActivate()
    {

        int index = Random.Range(0, numOfMoles);
        float timer = Random.Range(2f, 4f);

        MoleBox m = locations[index];

        if (!m.IsActive)
        {
            m.SetActive(timer);
            yield return new WaitForSeconds(1.5f);
        }
        else yield return new WaitForSeconds(1.5f);
        coroutineHasStarted = false;
       
    }
}
