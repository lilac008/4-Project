using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;  ///NavMeshAgent


// c.tag  / c.gameObject.tag 차이
// startCoroutine()에서 yield return의 의미
// update() - nav.isStopped 
// Targeting() - rayHits.Length



/// TestEnemy(Cube obj) : 1. Rigidbody(Freeze Rotation:x,z), Box Collider, Enemy script 설정
///                       2. Layer : 13:Enemy, 14:EnemyDead(Floor, Wall, EnemyDead 외 전부 해제) 추가


/// Enemy A (일반형)
/// 1. Rigidbody(FreezeRotation x,z 활성화), Box Collider(center(y:1.13),size(2.5,2.5,2.5)), Enemy Script 추가 후 아래 설정, Tag/Layer : Enemy 추가 후 Project Setting - Physics - LayerCollisionMask(EnemyBullet-Enemy 비활성화) 
/// 2. Nav Mesh Agent(AngularSpeed(회전속도):360, Acceleration(가속도):30) 추가 / Floor,Wall : Static 설정(static만 bake가능) / Window - AI - Navigation - Bake - Advanced:Bake  (NavMesh는 NavAgent가 경로를 그리기 위한 바탕, NavMeshAgent는 navigation을 사용하는 AI)
/// 3. Mesh Obj - Animator(Enemy A) 추가, 애니메이션 Idle(우클릭-SetAsLayerDefaultState), Walk, Attack, Die 추가 (영상11부 12분 참조), bWalk, bAttack, tDie
/// 4. 아래의 Enemy Bullet 추가 후 Enemy A 정면 앞에 배치
/// EnemyA/B/C/D 위치 초기화 후 prefab


/// Enemy B (돌격형) : 1. Enemy A 따라서 그대로 복사
///                    2. Nav Mesh Agent (speed:20, AngularSpeed:360, Acceleration:50) 


/// Enemy C (원거리) : 1. Enemy A 따라서 그대로 복사
///                    2. NavMeshAgent (speed:5, AngularSpeed:480, Acceleration:60) 
///                    3. Enemy Script의 Melee Area는 비워둠, Animator의 애니메이션은 모두 교체 


/// EnemyBullet(빈 obj) : 근접공격범위
///                       1. Box Collider(isTrigger, size:2,2,2, boxCollider 비활성화) + Tag/Layer:EnemyBullet + Bullet Script 추가


/// Missile (Transform:P/R(0,0,0))   (영상 12부 34분 참조, z축(blue) 각도 참조)
///                                  1. Missile - Mesh obj(Transform P(0,0,0), R(0,-90,0)) - Missile script 추가 
///                                  2. Missile - Effect(빈obj, 꼬리부분위치, Transform.P(0,3,-1)) - Particle System (Renderer:Default-Line, Effect(startLifetime:0.6,startSpeed:15,startSize:0.7), Emission(RoT:30), Shape(Angle:13, Radius:0.5, Rotation(0,180,0)), ColorOverLifetime(alpha:100), sizeOverLifetime:역방향) 추가
///                                  3. Missile - Rigidbody(useGravity 해제),  Box Collider(피격범위, center(0,3,0), size(2,2,2), isTrigger, Bullet script(damage:15), Tag/Layer:EnemyBullet 후 Prefab 등록
///                                  4. Open prefab(Tranform(0,0,0), )







public class Enemy : MonoBehaviour
{

    public enum Type { A, B, C, D };   /// 타입나누기
    public Type enemyType;             /// 타입 지정할 변수 생성
    public int maxHealth;              /// TestEnemy:200, EnemyA:50, EnemyB:80, EnemyC:200
    public int curHealth;              /// TestEnemy:200, EnemyA:50, EnemyB:80, EnemyC:200
    public int score;                  /// EnemyA:100, B:250, C:500, D:2000
    public Transform target;           /// Player 드래그
    public BoxCollider meleeArea;      /// 공격범위 : EnemyA의 EnemyBullet 드래그
    public GameObject bullet;          /// EnemyC에 Missile prefab 드래그
    public GameObject[] coins;         /// EnemyA/B/C/D -> coin prefab 3개
    public bool isChase;
    public bool isAttack;              
    public bool isDead;                /// 죽었을 때를 알기 위한 flag

