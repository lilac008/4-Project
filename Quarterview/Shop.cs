using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               ///����Ƽ UI�� ����ϰڴ�, public Text talkText; ���� ���





/// UI (UserInterface ������ȣ�ۿ� : ��ũ�� ��ǥ��, 2D�� �ٲٸ� �۾��ϱ� ����  /  Rect Transform(��ũ�� ��ǥ) - Anchor Presets(shift:UI������, Alt:UI��ġ))
/// 
/// Canvas - Menu Panel - Game Panel 
/// 1. Canvas (ũ��:gameȭ�鿡�� 16:9�� ����(canvasũ��� main camera ũ��� ����), pixel perfect(��Ʈ) Ȱ��ȭ,  Canvas Scaler(- UI Scale Mode:ScaleWithScreenSize, Reference Resolution(X:1920, Y:1080 �ػ�)  )
/// 2. Menu Panel(R click-UI-Panel, Color:Black) - Title Image(R click-UI-Image / Source Image : Title Sprite drag),  Set Native Size ����) 
///                                              - Max score Image(R click-UI-Image / Source Image : Icon Score Mini drag)
///                                              - Max score Text(R click-UI-Text / Text:999999, Fsize:130, Alignm:�߾�, col:white, React Transform(W:0,H:0, Scale(�۾�����):0.5), Font:��Ű��bold,  H/V Overflow:Overflow)
///                                              - Start Button(R click-UI-Button / Source Image: PanelA drag, Image Type:Simple - SetNativeSize - Image Type:Sliced ) - Text (text:Game Start �Է�, Font:��Ű��bold, Fsize:110, RectT(scale:0.5,0.5,0.5), H/V Overflow:Overflow)           
/// 3. Game Panel(R click-UI-Panel, Color: A:0)  - [1] Score Group(��obj, RectT(W:0,H:0, AnchorPreset:alt,shift,�������, PosX:20,PosY:-20) - Score Image(UI-Image / Source Image:Icon Score Mini drag, RectT(AnchorPreset:alt,shift,�������)), Score Text(UI-Text / Text:999999, Font:��Ű��bold, Fsize:100, RectT(W:0,H:0,scale:0.5x3, AnchorPreset:alt,shift,�������), H/V Overflow:Overflow)  
///                                              - Status Group ( [1]����, StatusGroup(RectT(PosX:20,PosY:-20)) �� �ڽ�obj�� RectT-Anchor-alt,shift,�����ϴ�, �ڽ�obj�� Image�� Text ������ 2�� ����) - Heart/Ammo/Coin Image(Source Image:Icon Heart/Ammo/Coin Mini, setNativeSize), Heart/Ammo/Coin Text (H:100/100, A:-/99, C:1000)
///                         (�� �ٺ��� ��������) - Stage Group( [1]����, Stage Group(RectT(PosX:-20,PosY:-20)) �� �ڽ�obj�� RectT-Anchor-alt,shift,������� )  -  Stage/Time Image(SourceImage:Icon Stage/Time Mini),  Stage/Time Text(Text:Stage 1/00:00:00, Alignm:����) ������ ����
///                                              - Enemy Group( [1]����, ) - Enemy A/B/C/D Image/Text 
///                                              - Equip Group - Equip 1/2/3(- Weapon Image/Num Image), ControlR(- Weapon Image/Num Image) 
///                                              - Boss Gruop - Image(SourceImage:, ImageType:Simple, setNativeSize, Anchor:, RectT(W:600,H:50)) - Boss Health Image(SourceImage:, color:Red, ImageType:Simple, setNativeSize, Anchor:, RectT(W:600,H:50)), Boss Text, Boss Image
///                                              - [2] Item Shop Group         - Item Button A(On) /B/C(- Text, Text, Image),  Exit Button(-Text����  ),  Portrait Image,  Talke Text
///                                              - Weapon Shop Group ([2]����) - Item Button A/B/C(- Text, Text, Image),  Exit Button(-Text����   ),  Portrait Image,  Talk Text 



