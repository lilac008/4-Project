using System.Collections;
using System.Collections.Generic;
using UnityEngine;




///Start Zone (shop zone 복사) : untagged, shop script삭제, StartZone script 연결, 우클릭추가-3Dobject-3DText(Next Stage)





public class Startzone : MonoBehaviour
{


    public GameManager gameManager;             ///Game Manager drag





    private void OnTriggerEnter(Collider collider) 
    {
        if(collider.gameObject.tag == "Player")
            gameManager.StageStart();


        
    }








}
