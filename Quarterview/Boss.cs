using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;           ///NavMeshAgent


/// Enemy D(보스)
/// 1. Animator 지정 (영상 13부 참고, Entry - Idle,  AnyState - tDie, tShot, tBigShot, tTaunt - Exit(has Exit Time )), 
/// 2. Enemy D - rigidbody(FreezeR x,z),  boxCollider(center(0,2,0),size(3.7 x 3)),  Nav Mesh Agent(Speed:40,AngularSpeed:0,Acceleration:60),  Tag/Layer Enemy,   Boss script 추가
/// 3. Enemy D - Mesh Obj - Missile PortA/B 2개(빈obj, A(2,2,1), B(-2,2,1))
/// 4. Enemy D - Mesh Obj - BossMeleeArea(빈obj/  Box Collider(공격범위,center(0,(0.5),0),size(3.5,0.5,3.5),isTrigger,비활성화, bullet script 추가 후 Damage:20, is Melee활성화), Tag/Layer:EnemyBullet 추가 ) 
///
/// Enemy D script 설정 
/// EnemyType:D, maxH:100, curH:100, target:player드래그,  MeleeArea:(EmeyD-MeshObj-)MeleeArea 드래그,  Bullet:BossRock(prefab) 드래그,  Missile:BossMissile(prefab) 드래그,  MissilePort A/B:(EmeyD-MeshObj-)MissilePortA/B 드래그, isLook 활성화(player를 향하도록) 








public class Boss : Enemy   ///상속
{
    public GameObject missile;
    public Transform missilePortA;
    public Transform missilePortB;
    public bool isLook;

    Vector3 lookVec;                     ///player움직임 예측
    Vector3 tauntVec;                    ///player움직임 예측





    void Awake() ///Awake 함수는 자식 script에만 위임???
    {
        ///UnassignedReforenceException : The variable anim of Boss has not been assigned. You probably need to assign the anim variable of the Boss script in the inspector.
        r = GetComponent<Rigidbody>();                              ///Enemy에서 상속
        bCollider = GetComponent<BoxCollider>();                    ///Enemy에서 상속
        meshs = GetComponentsInChildren<MeshRenderer>().material;   ///Enemy에서 상속    
        nav = GetComponent<NavMeshAgent>();                         ///Enemy에서 상속
        ani = GetComponentInChildren<Animator>();                   ///Enemy에서 상속

        nav.isStopped = true;                                       ///
        StartCoroutine(Think()); 
    }



    void Update() 
    {
        if (isDead)
        {
            StopAllCoroutines();                     ///모든 코루틴 멈춤
            return;                                  ///아래 반복문이 실행되지 않도록 빠져나가기
        }
        if (isLook) ///바라보는 중이면
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            lookVec = new Vector3(h, 0, v) * 5f;
            transform.LookAt(target.position + lookVec);    ///Enemy D가 보는 방향 = player위치(Enemy script의 target) + lookVec(player가 움직이는 방향의 5배 앞서서)
        }
        else
            nav.SetDestination(tauntVec);                   ///tauntVec방향으로 따라가라 - 점프공격시 목표지점으로 이동

        IEnumerator Think() 
        { 
            yield return new WaitForSeconds(0.1f);

            int ranAction = Random.Range(0, 5);
            switch (ranAction)
            {
                case 0:
                case 1:
                    StartCoroutine(MissileShot());              ///미사일 발사패턴
                    break;
                case 2:
                case 3:
                    StartCoroutine(RockShot());                 ///돌 굴러가는 패턴
                    break;
                case 4:
                    StartCoroutine(Taunt());                    ///점프 공격 패턴
                    break;
            }

        }


        IEnumerator MissileShot() ///미사일샷
        {
            ani.SetTrigger("tShot");                         ///Enemy에서 상속
            yield return new WaitForSeconds(0.2f);
            GameObject instantMissileA = Instantiate(missile, missilePortA.position, missilePortA.rotation);
            BossMissile bossMissileA = instantMissileA.GetComponent<BossMissile>();
            bossMissileA.target = target;

            yield return new WaitForSeconds(0.3f);          ///0.5초에는 a,b 두발 
            GameObject instantMissileB = Instantiate(missile, missilePortB.position, missilePortB.rotation);
            BossMissile bossMissileB = instantMissileB.GetComponent<BossMissile>();
            bossMissileB.target = target;

            yield return new WaitForSeconds(2f);           ///다합해서 2.5초 정도 나오도록
            StartCoroutine(Think());
        }

        IEnumerator RockShot()  ///돌굴리기샷
        {
            isLook = false;                                              ///기 모을때는 바라보기 중지
            ani.SetTrigger("tRock");                                     ///Enemy에서 상속
            Instantiate(bullet, transform.position, transform.rotation);    
            yield return new WaitForSeconds(3f);

            isLook = true;
            StartCoroutine(Think());
        }

        IEnumerator Taunt()     ///점프 후 내려찍기
        {
            tauntVec = target.position + lookVect;            ///점프 공격할 위치

            isLook = false;                                   ///player를 바라보면 이상하니까 tauntVec지점으로만 바라보게
            nav.isStopped = false;                            ///
            bCollider.enabled = false;                        ///player를 밀지 않도록 충돌 비활성화
            ani.SetTrigger("tTaunt");

            yield return new WaitForSeconds(1.5f);
            meleeArea.enabled = true;                        ///공격범위 활성화

            yield return new WaitForSeconds(0.5f);
            meleeArea.enabled = false;                       ///공격범위 비활성화  

            yield return new WaitForSeconds(1f);
            isLook = true;                                   
            nav.isStopped = true;                            ///
            bCollider.enabled = true;                       
            StartCoroutine(Think());
        }





    }


}