    public Rigidbody r;
    public BoxCollider bCollider;
    public MeshRenderer[] meshs;
    public NavMeshAgent nav;
    public Animator ani;







    void Awake()
    {
        r = GetComponent<Rigidbody>();
        bCollider = GetComponent<BoxCollider>();
        ///m = GetComponentInChildren<MeshRenderer>().material;     /// InChildren : 16 EnemyA - Mesh Obj - Bone Body - Body에 Mesh Rendere가 있음 
        meshs = GetComponentsInChildren<MeshRenderer>().material;   ///21미정 : GetComponents
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponentInChildren<Animator>();

        if(enemyType != Type.D)                         ///20미정  
            Invoke("ChaseStart", 2);                    ///16-3
    }


    void Update() 
    {

        if (nav.enabled && enemyType != Type.D)      ///20미정 &&이하 조건 추가
        {
            nav.SetDestination(target.position);    ///16 player 추적
            nav.isStopped = !isChase;               ///isStopped에 추적 아님을 저장하라?
        }



    }

    void FixedUpdate()  
    {
        Targeting();
        FreezeVelocity();
    }

    void Targeting()                        ///18 
    {
        if (!isDead && enemyType != Type.D)            ///  (죽지 않았으면) && (보스몹이 아니면,20미정)
        {
            float targetRadius = 0f;
            float targetRange = 0f;

            switch (enemyType)
            {
                case Type.A:
                    targetRadius = 1.5f;
                    targetRange = 3f;
                    break;
                case Type.B:
                    targetRadius = 1f;
                    targetRange = 12f;
                    break;
                case Type.C:
                    targetRadius = 0.5f;
                    targetRange = 25f;
                    break;
            }

            /// 배열 - SphereCastAll,       SphereCastAll(시작점, 구체반지름, 진행방향, 범위/거리, Layer) : 구체 모양의 raycasting(모든 obj)
            RaycastHit[] rayHits = Physics.SphereCastAll(transform.position,
                                                         targetRadius,
                                                         transform.forward,
                                                         targetRange,
                                                         LayerMask.GetMask("Player"));

            if (rayHits.Length > 0 && !isAttack)        /// !isAttack : 연속공격 방지
            {
                StartCoroutine(Attack());
            }

        }
    }



    void ChaseStart()                               ///16-3
    {
        isChase = true;
        ani.SetBool("bWalk", true);

    }

    void FreezeVelocity()   ///16-2 Enemy의 NavAgent이동을 물리력(rigid)이 방해하지 않도록 로직 추가 
    {
        if (isChase)                             ///16-3
        {
            r.velocity = Vector3.zero;           ///물리속도 0
            r.angularVelocity = Vector3.zero;    ///물리회전속도 0
        }
    }


    void OnTriggerEnter(Collider c)             ///13
    {
        if (c.tag == "Melee")
        {
            Weapon weapon = c.GetComponent<Weapon>();
            curHealth -= weapon.damage;
            Vector3 reactVec = transform.position - c.transfrom.position;  ///13-2 넉백? 현 위치 - 피격위치

            startCoroutine(OnDamage(reactVec, false));                     ///13-2넉백

            Debug.Log("Melee:" + curHealth);
        }
        else if (c.tag == "Bullet")
        {
            Bullet bullet = c.GetComponent<Bullet>();
            curHealth -= bullet.damage;
            Vector3 reactVec = transform.position - c.transfrom.position; ///13-2 넉백 
            Destroy(c.gameObject);

            startCoroutine(OnDamage(reactVec, false));                    ///13-2넉백

            Debug.Log("Range:" + curHealth);
        }
    }



