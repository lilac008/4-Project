using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// Item Shop  - Table,  Goods Group,  Luna (MeshObj-Animator-Idle,Hello (tHello)),  Zone(��obj - Particle System (Shpape:Donut, ���ͺ� 15�� ����), Shop script) - Spawn Pos A/B/C(��obj)
/// Item Shop2 - Table,  Goods Group,  Ludo (MeshObj- Luna Animation���� �� ��ü ),  Zone(��obj - Shop script) - Spawn Pos A/B/C(��obj)



/// UI (User Interface : ��ũ�� ��ǥ��, 2D�� �ٲٸ� �۾��ϱ� ����  /  Rect Transform(��ũ�� ��ǥ) - Anchor Presets(shift:UI������, Alt:UI��ġ))
/// 
/// Canvas - Menu Panel - Game Panel 
/// 1. Canvas (ũ��:gameȭ�鿡�� 16:9�� ����(canvasũ��� main camera ũ��� ����), pixel perfect(��Ʈ) Ȱ��ȭ,  Canvas Scaler(- UI Scale Mode:ScaleWithScreenSize, Reference Resolution(X:1920, Y:1080 �ػ�)  )
/// 2. Menu Panel(R click-UI-Panel, Color:Black) - Title Image(R click-UI-Image / Source Image : Title Sprite drag),  Set Native Size ����) 
///                                              - Max score Image(R click-UI-Image / Source Image : Icon Score Mini drag)
///                                              - Max score Text(R click-UI-Text / Text:999999, Fsize:130, Alignm:�߾�, col:white, React Transform(W:0,H:0, Scale(�۾�����):0.5), Font:��Ű��bold,  H/V Overflow:Overflow)
///                                              - Start Button(R click-UI-Button / Source Image: PanelA drag, Image Type:Simple - SetNativeSize - Image Type:Sliced ) - Text (text:Game Start �Է�, Font:��Ű��bold, Fsize:110, RectT(scale:0.5,0.5,0.5), H/V Overflow:Overflow)           
/// 3. Game Panel(R click-UI-Panel, Color: A:0)  - Score Group(��obj, RectT(W:0,H:0, AnchorPreset:alt,shift,�������, PosX:20,PosY:-20) - Score Image(UI-Image / Source Image:Icon Score Mini drag, RectT(AnchorPreset:alt,shift,�������)), Score Text(UI-Text / Text:999999, Font:��Ű��bold, Fsize:100, RectT(W:0,H:0,scale:0.5x3, AnchorPreset:alt,shift,�������), H/V Overflow:Overflow)  
///                                              - Status Group (ScoreGroup����, StatusGroup(RectT(PosX:20,PosY:-20)) �� �ڽ�obj�� RectT-Anchor-alt,shift,�����ϴ�, �ڽ�obj�� Image�� Text ������ 2�� ����) - Heart/Ammo/Coin Image(Source Image:Icon Heart/Ammo/Coin Mini, setNativeSize), Heart/Ammo/Coin Text (H:100/100, A:-/99, C:1000)
///                                              - Stage Group(ScoreGroup����, Stage Group(RectT(PosX:-20,PosY:-20)) �� �ڽ�obj�� RectT-Anchor-alt,shift,������� )  - Stage/Time Image(SourceImage:Icon Stage/Time Mini), Stage/Time Text(Text:Stage 1/00:00:00, Alignm:����) ������ ����
///                                              - Enemy Group(ScoreGroup����)





public class Shop : MonoBehaviour
{










}
