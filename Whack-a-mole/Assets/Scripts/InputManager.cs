using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    #region Properties

    Touch[] touchesInAFrame;

    #endregion

    #region Fields

    public Touch[] TouchesInAFrame { get { return touchesInAFrame; } }

    #endregion

    private void Awake()
    {
    }

    // Use this for initialization
    void Start () {

	}
	
	void Update ()
    {

        //temos q ir buscar os toques no update do input manager, é codigo mais correcto do que ficar no Game Manager
        //para isso a variavel touches tem que ser publica pq precisamos de ir buscar a informação

        if (IsTouchingOnScreen()) touchesInAFrame = GetTouchesOnScreen();
        else touchesInAFrame = null;

    }


    //devolve os toques no touchscreen numa determinada frame
    public Touch[] GetTouchesOnScreen()
    {
        return Input.touches;
    }

    //confirma se esta a haver toques no touchscreen
    public bool IsTouchingOnScreen()
    {
        if (Input.touchCount > 0) return true;

        return false;
    }
}