    public void HitByGrenade(Vector3 explosionPos) ///15
    {
        curHealth -= 100;
        Vector3 reactVec = transform.position - explosionPos;
        StartCoroutine(OnDamage(reactVec, true));
    }

    IEnumerator Attack() ///18
    { 
        isChase = false;                 ///쫓아오기 비활성화
        isAttack = true;                 ///공격 활성화
        ani.SetBool("bAttack", true);    ///공격 애니메이션 활성화

        switch (enemyType)
        {
            case Type.A: 
                yield return new WaitForSeconds(0.2f);
                meleeArea.enabled = true;

                yield return new WaitForSeconds(1f);
                meleeArea.enabled = false;

                yield return new WaitForSeconds(1f);
                break;
            case Type.B:
                yield return new WaitForSeconds(0.1f);
                r.AddForce(transform.forward * 20, ForceMode.Impulse); ///돌격
                meleeArea.enabled = true;

                yield return new WaitForSeconds(0.5f);
                r.velocity = Vector3.zero;                            ///속도제어
                meleeArea.enabled = false;

                yield return new WaitForSeconds(2f);
                break;
            case Type.C:
                yield return new WaitForSeconds(0.5f);
                GameObject instantBullet = Instantiate(bullet, transform.position, transform.rotation);
                Rigidbody rbIB = instantBullet.GetComponent<Rigidbody>();
                rbIB.velocity = transform.forward * 20;

                yield return new WaitForSeconds(2f);
                break;
        }

        isChase = true;                 ///쫓아오기 활성화
        isAttack = false;               ///공격 비활성화
        ani.SetBool("bAttack", false);  ///공격 애니메이션 비활성화
    }


    IEnumerator OnDamage(Vector3 reactVec, bool isGrenade)      ///13,  15 bool isGrenade
    {
        foreach (MeshRenderer mesh in meshs)                         ///21미정
            mesh.material.color = Color.red;

        yield return new WaitForSeconds(0.1f);                      

        if (curHealth > 0)
        {
            foreach (MeshRenderer mesh in meshs)                    ///21미정
                mesh.material.color = Color.white;
        }
        else                             ///체력<0
        {
            foreach (MeshRenderer mesh in meshs)                    ///21미정
                mesh.material.color = Color.gray;


            gameObject.layer = 14;       ///14:EnemyDead 충돌해제 (edit-ProjectSetting-Physics-LayerCollisionMatrix 에서 Enemy Dead와 겹치는 부분에서 Floor,Wall,Enemy Dead 외 전부 충돌 해제)
            isDead = true;               ///
            isChase = false;             ///16-3 추적 비활성화
            nav.enabled = false;         ///16-3 nav 비활성화
            ani.SetTrigger("tDie");      ///16-3 사망 애니메이션

            Player player = target.GetComponent<Player>();                          /// 17강-1
            player.score += score;                                                  /// 
            int ranCoin = Random.Range(0, 3);                                       ///
            Instantiate(coins[ranCoin], transform.position, Quaternion.identity);   ///회전제로?

            if (isGrenade)
            {
                reactVec = reactVec.normalized;                             
                reactVec += Vector3.up *3;                               ///15 enemy의 수류탄사망리액션

                r.freezeRotation = false;                                ///FreezeRotation x,z축 해제
                r.AddForce(reactVec * 5, ForceMode.Impulse);
                r.AddTorque(reactVec * 10, ForceMode.Impulse);           ///회전

            }
            else 
            {
                reactVec = reactVec.normalized;                          ///13-2 넉백
                reactVec += Vector3.up;                                  ///13-2 넉백

                r.AddForce(reactVec * 5, ForceMode.Impulse);
            }

            ///if(enemyType != Type.D)                                      ///17강-1 보스도 조건에 따라 삭제
                Destroy(gameObject, 4);


        }


    }


}
