using System.Collections;
using System.Collections.Generic;
using UnityEngine;




///StartZone (ShopZone복사) : untagged, Shop script삭제, StartZone script 추가, 우클릭추가-3Dobject-3DText(Next Stage)

/// Enemy Zone Group(빈obj) - Enemy Respawn Zone (StartZone 복사 후 collider, script, stage text 전부 제거)
/// 



public class Startzone : MonoBehaviour
{


    public GameManager gameManager;             ///Game Manager drag



    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
            gameManager.StageStart();
    }








}
