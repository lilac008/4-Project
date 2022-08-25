using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  /// 



/// Game Manager(빈 obj,) 생성
/// Canvas - Game Panel - Score Group, Status Group, Stage Group, Enemy Group, Equip Grop, Boss Group, Item Shop Group, Weapon Shop Group 


/// Menu Camera : follow script 삭제, Animation(AddProperty-Transform-Rotation-자세한 값) 생성 후 드래그하면 animator(speed:0.1) 자동생성 / script가 자동 생성되었는지 확인  
/// 




public class GameManager : MonoBehaviour
{

    public GameObject menuCamera;                   /// Menu Camera 드래그
    public GameObject gameCamera;                   /// game Camera 드래그

    public Player player;                           /// Player script 드래그
    public Boss boss;                               /// Boss script 드래그
    public int stage;                               ///4
    public float playTime;
    public bool isBattle;                           ///활성화시 누적시간
    public int enemyCntA;                           ///각각 2,3,5
    public int enemyCntB;                           
    public int enemyCntC;
    public int enemyCntD;
    ///Panel
    public GameObject menuPanel;                    ///Canvas - menuPanel
    public GameObject gamePanel;                    ///Canvas - gamePanel
    public GameObject gameoverPanel;
    /// Score Group
    public Text curScoreText;
    /// Stage Group 
    public Text stageText;                           ///Game Panel - Stage Group - Stage Text 드래그   
    public Text playTimeText;                        ///Game Panel - Stage Group - TimeText 드래그   
    /// Status Group
    public Text playerHealthText;                    ///Game Panel - status group - HealthText
    public Text playerAmmoText;                      ///Game Panel - status group - AmmoText
    public Text playerCoinText;                      ///Game Panel - status group - CoinText
    /// Equip Group
    public Image weapon1Img;                        ///Game Panel - Equip group - Equip1 - weapon1 image
    public Image weapon2Img;                        ///Game Panel - Equip group - Equip2 - weapon2 image
    public Image weapon3Img;                        ///Game Panel - Equip group - Equip3 - weapon3 image
    public Image weaponRImg;                        ///Game Panel - Equip group - Equip4 - weapon4 image
    /// Enemy Group
    public Text enemyAText;                          ///Game Panel - Equip group - enemyAText
    public Text enemyBText;                          ///Game Panel - Equip group - enemyBText
    public Text enemyCText;                          ///Game Panel - Equip group - enemyCText
    /// Boss Group
    public RectTransform bossHealthGroup;           ///Game Panel - Boss group
    public RectTransform bossHealthBar;             ///Game Panel - Boss group - Image - Boss Health Image
    /// GameOver
    public Text bestText;
    public Text maxScoreText;                        ///Menu Panel - Max Score Text
    public Text scoreText;                           ///Game Panel - Score group - Score Text 드래그 


    public GameObject itemShop;
    public GameObject weaponShop;
    public GameObject startZone;
    public GameObject startWall1;
    public GameObject startWall2;
    public GameObject startWall3;
    public GameObject startWall4;
    public GameObject bossMap;

    public Transform[] enemyZone;
    public GameObject[] enemyPrefabs;
    public List<int> enemyList;




    void Awake() ///16강-1
    {
        maxScoreText.text = string.Format("{0:n0}", PlayerPrefs.GetInt("MaxScore"));    ///string.Format() 문자열 양식
        enemyList = new List<int>();

        if (PlayerPrefs.HasKey("MaxScore"))        /// HasKey() 함수로 Key가 있는지 확인 후, 없다면 0으로 저장
            PlayerPrefs.SetInt("MaxScore", 0);
    }


    public void GameStart()  ///16강-2   Menu Panel - Start Button - Button(OnClick-GameManager-GameStart)
    {
        menuCamera.SetActive(false);    ///menu관련 비활성, game관련 활성
        gameCamera.SetActive(true);

        menuPanel.SetActive(false);
        gamePanel.SetActive(true);

        player.gameObject.SetActive(true);

        startWall1.SetActive(true);
        startWall2.SetActive(true);
        startWall3.SetActive(true);
        startWall4.SetActive(true);

    }

    public void StageStart()
    {
        itemShop.SetActive(false);
        weaponShop.SetActive(false);
        startZone.SetActive(false);
        startWall1.SetActive(false);
        startWall2.SetActive(false);
        startWall3.SetActive(false);
        startWall4.SetActive(false);
        foreach (Transform zone in enemyZone) zone.gameObject.SetActive(true);

        isBattle = true;
        StartCoroutine(InBattle());
    }

    public void StageEnd()
    {
        /// 플레이어 재위치
        player.transform.position = Vector3.back * 40f;

        itemShop.SetActive(true);
        weaponShop.SetActive(true);
        startZone.SetActive(true);
        startWall1.SetActive(true);
        startWall2.SetActive(true);
        startWall3.SetActive(true);
        startWall4.SetActive(true);
        foreach (Transform zone in enemyZone) zone.gameObject.SetActive(false);

        isBattle = false;
        stage++;
    }

