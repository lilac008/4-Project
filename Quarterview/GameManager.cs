using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  /// 



/// Game Manager(�� obj,) ����
/// Canvas - Game Panel - Score Group, Status Group, Stage Group, Enemy Group, Equip Grop, Boss Group, Item Shop Group, Weapon Shop Group 


/// Menu Camera : follow script ����, Animation(AddProperty-Transform-Rotation-�ڼ��� ��) ���� �� �巡���ϸ� animator(speed:0.1) �ڵ����� / script�� �ڵ� �����Ǿ����� Ȯ��  
/// 




public class GameManager : MonoBehaviour
{

    public GameObject menuCamera;                   /// Menu Camera �巡��
    public GameObject gameCamera;                   /// game Camera �巡��

    public Player player;                           /// Player script �巡��
    public Boss boss;                               /// Boss script �巡��
    public int stage;                               ///4
    public float playTime;
    public bool isBattle;                           ///Ȱ��ȭ�� �����ð�
    public int enemyCntA;                           ///���� 2,3,5
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
    public Text stageText;                           ///Game Panel - Stage Group - Stage Text �巡��   
    public Text playTimeText;                        ///Game Panel - Stage Group - TimeText �巡��   
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
    public Text scoreText;                           ///Game Panel - Score group - Score Text �巡�� 


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




    void Awake() ///16��-1
    {
        maxScoreText.text = string.Format("{0:n0}", PlayerPrefs.GetInt("MaxScore"));    ///string.Format() ���ڿ� ���
        enemyList = new List<int>();

        if (PlayerPrefs.HasKey("MaxScore"))        /// HasKey() �Լ��� Key�� �ִ��� Ȯ�� ��, ���ٸ� 0���� ����
            PlayerPrefs.SetInt("MaxScore", 0);
    }


    public void GameStart()  ///16��-2   Menu Panel - Start Button - Button(OnClick-GameManager-GameStart)
    {
        menuCamera.SetActive(false);    ///menu���� ��Ȱ��, game���� Ȱ��
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
        /// �÷��̾� ����ġ
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
            /// ������ȭ �� ������Ʈ���� �÷��̾��(���̾��Ű) �����ϱ� ���� ������Ʈ�� �����´�.
            Enemy enemy = instantEnemy.GetComponent<Enemy>();
            enemy.target = player.transform;
            /// Enemy ��ũ��Ʈ���� ���ҵ� ī��Ʈ�� �����´�.
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
                /// ������ȭ �� ������Ʈ���� �÷��̾��(���̾��Ű) �����ϱ� ���� ������Ʈ�� �����´�.
                Enemy enemy = instantEnemy.GetComponent<Enemy>();
                enemy.target = player.transform;
                /// Enemy ��ũ��Ʈ���� ���ҵ� ī��Ʈ�� �����´�.
                enemy.manager = this;
                /// ���� �Ŀ��� ���� �����ʹ� RemoveAt() �Լ��� ����
                enemyList.RemoveAt(0);
                /// while������ �ڷ�ƾ���� Ÿ�̹� ���߱�
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

        /// ������ ����� �ְ������� �ҷ��� �� �� ������ ����
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
        ///16-4 �÷���Ÿ��  :  deltaTime���� ����    
        if (isBattle) playTime += Time.deltaTime;
    }


    void LateUpdate()   ///16-3 
    {
        /// ��� UI
        scoreText.text = string.Format("{0:n0}", player.score);
        stageText.text = "STAGE " + stage;

        ///16-4  �÷���Ÿ�� : update�Լ� ����
        int hour = (int)(playTime / 3600);          
        int min = (int)((playTime - hour * 3600) / 60);   
        int second = (int)(playTime % 60);   ///������
        playTimeText.text = string.Format("{0:00}", hour) + ":" +
                           string.Format("{0:00}", min) + ":" +
                           string.Format("{0:00}", second);

        ///�÷��̾� UI
        playerHealthText.text = player.health + " / " + player.maxHealth;
        playerCoinText.text = string.Format("{0:n0}", player.coin);

        ///���� UI  :  ���� �������¿� ���� 
        if (player.equipWeapon == null) playerAmmoText.text = "- / " + player.ammo;
        else if (player.equipWeapon.type == Weapon.Type.Melee) playerAmmoText.text = "- / " + player.ammo;
        else playerAmmoText.text = player.equipWeapon.curAmmo + " / " + player.ammo;

        ///���� UI  :  ���� ���� ���¿� ���� ���İ��� ����
        weapon1Img.color = new Color(1, 1, 1, player.hasWeapons[0] ? 1 : 0);
        weapon2Img.color = new Color(1, 1, 1, player.hasWeapons[1] ? 1 : 0);
        weapon3Img.color = new Color(1, 1, 1, player.hasWeapons[2] ? 1 : 0);
        weaponRImg.color = new Color(1, 1, 1, player.hasGranades > 0 ? 1 : 0);

        ///���ͼ� UI
        enemyAText.text = enemyCntA.ToString();
        enemyBText.text = enemyCntB.ToString();
        enemyCText.text = enemyCntC.ToString();

        ///���� UI 
        if (boss != null)         /// ���� ������ ������� �� UI ������Ʈ ���� �ʵ��� ���� �߰�
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
