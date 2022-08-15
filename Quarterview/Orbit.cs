using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    /// 1) G Group(��obj) - Front/Back/Right/Left(���� ��obj)�� grenade prefab �߰�  
    /// 2) Front/Back/Right/Left - ���� mesh obj�� ���� Light, Particle ( Emission - RoT:0, RoD:10 ) �߰�, Mesh Object - Simulation Space - World ����
    /// 3) Front/Back/Right/Left�� Orbit script �߰�, Inspector - target: Player����, - orbit Speed: 20 ���� 
    /// 4) Front/Back/Right/Left(���� ��obj) - grenades prefab�� Player - player script - Grenades - size�� ���� �� ��Ȱ��ȭ. 





    public Transform target;             /// Player
    public float orbitSpeed;             /// �����ӵ� : 20
    Vector3 offset;                     



    void Start()
    {
        offset = transform.position - target.position;                                     /// (�Ÿ�)������ = ����ź ������ ��ġ - �÷��̾� ��ġ �� �ʱⰪ ����,  target.position���� ��� ����(�÷��̾ �����̱� ���� �������� �����ع����µ� ���� �÷��̾ ������������ �׸�ŭ �Ÿ��� ����) 
    }


    void Update()
    {
        transform.position = target.position + offset;      

        transform.RotateAround(target.position, Vector3.up, orbitSpeed * Time.deltaTime); ///transform.RotateAround(��ǥ��ġ, ȸ����, �ӵ� * T.dT) : ��ǥ ������ ȸ��

        offset = transform.position - target.position;                                    ///�ʱⰪ �缳��    
    }





}
