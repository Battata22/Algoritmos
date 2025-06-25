using System.Collections;
using UnityEngine;

public class TPManager : MonoBehaviour
{
    [SerializeField] Transform[] puntosDeTp;
    [SerializeField] GameObject canvasTp;
    Transform playerTransform;
    ShootingManager shootScript;
    PlayerCameraControl cameraScript;

    [SerializeField] Material _PPTp;
    [SerializeField, Range(0, 1)] int numActive;

    [SerializeField] float temp;

    [SerializeField] float tiempoAjuste;

    private void Start()
    {
        playerTransform = EntitiesManager.Instance.Player.transform;
        shootScript = EntitiesManager.Instance.Player.GetComponent<ShootingManager>();
        cameraScript = EntitiesManager.Instance.Player.GetComponent<PlayerCameraControl>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            canvasTp.SetActive(true);
            shootScript.enabled = false;
            cameraScript.menu = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            canvasTp.SetActive(false);
            shootScript.enabled = true;
            cameraScript.menu = false;
        }

        //--------------------------------------------------------------------------------------------------

        if (temp >= 100)
        {
            temp = 1.2f;
        }

        if (numActive == 0)
        {
            if (temp != 1.2f)
            {
                temp = 1.2f;
            }
            _PPTp.SetFloat("_Activado", 0);
            _PPTp.SetFloat("_Senos", temp);
        }
        else
        {
            temp += Time.deltaTime;
            _PPTp.SetFloat("_Activado", 1);
            _PPTp.SetFloat("_Senos", temp);
        }
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    if (numActive == 0)
        //    {
        //        numActive = 1;
        //    }
        //    else
        //    {
        //        numActive = 0;
        //    }
        //}
        //2.9 pantallazo azul de gonza
        //termina en 4.608348


    }

    public void TP_Base()
    {
        StopCoroutine(TPBase());
        StartCoroutine(TPBase());
    }

    public void TP_Shaders()
    {
        StopCoroutine(TPShaders());
        StartCoroutine(TPShaders());
    }

    public void TP_Niveles()
    {
        StopCoroutine(TPNiveles());
        StartCoroutine(TPNiveles());
    }

    IEnumerator TPBase()
    {
        //activar shader
        numActive = 1;

        //esperar el tiempo a la mitad
        yield return new WaitForSeconds(tiempoAjuste);

        //tp player
        playerTransform.position = puntosDeTp[0].position;

        //esperar al final
        yield return new WaitForSeconds(tiempoAjuste);

        //apagar shader
        numActive = 0;
    }

    IEnumerator TPShaders()
    {
        //activar shader
        numActive = 1;

        //esperar el tiempo a la mitad
        yield return new WaitForSeconds(tiempoAjuste);

        //tp player
        playerTransform.position = puntosDeTp[1].position;

        //esperar al final
        yield return new WaitForSeconds(tiempoAjuste);

        //apagar shader
        numActive = 0;
    }

    IEnumerator TPNiveles()
    {
        //activar shader
        numActive = 1;

        //esperar el tiempo a la mitad
        yield return new WaitForSeconds(tiempoAjuste);

        //tp player
        playerTransform.position = puntosDeTp[2].position;

        //esperar al final
        yield return new WaitForSeconds(tiempoAjuste);

        //apagar shader
        numActive = 0;
    }

    public void Sorpresa()
    {
        Application.Quit();
    }
}