/// Item Shop   - Table,  Goods Group,  Luna (MeshObj-Animator-Idle,Hello (tHello)),  Zone(��obj - Particle System (Shpape:Donut, ���ͺ� 15�� ����), Shop script) - Spawn Pos A/B/C(��obj)
/// Weapon Shop - Table,  Goods Group,  Ludo (MeshObj- Luna Animation���� �� ��ü ),  Zone(��obj - Shop script) - Spawn Pos A/B/C(��obj)






public class Shop : MonoBehaviour
{

    public RectTransform rectT_UI;                                ///ui ���� ����,  Item / Weapon  Shop Group �巡��
    public Animator anim;                                         /// Luna/Ludo - Mesh Obj �巡��    
    Player player;                                                /// �÷��̾� ����

    public GameObject[] itemObjArr;                               /// ������ prefab �迭, Luna/Ludo - zone (shop script : ItemObjArr - size: 3, ItemHeart/ ItemAmmo / WeaponGrenade prefab ���� ����) 
    public int[] itemPriceArr;                                    /// ������ ���� �迭, Luna/Ludo - zone (shop script : ItemPriceArr - size: 3, Luna1000/1200/2500 or Ludo500/3000/5000 �Է�)
    public Transform[] itemPosArr;                                /// ������ ��ġ �迭, Luna/Ludo - zone (shop script : ItemPosArr - size: 3, (Luna-Zone-)Spawn Pos A/B/C ����)
    public Text talkText;                                         /// Luna/Ludo - zone ( shop script : TalkText - (Item/Weapon Shop Group-)TalkText ���� )
    public string[] shopTalk;                                     /// ������ȭ�� ���� ���� �迭, Luna/Ludo - zone (shop script : shopTalk - size:2, 0:�Ҹ�ǰ/���� ������ ��������, 1:���� ������... �ٽ� Ȯ���غ�.)


    /// Item Shop Group   - Exit Button : On Click()�Լ���  Luna �巡�� �� Shop - Exit() ����
    /// Weapon Shop Group - Exit Button : On Click()�Լ���  Ludo �巡�� �� Shop - Exit() ����
    /// Item Shop Group   - Item Button A/B/C ���� : On Click()�Լ��� (Luna-)zone �巡�� �� Shop - Buy(int) - 0/1/2 ���� 
    /// Weapon Shop Group - Item Button A/B/C ���� : On Click()�Լ��� (Ludo-)zone �巡�� �� Shop - Buy(int) - 0/1/2 ���� 




    public void Enter(Player _player)///15��-1����
    {
        player = _player;
        rectT_UI.anchoredPosition = Vector3.zero;                ///ȭ�� �� �߾ӿ� ������
    }


    public void Exit()                ///15��-1����
    {

        anim.SetTrigger("doHello");
        rectT_UI.anchoredPosition = Vector3.down * 1000;        ///
    }




    public void Buy(int _int)
    {
        int price = itemPriceArr[_int];

        if (price > player.coin)    /// �ݾ��� �����ϸ� return
        {
            
            StopCoroutine(Talk());      /// �̿��ڰ� �ߺ����� ���� �� ��簡 ���̴°� �����ϱ� ���� �� �� �����Ѵ�.
            StartCoroutine(Talk());     /// ��� �Լ� ȣ��
            return;
        }

        player.coin -= price;                                                                              ///���� ������ �ݾ�����
        Vector3 randomVec = Vector3.right * Random.Range(-3, 3)  +  Vector3.forward * Random.Range(-3, 3); /// ���� ��ġ ����
        Instantiate(itemObjArr[_int], itemPosArr[_int].position + randomVec,  itemPosArr[_int].rotation);  /// ������ ����
    }
    IEnumerator Talk()
    {
        talkText.text = shopTalk[1];            
        yield return new WaitForSeconds(2f);    ///2�� ����
        talkText.text = shopTalk[0];
    }








}
