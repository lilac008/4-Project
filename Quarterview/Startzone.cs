using System.Collections;
using System.Collections.Generic;
using UnityEngine;




///Start Zone (shop zone ����) : untagged, shop script����, StartZone script ����, ��Ŭ���߰�-3Dobject-3DText(Next Stage)





public class Startzone : MonoBehaviour
{


    public GameManager gameManager;             ///Game Manager drag





    private void OnTriggerEnter(Collider collider) 
    {
        if(collider.gameObject.tag == "Player")
            gameManager.StageStart();


        
    }








}
