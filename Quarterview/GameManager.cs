using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  /// 


///16강
/// Game Manager(빈 obj,) 생성
/// Canvas - Game Panel - Score Group, Status Group, Stage Group, Enemy Group, Equip Grop, Boss Group, Item Shop Group, Weapon Shop Group 


/// Menu Camera : follow script 삭제, Animation(AddProperty-Transform-Rotation-자세한 값) 생성 후 드래그하면 animator(speed:0.1) 자동생성 / script가 자동 생성되었는지 확인  


///Enemy Zone Group - Enemy Respawn Zone 4개(비활성화) 



public class GameManager : MonoBehaviour
{

    public GameObject menuCamera;                   /// Menu Camera drag
    public GameObject gameCamera;                   /// game Camera drag

    public Player player;                           /// Player script drag
    public Boss boss;                               /// Boss script drag
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
    public Text stageText;                           ///Game Panel - Stage Group - Stage Text  
    public Text playTimeText;                        ///Game Panel - Stage Group - TimeText 
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
    public Text scoreText;                           ///Game Panel - Score group - Score Text


    public GameObject itemShop;                      ///drag
    public GameObject weaponShop;                    ///drag
    public GameObject startZone;                     ///drag
    public GameObject startWall1;
    public GameObject startWall2;
    public GameObject startWall3;
    public GameObject startWall4;
    public GameObject bossMap;

    public Transform[] enemyZone;                    /// Enemy Respawn Zone 4개 drag
    public GameObject[] enemies;                     /// Enemy A/B/C/D prefab drag
    public List<int> enemyList;




    void Awake() ///16-1
    {
        enemyList = new List<int>();                ///17-2


        maxScoreText.text = string.Format("{0:n0}", PlayerPrefs.GetInt("MaxScore"));    ///16-1 string.Format() 문자열 양식

        if (PlayerPrefs.HasKey("MaxScore"))                                             /// HasKey() 함수로 Key가 있는지 확인 후, 없다면 0으로 저장
            PlayerPrefs.SetInt("MaxScore", 0);
    }


    public void GameStart()             ///16-2   Menu Panel - Start Button - Button(OnClick-GameManager-GameStart)
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

    public void GameOver()           
    {


    }

    public void StageStart()  ///17-1
    {
        itemShop.SetActive(false);
        weaponShop.SetActive(false);
        startZone.SetActive(false);
        startWall1.SetActive(false);
        startWall2.SetActive(false);
        startWall3.SetActive(false);
        startWall4.SetActive(false);

        foreach (Transform data in enemyZone) data.gameObject.SetActive(true);  

        isBattle = true;
        StartCoroutine(InBattle());     /// Coroutine으로 소환
    }

    public void StageEnd()  ///17-1
    {
        player.transform.position = Vector3.up * 0.8f;   /// 플레이어 재위치

        itemShop.SetActive(true);
        weaponShop.SetActive(true);
        startZone.SetActive(true);
        startWall1.SetActive(true);
        startWall2.SetActive(true);
        startWall3.SetActive(true);
        startWall4.SetActive(true);

        foreach (Transform data in enemyZone) data.gameObject.SetActive(false);

        isBattle = false;
        stage++;                                        ///스테이지 종료시 stage값 1 증가
    }

    IEnumerator InBattle()   ///17-1 
    {
        if (stage % 5 == 0)  ///stage가 5단위일때
        {
            enemyCntD++;  
            GameObject instantEnemy = Instantiate(enemies[3], enemyZone[0].position, enemyZone[0].rotation);
            Enemy enemy = instantEnemy.GetComponent<Enemy>();            
            enemy.target = player.transform;
            enemy.gameManager = this;                                               
            boss = instantEnemy.GetComponent<Boss>();

            if (boss) bossMap.SetActive(true);
            else bossMap.SetActive(false);
        }
        else
        {
            for (int i = 0; i < stage; i++)       ///17-2
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

            while (enemyList.Count > 0)         ///17-2
            {
                int ranZone = Random.Range(0, 4);
                GameObject instantEnemy = Instantiate(enemies[enemyList[0]], enemyZone[ranZone].position, enemyZone[ranZone].rotation);
                Enemy enemy = instantEnemy.GetComponent<Enemy>();                /// prefab화 된 obj는 scene에 접근할 수 없다.       ///따라서 hierarchy Player에 접근하기 위해 component를 가져옴
                enemy.target = player.transform;
                enemy.gameManager = this;                                        /// Enemy 스크립트에서 감소된 카운트를 가져온다.
                enemyList.RemoveAt(0);                                           /// 생성 후에 사용된 데이터 삭제, nemyList.Count = 0이되면 while문 종료
                yield return new WaitForSeconds(4f);                             ///
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
        if (boss != null)         /// 보스 변수가 비었을때 UI 업데이트 하지 않도록
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
