using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;               ///NavMeshAgent


/// Enemy D (보스)
/// 1. Animator 지정 (영상 13부 참고, Entry - Idle,  AnyState - tDie, tShot, tBigShot, tTaunt - Exit(has Exit Time )), 
/// 2. Enemy D - rigidbody(FreezeR x,z), boxCollider(center(0,2,0),size(3.7 x 3)), Nav Mesh Agent(Speed:40,AngularSpeed:0,Acceleration:60), Tag/Layer Enemy 추가
/// 3. Enemy D - Missile PortA/B 2개(빈obj, A(2,2,1), B(-2,2,1))
/// 4. Enemy D - MeleeArea(빈obj/ Box Collider(공격범위,center(0,(0.5),0),size(3.5,0.5,3.5),isTrigger,비활성화), Tag/Layer:EnemyBullet 추가 ) 

/// Missile Boss : Bullet 상속
/// 1. Missile Boss(Tag/Layer:EnemyBullet, rigidbody(UseGravity해제), BoxCollider( C(0,4,0),R(2.5,2.5,3.5),isTrigger), Nav Agent(speed:35,Ang:360,Acc:30) 추가 )
/// 2. Missile Boss - Mesh Obj(Transform.R(0,-90,0), S(0.4 x3)) - Missile script(자전) 연결 후 아래 설정 추가 
/// 3. Missile Boss - Effect(빈obj, component에 Particle System( Renderer:DefaultL, Shape(Ang:10,Rad:0.6,Rot:(0,180,0)), Color(alpha:100), SOL:역방향, Effect(SLifetime:1, SSpeed:10, SSize:0.9, SimulationSpace:World ), Emission(RoT:30) )추가 
/// 4. frefab화




public class BossMissile : Bullet   ///상속 
{
    /// public int damage;          ///(Bullet script에서 상속) MissileBoss:12
    public Transform target;        /// Player 드래그
    NavMeshAgent nav;


    void Awake() 
    {
        nav = GetComponent<NavMeshAgent>();
        
    }


    void Update() 
    {
        nav.SetDestination(target.position);
    }







}
