using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;               ///NavMeshAgent


/// Enemy D (����)
/// 1. Animator ���� (���� 13�� ����, Entry - Idle,  AnyState - tDie, tShot, tBigShot, tTaunt - Exit(has Exit Time )), 
/// 2. Enemy D - rigidbody(FreezeR x,z), boxCollider(center(0,2,0),size(3.7 x 3)), Nav Mesh Agent(Speed:40,AngularSpeed:0,Acceleration:60), Tag/Layer Enemy �߰�
/// 3. Enemy D - Missile PortA/B 2��(��obj, A(2,2,1), B(-2,2,1))
/// 4. Enemy D - MeleeArea(��obj/ Box Collider(���ݹ���,center(0,(0.5),0),size(3.5,0.5,3.5),isTrigger,��Ȱ��ȭ), Tag/Layer:EnemyBullet �߰� ) 

/// Missile Boss : Bullet ���
/// 1. Missile Boss(Tag/Layer:EnemyBullet, rigidbody(UseGravity����), BoxCollider( C(0,4,0),R(2.5,2.5,3.5),isTrigger), Nav Agent(speed:35,Ang:360,Acc:30) �߰� )
/// 2. Missile Boss - Mesh Obj(Transform.R(0,-90,0), S(0.4 x3)) - Missile script(����) ���� �� �Ʒ� ���� �߰� 
/// 3. Missile Boss - Effect(��obj, component�� Particle System( Renderer:DefaultL, Shape(Ang:10,Rad:0.6,Rot:(0,180,0)), Color(alpha:100), SOL:������, Effect(SLifetime:1, SSpeed:10, SSize:0.9, SimulationSpace:World ), Emission(RoT:30) )�߰� 
/// 4. frefabȭ




public class BossMissile : Bullet   ///��� 
{
    /// public int damage;          ///(Bullet script���� ���) MissileBoss:12
    public Transform target;        /// Player �巡��
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
