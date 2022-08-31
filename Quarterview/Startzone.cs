using System.Collections;
using System.Collections.Generic;
using UnityEngine;




///StartZone (ShopZone����) : untagged, Shop script����, StartZone script �߰�, ��Ŭ���߰�-3Dobject-3DText(Next Stage)

/// Enemy Zone Group(��obj) - Enemy Respawn Zone (StartZone ���� �� collider, script, stage text ���� ����)
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
