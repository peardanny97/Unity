# Unity

서울대학교 시리어스 게임의 기말 프로젝트

## OP vs GLITCH
Unity를 이용하여 만든 간단한 퍼즐 게임

## 멤버
2017-11621 배병욱

## 사용 ASSET
itch.io 의 무료 에셋

Mystic Woods <https://game-endeavor.itch.io/mystic-woods>

Pixel Art Top Down - Basic <https://cainos.itch.io/pixel-art-top-down-basic>

## Map Design

1. 마을의 유일한 출구이자 한갈래 길로 나가게 되면 이 게임의 유일한 적이자 OP인 슬라임을 만나도록 유도

  해당 슬라임을 물리적(유저 개인의 피지컬)으로 피할 수 없도록 슬라임의 크기 및 속도 길목의 넓이를 설정

2. 유저는 이 슬라임을 지나야 골이 있음을 느끼나 이 슬라임을 파훼할 무언가 다른 방법이 숨겨져 있음을 느끼게 됨

3. 유저가 goal에 도달하도록 하는 3가지 glitch

3-1. 여신상 

제대로 설계된 게임이라면 불가능했을 0 gold에서 거래가 진행되어 gold가 overflow 되도록 만듬

여신상에 무한히 기도하여 유저의 체력을 무한히 늘릴 수 있게 하여 슬라임과 대적할 수 있게 됨.

해당 여신상의 경우 자동으로 유저와 상호작용하기에 가장 쉽게 찾을 수 있는 glitch

3-2. 깨진 나무

마을의 출구가 아닌 반대편 길 끝에 그래픽이 깨진 나무를 배치

해당 나무에 유저가 캐릭터를 비비게 되면 벽을 통과할 수 있도록 함

슬라임을 처치하는 것이 아닌 우회하여 게임의 골을 얻게 하는 glitch

3-3. 투명한 돌

beta player의 테스트를 통해 가장 지나가기 쉬운 길목에 투명한 돌을 배치

해당 돌을 유저가 공격하게 된다면 슬라임에게 캐릭터가 인지되지 않는

투명 gltich를 해금할 수 있게 하는 glitch

## Game play Feedback

가장 간과한 점은 유저가 작성된 글을 유심히 읽는 경우가 적다는 것이다.

실제로 유저가 glitch를 발견하더라도 해당 화면을 재빨리 넘기기에 glitch 사용법을 모르는 경우가 존재하였다.

또한 첫 게임 화면의 설명을 읽지 않아 공격, 재시작 버튼을 모르는 경우가 존재하였다.

gltich의 발견 빈도는 여신상 > 깨진 나무 > 투명 돌 순이였다.

특히 투명 돌의 경우 유저가 캐릭터와 부딪히더라도 제대로 인지하지 못하는 경우가 존재하였다.


## 게임 화면

<img width="1347" alt="스크린샷 2023-04-04 오후 3 33 10" src="https://user-images.githubusercontent.com/37990408/229707789-5791d353-e5a4-4c67-8157-17dc67f2f393.png">
<img width="1433" alt="스크린샷 2023-04-04 오후 3 33 47" src="https://user-images.githubusercontent.com/37990408/229707797-8a75fb2b-bfe0-4a1c-aacf-ce5f87905833.png">


![화면 캡처 2023-04-04 224752](https://user-images.githubusercontent.com/37990408/229813137-f522805b-0d90-4cfb-a593-3c74f0d567c9.png)
