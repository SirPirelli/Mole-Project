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
    private float activeTimer;


    private bool boxWasHit;
    bool isFading = false;

    /* cores dos sprites para identificação de estado */
    Color idleColor, activeColor, hitColor;

    int BoxId;

    public int BoxID { get { return BoxId; } }
    public bool IsActive { get { return isActive; } }


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();   
    }


    void Start () {
        isActive = false;
        activeTimer = 0;
        boxWasHit = false;

        timeColorChangesAfterHit = 0.2f;

        /* declaração das cores para cada estado */
        idleColor = Color.green;
        activeColor = Color.blue;
        hitColor = Color.magenta;
        /* -------------------------------- */
        // o jogo começa com todos os quadrados com a cor idle
        spriteRenderer.color = idleColor;
    }


    /* tenho que aprender a trabalhar com Events, assim se detectar que o metodo BoxWasHit foi chamado, podemos ativar o timer da mudança de cor apos o hit */
    void Update ()
    {

        if(isActive)
        {
            StartCoroutine("ActivateObjectForCollision");

            if (boxWasHit)
            {
                StopCoroutine("ActivateObjectForCollision");
                StartCoroutine("FlashColor");
            }
        }

    }
    /*-------------------------------------------------------------------*/

    public void BoxWasHit() { boxWasHit = true; }


    //no game manager chamamos esta função para activar o quadrado
    public void SetActive(float timer)
    {
        isActive = true;
        activeTimer = timer;
    }

    //coroutine para mudar a cor do quadrado com o no momento do toque
    IEnumerator FlashColor()
    {
        spriteRenderer.color = hitColor;
        boxWasHit = false;
        isActive = false;
        yield return new WaitForSeconds(timeColorChangesAfterHit);
        spriteRenderer.color = idleColor;
    }


    //coroutine que activa o objecto e tem o timer do tempo activo
    IEnumerator ActivateObjectForCollision()
    {
        spriteRenderer.color = activeColor;
        yield return new WaitForSeconds(activeTimer);
        spriteRenderer.color = idleColor;
        isActive = false;
    }
}
