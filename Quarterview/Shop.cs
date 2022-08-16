using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// Item Shop  - Table,  Goods Group,  Luna (MeshObj-Animator-Idle,Hello (tHello)),  Zone(빈obj - Particle System (Shpape:Donut, 쿼터뷰 15부 참고), Shop script) - Spawn Pos A/B/C(빈obj)
/// Item Shop2 - Table,  Goods Group,  Ludo (MeshObj- Luna Animation복사 후 교체 ),  Zone(빈obj - Shop script) - Spawn Pos A/B/C(빈obj)



/// UI (User Interface : 스크린 좌표계, 2D로 바꾸면 작업하기 편함  /  Rect Transform(스크린 좌표) - Anchor Presets(shift:UI기준점, Alt:UI위치))
/// 
/// Canvas - Menu Panel - Game Panel 
/// 1. Canvas (크기:game화면에서 16:9로 설정(canvas크기는 main camera 크기와 동일), pixel perfect(도트) 활성화,  Canvas Scaler(- UI Scale Mode:ScaleWithScreenSize, Reference Resolution(X:1920, Y:1080 해상도)  )
/// 2. Menu Panel(R click-UI-Panel, Color:Black) - Title Image(R click-UI-Image / Source Image : Title Sprite drag),  Set Native Size 설정) 
///                                              - Max score Image(R click-UI-Image / Source Image : Icon Score Mini drag)
///                                              - Max score Text(R click-UI-Text / Text:999999, Fsize:130, Alignm:중앙, col:white, React Transform(W:0,H:0, Scale(글씨압축):0.5), Font:쿠키런bold,  H/V Overflow:Overflow)
///                                              - Start Button(R click-UI-Button / Source Image: PanelA drag, Image Type:Simple - SetNativeSize - Image Type:Sliced ) - Text (text:Game Start 입력, Font:쿠키런bold, Fsize:110, RectT(scale:0.5,0.5,0.5), H/V Overflow:Overflow)           
/// 3. Game Panel(R click-UI-Panel, Color: A:0)  - Score Group(빈obj, RectT(W:0,H:0, AnchorPreset:alt,shift,좌측상단, PosX:20,PosY:-20) - Score Image(UI-Image / Source Image:Icon Score Mini drag, RectT(AnchorPreset:alt,shift,좌측상단)), Score Text(UI-Text / Text:999999, Font:쿠키런bold, Fsize:100, RectT(W:0,H:0,scale:0.5x3, AnchorPreset:alt,shift,좌측상단), H/V Overflow:Overflow)  
///                                              - Status Group (ScoreGroup복사, StatusGroup(RectT(PosX:20,PosY:-20)) 및 자식obj도 RectT-Anchor-alt,shift,좌측하단, 자식obj의 Image와 Text 선택후 2쌍 복사) - Heart/Ammo/Coin Image(Source Image:Icon Heart/Ammo/Coin Mini, setNativeSize), Heart/Ammo/Coin Text (H:100/100, A:-/99, C:1000)
///                                              - Stage Group(ScoreGroup복사, Stage Group(RectT(PosX:-20,PosY:-20)) 및 자식obj도 RectT-Anchor-alt,shift,우측상단 )  - Stage/Time Image(SourceImage:Icon Stage/Time Mini), Stage/Time Text(Text:Stage 1/00:00:00, Alignm:우측) 설정후 복사
///                                              - Enemy Group(ScoreGroup복사)





public class Shop : MonoBehaviour
{










}
