# Record_20xx

> 홀로 파견된 조사원이 되어 버려진 장소를 탐사하고, 사물을 **스캔**해 퍼즐을 풀며 세계를 기록하는 2D 탐험·퍼즐 게임.

Unity로 제작한 개인 졸업작품입니다. 시연 영상은 [`Recordings/정다연_졸작.mp4`](Recordings/)에 있습니다.

---

## 개요

| 항목 | 내용 |
| --- | --- |
| 엔진 | Unity **2022.3.5f1** |
| 장르 | 2D 탑다운 탐험 / 방탈출형 퍼즐 |
| 조작 | 키보드 (이동 + 스캔) |
| 해상도 | 1920 × 1080 (가로) |
| 플랫폼 | PC (Standalone) |

## 스토리

상사의 무전만 들으며 혼자 조사 임무에 투입된다.
"도착하면 주변을 둘러보고, **스캔해서 문제를 풀면 기록은 자동으로 된다**"는 지시를 따라
집과 마당을 돌아다니며 잠긴 사물들을 하나씩 열어나간다.
마지막, 조사가 끝난 세상은 온통 초록빛 – 칡으로 뒤덮여 있다.

## 플레이 방법

- **이동**: 방향키 / WASD
- **스캔**: 사물에 가까이 다가가 `E` 키
  - 스캔하면 해당 사물의 퍼즐 화면이 열린다.
  - 퍼즐을 풀면 사물이 열리고 아이템·힌트를 얻으며, 다음 장소로 가는 길이 열린다.
- 플레이어는 Y축 위치에 따라 크기가 변해 원근감을 준다. TV 등 앞을 가리는 사물은 겹치면 반투명해진다.

## 씬 흐름

빌드 순서(`Assets/Scenes/`)대로 진행됩니다.

| # | 씬 | 역할 |
| --- | --- | --- |
| 0 | `0)MainScene` | 타이틀 (시작 / 종료) |
| 1 | `1)story_start` | 도입부 대사 |
| 2 | `2)first_home` | **스테이지 1 – 집 내부.** TV·신발장·장식장·소파·매트·냉장고·식탁·현관문 퍼즐 |
| 3 | `3)second_yard` | **스테이지 2 – 마당.** 텃밭·장독대·파이프·문 퍼즐 |
| 4 | `4)story_end` | 마무리 대사 (세상이 칡으로 뒤덮임) |
| 5 | `5)EndScene` | 엔딩 (다시하기 / 종료) |

## 퍼즐 종류

스테이지별로 `puzzleManager`(집) / `puzzleManager2`(마당)가 상태를 관리하며,
각 퍼즐은 `*_ctrl`(개별 오브젝트 동작) + `*_group`(퍼즐 전체 정답 판정) 스크립트 쌍으로 구성됩니다.

- **숫자 키패드** (`input_ctrl`) – 4자리 비밀번호 입력
- **도형 키패드** (`main_ctrl` / `main_ctrl2`) – 점·사각형·삼각형·원을 순환시켜 패턴 맞추기
- **숫자 블럭** (`block_ctrl` / `block_group`) – 블럭을 옮겨 식을 완성
- **자석** (`magnet_ctrl` / `magnet_group`) – 냉장고 자석 배치
- **도장** (`stamp_ctrl` / `stamp_group`) – 정해진 자리에 도장 찍기
- **미로** (소파) · **손잡이**(`handle_ctrl`) · **파이프 연결** 등

## 프로젝트 구조

```
Assets/
├── Scenes/           씬 6개 (0)~5)
├── Scripts/          게임 로직 C# 스크립트 (~30개)
│   ├── scene_*.cs        타이틀 / 엔딩 씬 UI
│   ├── story_*.cs        도입 / 마무리 대사 연출
│   ├── player_move*.cs   플레이어 이동·스캔 (스테이지별 2종)
│   ├── puzzleManager*.cs 스테이지별 퍼즐 상태 머신
│   ├── *_ctrl.cs         개별 퍼즐 오브젝트 동작
│   ├── *_group.cs        퍼즐 정답 판정
│   ├── dialogue_group.cs 대사 / 힌트 출력
│   ├── ui_group.cs       획득 아이템 UI
│   └── bg_move.cs        플레이어 추적 배경 스크롤
├── Character/         플레이어 스프라이트 · 애니메이션 (idle / scanner, 4방향)
├── Resources/
│   ├── Objects/          사물 스프라이트 (home / yard)
│   ├── Puzzles/          퍼즐 화면 스프라이트
│   ├── Prefebs/          도장 프리팹 등
│   ├── UIs/              버튼·대사창·아이템 UI
│   └── Sounds/           효과음 · BGM
├── bg_*.png          배경 (거실 / 마당 / 마을 등)
└── Silver.ttf        폰트 (TextMeshPro SDF)
```

## 실행 방법

1. **Unity 2022.3.5f1** (LTS)로 이 폴더를 연다.
2. `Assets/Scenes/0)MainScene.unity`를 열고 Play.
3. 빌드: `File > Build Settings`에서 씬 0~5가 순서대로 포함되어 있는지 확인 후 PC 대상으로 빌드.

## 주요 패키지

- `com.unity.feature.2d` – 2D 툴셋
- `com.unity.textmeshpro` – 텍스트 렌더링
- `com.unity.recorder` – 시연 영상 녹화
- `com.unity.timeline`, `com.unity.visualscripting`

## 참고

- 코드 주석과 대사는 한국어로 작성되어 있습니다.
- `Library/`, `obj/`, `.vs/` 등 Unity가 생성하는 폴더는 재생성되므로 무시해도 됩니다.
