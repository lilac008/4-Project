using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               /// 

public class GameManager : MonoBehaviour
{

    public GameObject menuCamera;                   /// Menu Camera drag
    public GameObject gameCamera;                   /// game Camera drag

    public Player player;                           /// Player script drag
    public Boss boss;                               /// Boss script drag
    public int stage;
    public float playTime;
    public bool isBattle;
    public int enemyCntA;
    public int enemyCntB;
    public int enemyCntC;
    public int enemyCntD;

    public GameObject menuPanel;
    public GameObject gamePanel;
    public GameObject gameoverPanel;

    /// Score Group
    public Text curScoreText;
    /// Stage Group 
    public Text stageTxt;                           ///Game Panel - Stage Group - Stage Text    
    public Text playTimeTxt;                        ///Game Panel - Stage Group - Time Text 
    /// Status Group
    public Text playerHealthTxt;                    ///G
    public Text playerAmmoTxt;
    public Text playerCoinTxt;
    /// Equip Group
    public Image weapon1Img;
    public Image weapon2Img;
    public Image weapon3Img;
    public Image weaponRImg;
    /// Enemy Group
    public Text enemyATxt;
    public Text enemyBTxt;
    public Text enemyCTxt;
    /// Boss Group
    public RectTransform bossHealthGroup;
    public RectTransform bossHealthBar;
    /// GameOver
    public Text bestText;
    public Text maxScoreTxt;                        ///Canvas - Max Score Text
    public Text scoreTxt;                           ///Game Panel - Score Group - Score Text 



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




    void Awake()
    {
        maxScoreTxt.text = string.Format("{0:n0}", PlayerPrefs.GetInt("MaxScore"));
        enemyList = new List<int>();
        /// ��HasKey() �Լ��� Key�� �ִ��� Ȯ�� ��, ���ٸ� 0���� ����
        if (PlayerPrefs.HasKey("MaxScore"))
            PlayerPrefs.SetInt("MaxScore", 0);
    }

    /// ���� ��ŸƮ ��ư Ŭ�� �̺�Ʈ
    public void GameStart()
    {
        menuCamera.SetActive(false);
        gameCamera.SetActive(true);

        menuPanel.SetActive(false);
        gamePanel.SetActive(true);

        startWall1.SetActive(true);
        startWall2.SetActive(true);
        startWall3.SetActive(true);
        startWall4.SetActive(true);
        player.gameObject.SetActive(true);
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

        curScoreText.text = scoreTxt.text;

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
        /// �÷��� Ÿ���� ��ŸŸ���� ����Ͽ� ����
        if (isBattle) playTime += Time.deltaTime;
    }

    /// �ΰ��� UI
    void LateUpdate()
    {
        /// ��� UI
        scoreTxt.text = string.Format("{0:n0}", player.score);
        stageTxt.text = "STAGE " + stage;
        /// �ʴ��� �ð��� 3600, 60���� ������ �ú��ʷ� ���
        int hour = (int)(playTime / 3600);
        /// hour�� ���� ����ϰ� ���� ���� ���ش�.
        int min = (int)((playTime - hour * 3600) / 60);
        int second = (int)(playTime % 60);
        playTimeTxt.text = string.Format("{0:00}", hour) + ":" +
                           string.Format("{0:00}", min) + ":" +
                           string.Format("{0:00}", second);

        /// �÷��̾� UI
        playerHealthTxt.text = player.health + " / " + player.maxHealth;
        playerCoinTxt.text = string.Format("{0:n0}", player.coin);
        /// ���⸦ �������� �ʾҴٸ�,
        if (player.equipWeapon == null) playerAmmoTxt.text = "- / " + player.ammo;
        /// ������ ���Ⱑ ���� ������,
        else if (player.equipWeapon.type == Weapon.Type.Melee) playerAmmoTxt.text = "- / " + player.ammo;
        else playerAmmoTxt.text = player.equipWeapon.curAmmo + " / " + player.ammo;

        /// ���� UI | �������� ���� ��Ȳ�� ���� ���İ��� ����
        weapon1Img.color = new Color(1, 1, 1, player.hasWeapons[0] ? 1 : 0);
        weapon2Img.color = new Color(1, 1, 1, player.hasWeapons[1] ? 1 : 0);
        weapon3Img.color = new Color(1, 1, 1, player.hasWeapons[2] ? 1 : 0);
        weaponRImg.color = new Color(1, 1, 1, player.hasGranades > 0 ? 1 : 0);

        /// ���� ���� UI
        enemyATxt.text = enemyCntA.ToString();
        enemyBTxt.text = enemyCntB.ToString();
        enemyCTxt.text = enemyCntC.ToString();

        /// ���� UI 
        /// int ���³��� �����ϸ� ������� int�̹Ƿ� ���� (�ϳ��� float ��ȯ)
        /// ���� ������ ������� �� UI ������Ʈ ���� �ʵ��� ���� �߰�
        if (boss != null)
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