# Unity 게임개발 심화 개인 과제 - 김광수



## Project Introduction

최종 프로젝트에서 만들 로그라이크 게임에대해 조사해보다가

Slay the Spire의 지도 맵을 레퍼런스로 랜덤으로 던전이 생성되고 경로를 선택해서 진행하는 시스템을 만들어 보았습니다.

## Development Environment

Language : C#

Engine : Unity 2022.3.2f1

IDE : Visual Studio 2022

Framework : .NET 6.0

## 내가 구현한 기능

1. 랜덤으로 맵의 구조를 생성하고 해당 맵의 정보를 할당
   
    MapManager [Wiki](https://github.com/kksoo0131/CreateSelectMap/wiki/MapManager)

2. 각 맵 (이벤트)에 관한 정보들을 ScriptableObject로 관리

   EventInfoSO [Wiki](https://github.com/kksoo0131/CreateSelectMap/wiki/EventInfoSO)

3. 이벤트의 선택에 따라 발생할 기능들을 ScirptableObject로 관리

   DamagedEventSO [Wiki](https://github.com/kksoo0131/CreateSelectMap/wiki/DamagedEventSO)
   
   RunEventSO [Wiki](https://github.com/kksoo0131/CreateSelectMap/wiki/RunEventSO)

5. EventInfoSo의 정보를 바탕으로 UIEventWindow에서 관리하는 Text, Button의 기능이 정해집니다.

   
   UIEventWindow [Wiki](https://github.com/kksoo0131/CreateSelectMap/wiki/UIEventWindow)

## 전체적인 흐름 영상

![Movie_004](https://github.com/kksoo0131/CreateSelectMap/assets/99727193/c4ddabd1-a50f-4b94-b84d-b13c6d33c548)

## 맵 생성에 초점을 둔 영상

![Movie_005](https://github.com/kksoo0131/CreateSelectMap/assets/99727193/686f79a1-8263-4fb6-a26d-994b66fda888)

## 필수 요구사항


1. 인트로 씬 구성

2. 자유 게임 만들기

<br/>

## 선택 요구사항

- Instantiate로 오브젝트 생성  
- 스크립트로 버튼에 이벤트 추가
- delegate 사용
- generic을 이용한 싱글톤
- Dictionary 활용
- Queue,Stack 활용

 <br/>
 
>  ~~오브젝트 풀링~~

>  ~~InputAction 사용~~

>  ~~raycast~~

>  ~~FSM~~


## Main Functions

## Manager
### MapManager [Wiki](https://github.com/kksoo0131/CreateSelectMap/wiki/MapManager)

<br/>

## UI
### UIMap [Wiki](https://github.com/kksoo0131/CreateSelectMap/wiki/UIMap)
### UIButton [Wiki](https://github.com/kksoo0131/CreateSelectMap/wiki/UIButton)
### UIEventWindow [Wiki](https://github.com/kksoo0131/CreateSelectMap/wiki/UIEventWindow)
### UIEventIcon [Wiki](https://github.com/kksoo0131/CreateSelectMap/wiki/UIEventIcon)

<br/>

## ScriptableObject
### EventInfoSO [Wiki](https://github.com/kksoo0131/CreateSelectMap/wiki/EventInfoSO)
### EventFuncSO [Wiki](https://github.com/kksoo0131/CreateSelectMap/wiki/EventFuncSO)
### DamagedEventSO [Wiki](https://github.com/kksoo0131/CreateSelectMap/wiki/DamagedEventSO)
### RunEventSO [Wiki](https://github.com/kksoo0131/CreateSelectMap/wiki/RunEventSO)
### CharacterStatSO [Wiki](https://github.com/kksoo0131/CreateSelectMap/wiki/CharacterStatSO)
<br/>

## Util
### Singleton<T> [Wiki](https://github.com/kksoo0131/CreateSelectMap/wiki/SingleTon-T-)
### Enum [Wiki](https://github.com/kksoo0131/CreateSelectMap/wiki/Enum)
### Util [Wiki](https://github.com/kksoo0131/CreateSelectMap/wiki/Util)
