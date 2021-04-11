using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPorBase : BaseDeVariables
{
    
    // Start is called before the first frame update
    void Start()
    {
        //Movimiento
        velocidadFB = 15.0f;
        velocidadDI = 10.0f;
        horizontalVelocidad=3f;
        verticalVelocidad=3f;
        
        
        //Cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //Salto
         fuerzaSalto=5f;
         PuedoSaltar=true;
}

    // Update is called once per frame
    void Update()
    {
         
        Movimiento();//Estoy llamando a la funcion movimiento que es la override para que se haga en el update
        
        CamaraJugador();
        Salto();
    }
    public override void Salto()
    {
        base.Salto();
    }
    public override void CamaraJugador()
    {
        base.CamaraJugador();
    }

    public override void Movimiento()
    {
        base.Movimiento();
    }
   
}
