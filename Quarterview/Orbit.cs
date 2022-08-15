using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    /// 1) G Group(빈obj) - Front/Back/Right/Left(각각 빈obj)에 grenade prefab 추가  
    /// 2) Front/Back/Right/Left - 하위 mesh obj에 각각 Light, Particle ( Emission - RoT:0, RoD:10 ) 추가, Mesh Object - Simulation Space - World 설정
    /// 3) Front/Back/Right/Left에 Orbit script 추가, Inspector - target: Player연결, - orbit Speed: 20 설정 
    /// 4) Front/Back/Right/Left(각각 빈obj) - grenades prefab를 Player - player script - Grenades - size에 넣은 후 비활성화. 





    public Transform target;             /// Player
    public float orbitSpeed;             /// 공전속도 : 20
    Vector3 offset;                     



    void Start()
    {
        offset = transform.position - target.position;                                     /// (거리)보정값 = 수류탄 개개의 위치 - 플레이어 위치 로 초기값 설정,  target.position에서 벗어남 방지(플레이어가 움직이기 전을 기준으로 공전해버리는데 이후 플레이어가 움직여버리면 그만큼 거리가 생김) 
    }


    void Update()
    {
        transform.position = target.position + offset;      

        transform.RotateAround(target.position, Vector3.up, orbitSpeed * Time.deltaTime); ///transform.RotateAround(목표위치, 회전축, 속도 * T.dT) : 목표 주위를 회전

        offset = transform.position - target.position;                                    ///초기값 재설정    
    }





}