    IEnumerator InBattle()
    {
        if (stage % 5 == 0)
        {
            enemyCntD++;
            GameObject instantEnemy = Instantiate(enemyPrefabs[3], enemyZone[2].position, enemyZone[2].rotation);
            /// 프리팹화 된 오브젝트들이 플레이어에게(하이어라키) 접근하기 위해 컴포넌트를 가져온다.
            Enemy enemy = instantEnemy.GetComponent<Enemy>();
            enemy.target = player.transform;
            /// Enemy 스크립트에서 감소된 카운트를 가져온다.
            enemy.manager = this;
            boss = instantEnemy.GetComponent<Boss>();

            if (boss) bossMap.SetActive(true);
            else bossMap.SetActive(false);
        }
        else
        {
            for (int i = 0; i < stage; i++)
            {
                int ran = Random.Range(0, 3);
                enemyList.Add(ran);

                switch (ran)
                {
                    case 0:
                        enemyCntA++;
                        break;
                    case 1:
                        enemyCntB++;
                        break;
                    case 2:
                        enemyCntC++;
                        break;
                }
            }

            while (enemyList.Count > 0)
            {
                int ranZone = Random.Range(0, 5);
                GameObject instantEnemy = Instantiate(enemyPrefabs[enemyList[0]], enemyZone[ranZone].position, enemyZone[ranZone].rotation);
                /// 프리팹화 된 오브젝트들이 플레이어에게(하이어라키) 접근하기 위해 컴포넌트를 가져온다.
                Enemy enemy = instantEnemy.GetComponent<Enemy>();
                enemy.target = player.transform;
                /// Enemy 스크립트에서 감소된 카운트를 가져온다.
                enemy.manager = this;
                /// 생성 후에는 사용된 데이터는 RemoveAt() 함수로 삭제
                enemyList.RemoveAt(0);
                /// while문에선 코루틴으로 타이밍 맞추기
                yield return new WaitForSeconds(4f);
            }
        }

        while (enemyCntA + enemyCntB + enemyCntC + enemyCntD > 0)
        {
            yield return null;
        }

        yield return new WaitForSeconds(4f);
        boss = null;
        StageEnd();
    }

    public void GameOver()
    {
        gamePanel.SetActive(false);
        gameoverPanel.SetActive(true);

        curScoreText.text = scoreText.text;

        /// 기존에 저장된 최고점수를 불러와 비교 후 높으면 갱신
        int maxScore = PlayerPrefs.GetInt("MaxScore");
        if (player.score > maxScore)
        {
            bestText.gameObject.SetActive(true);
            PlayerPrefs.SetInt("MaxScore", player.score);
        }
    }

    public void ReStart()
    {
        SceneManager.LoadScene(0);
    }

    void Update()     
    {
        ///16-4 플레이타임  :  deltaTime으로 증가    
        if (isBattle) playTime += Time.deltaTime;
    }


    void LateUpdate()   ///16-3 
    {
        /// 상단 UI
        scoreText.text = string.Format("{0:n0}", player.score);
        stageText.text = "STAGE " + stage;

        ///16-4  플레이타임 : update함수 참조
        int hour = (int)(playTime / 3600);          
        int min = (int)((playTime - hour * 3600) / 60);   
        int second = (int)(playTime % 60);   ///나머지
        playTimeText.text = string.Format("{0:00}", hour) + ":" +
                           string.Format("{0:00}", min) + ":" +
                           string.Format("{0:00}", second);

        ///플레이어 UI
        playerHealthText.text = player.health + " / " + player.maxHealth;
        playerCoinText.text = string.Format("{0:n0}", player.coin);

        ///무기 UI  :  무기 보유상태에 따른 
        if (player.equipWeapon == null) playerAmmoText.text = "- / " + player.ammo;
        else if (player.equipWeapon.type == Weapon.Type.Melee) playerAmmoText.text = "- / " + player.ammo;
        else playerAmmoText.text = player.equipWeapon.curAmmo + " / " + player.ammo;

        ///무기 UI  :  무기 보유 상태에 따라 알파값만 변경
        weapon1Img.color = new Color(1, 1, 1, player.hasWeapons[0] ? 1 : 0);
        weapon2Img.color = new Color(1, 1, 1, player.hasWeapons[1] ? 1 : 0);
        weapon3Img.color = new Color(1, 1, 1, player.hasWeapons[2] ? 1 : 0);
        weaponRImg.color = new Color(1, 1, 1, player.hasGranades > 0 ? 1 : 0);

        ///몬스터수 UI
        enemyAText.text = enemyCntA.ToString();
        enemyBText.text = enemyCntB.ToString();
        enemyCText.text = enemyCntC.ToString();

        ///보스 UI 
        if (boss != null)         /// 보스 변수가 비어있을 때 UI 업데이트 하지 않도록 조건 추가
        {
            bossHealthGroup.anchoredPosition = Vector3.down * 30;
            bossHealthBar.localScale = new Vector3((float)boss.curHelath / boss.maxHelath, 1, 1);         
        }
        else
        {
            bossHealthGroup.anchoredPosition = Vector3.up * 200;
        }
    }





}
