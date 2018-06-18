using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleBox : MonoBehaviour {

    /* isActive determina se box pode ser colidida */
    bool isActive;
    private Rigidbody2D rb;

    [HideInInspector]public BoxCollider2D boxCollider;
    [HideInInspector]public float timeColorChangesAfterHit; //tentar utilizar uma coroutine para este timer (?)

    SpriteRenderer spriteRenderer;

    /* tempo q o objecto esta activo (nao sei se essa informaçao estara aqui ou no game manager */
    private float timer;

    private bool boxWasHit;

    /* cores dos sprites para identificação de estado */
    Color idleColor, activeColor, hitColor;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    void Start () {
        isActive = false;
        timer = 0;
        boxWasHit = false;

        /* declaração das cores para cada estado */
        idleColor = Color.green;
        activeColor = Color.blue;
        hitColor = Color.yellow;
        /* -------------------------------- */
        spriteRenderer.color = idleColor;
    }
	
	void Update () {	

        /* tenho que aprender a trabalhar com Events, assim se detectar que o metodo BoxWasHit foi chamado, podemos ativar o timer da mudança de cor apos o hit */
	}

    public void BoxWasHit()
    {
        spriteRenderer.color = hitColor;
        boxWasHit = true;
    }
}
