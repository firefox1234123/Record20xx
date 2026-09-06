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

## 기술적 특징

### 아키텍처

- **씬 단위 선형 진행** – 6개 씬을 `SceneManager.LoadScene`으로 순서대로 연결한다. 씬을 넘나드는 영속 상태 없이 각 스테이지가 자기 완결적으로 상태를 보유한다.
- **스테이지별 중앙 상태 머신** – 캔버스에 붙은 `puzzleManager`(집) / `puzzleManager2`(마당)가 모든 퍼즐의 `열림 / 해결 / 최초 진입 / 아이템 획득` 상태를 총괄한다. `Update()`에서 매 프레임 상태값을 검사해 각 UI 그룹을 `SetActive`로 토글하는 **폴링(즉시 모드) 방식**이다.
- **`_ctrl` + `_group` 2계층 퍼즐 구성** – `_ctrl`은 개별 오브젝트의 입력·연출·회전 상태를, `_group`은 퍼즐 전체의 정답 판정을 담당한다. 판정 성공 시 `puzzleManager.*StateOpen()` 콜백 하나로 스프라이트 교체·효과음·대사·아이템 활성화를 처리한다.
- 상태 표현은 `bool` 대신 **2값 `enum`(on/off, yes/no)** 을 퍼즐마다 세트로 선언하는 스타일이다.
- 컴포넌트 참조는 대부분 `GameObject.Find` + `Resources.Load` 런타임 조회로 연결한다(인스펙터 주입 최소화).

### 플레이어 · 연출

- `Rigidbody2D.velocity` 직접 제어 이동, `GetAxisRaw` + `Mathf.Clamp`로 이동 범위 제한, `Animator`의 MoveX/MoveY 블렌드 + `isScanning` 트리거.
- **가짜 원근감** – 플레이어 Y좌표를 `InverseLerp → Lerp`로 매핑해 `localScale`을 1.0~1.5배로 부드럽게 보간한다(아래로 갈수록 커짐).
- **가림 오브젝트 반투명 처리** – 플레이어가 TV 등과 겹치는 X 구간에 들어가면 해당 `SpriteRenderer`의 알파를 0.6으로 낮춘다.
- **스캔 상호작용** – `OnCollisionStay2D` / `OnTriggerStay2D`로 근접 사물명을 저장 → `E` 키 → 코루틴으로 스캔 모션(약 1.1초) 대기 후 `switch(objectName)`로 해당 퍼즐 캔버스를 연다.
- `bg_move` – 플레이어 X 위치를 기준으로 배경을 좌/우 프리셋 위치로 스냅 스크롤한다.

### 퍼즐 메커니즘 구현

- **숫자 키패드**(`input_ctrl`) – `StringBuilder`로 4자리 입력 관리, 버튼 리스너 람다 일괄 등록, 현재 활성 퍼즐 enum + 정답 문자열 비교, `TextMeshProUGUI` 출력.
- **자석 / 도장 / 블럭** – `IDragHandler`·`IEndDragHandler`·`IPointerClickHandler` 구현. 클릭 시 90° 단위 회전 enum 순환, 드래그 종료 시 `snapOffset` 거리 안의 스냅 포인트로 흡착, 부착/분리 효과음.
- **도형 키패드**(`main_ctrl`) – 점·사각형·삼각형·원을 카운터로 순환 교체.
- 퍼즐 공통 – 최초 진입 시 설명 대사 1회, `H` 키 힌트, 반투명 `blind` 클릭 시 창 닫기 + 입력 초기화. `dialogue_group`이 코루틴 기반 타이핑 대사·힌트를 출력한다.

### 진행 · 아이템

- 아이템(문열쇠·배터리1·2)은 해결 후 `getX` enum으로 소지를 추적한다. 장식장 퍼즐은 배터리 2개를 모두 획득해야 입력이 활성화되는 **선행 조건부 게이팅**을 건다.
- 스테이지 클리어 조건 충족 시 팝업 → OK 버튼 리스너로 다음 씬을 로드한다.

### 알려진 한계 / 트레이드오프

- 상태를 `bool` 대신 `퍼즐 수 × 상태 종류`만큼 개별 enum으로 선언해 보일러플레이트가 많고, `puzzleManager.Update()`가 거대한 `if` 체인이 된다.
- 정답이 코드에 하드코딩되어 있고, `GameObject.Find` 의존이 커서 씬 구조 변경에 취약하다.
- 저장/로드·설정 메뉴는 없다(졸업작품 시연 목적의 선형 경험).

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
