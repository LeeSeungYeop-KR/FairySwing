using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniDoodles
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2020.04.28 </para>
    /// <para> 내    용 : 플레이 씬을 관리하는 스크립트 </para>
    /// </summary>
    public class MD_Character : MonoBehaviour, MD_IHit
    {
        #region 캐릭터의 열거형

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.28 </para>
        /// <para> 내    용 : 캐릭터의 상태 열거형 </para>
        /// </summary>
        public enum STATE
        {
            Idle, Attack, Hit, Die
        }


        #endregion

        #region Properties
        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.28 </para>
        /// <para> 내    용 : 캐릭터의 상태를 설정하면 그에 맞는 행동 하게하는 메서드 호출하는 캐릭터 상태의 속성 </para>
        /// </summary>
        public STATE CharacterState
        {
            get
            {
                return characterState;
            }

            set
            {
                characterState = value;
                Func_CharacterState();
            }
        }

        #endregion

        [Header("- Character Value")]
        public MD_BattleManager.TEAM team;                  // 캐릭터가 어디 팀인지 확인
        public int hp;                                      // 체력
        public int attack;                                  // 공격력
        public float attackTime = 1f;                       // 공격 쿨타임
        [SerializeField] private STATE characterState;      // 캐릭터의 상태

        [Header("- Characer Image")]
        [SerializeField] private SpriteRenderer characterImage;
        [SerializeField] private Sprite[] image_state;

        [Header("- State Value")]
        [SerializeField] private float time_Hit = 1f;       // 맞고 Idle로 돌아가는 시간
        [SerializeField] private float time_Die = 1f;       // 죽음으로 변하는 시간

        [Header("- UI")]
        [SerializeField] private Text text_HP;      // 캐릭터의 체력 텍스트
        [SerializeField] private Text text_State;   // 캐릭터의 상태 텍스트

        private bool isBattleEnd = false;           // 전투가 끝났는지 체크
        [HideInInspector] public bool isDie = false;         // 죽었는지 체크하는 변수
        private MD_Character targetCharacter;       // 공격해야 할 캐릭터

        // Start is called before the first frame update
        void Start()
        {
            Func_InitCharacter();
            Func_CharacterState();
        }

        #region 캐릭터의 상태 메서드

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.28 </para>
        /// <para> 내    용 : 캐릭터의 상태에 따라 알맞은 메서드 호출 </para>
        /// </summary>
        private void Func_CharacterState()
        {
            Func_CharacterImage(characterState);        // 캐릭터 상태에 따라 이미지 변환
            Func_SetCharacterText();                    // 캐릭터 텍스트 변환

            switch (characterState)
            {
                case STATE.Idle:
                    Func_StateIdle();
                    break;

                case STATE.Attack:
                    Func_StateAttack();
                    break;

                case STATE.Hit:
                    Func_StateHit();
                    break;

                case STATE.Die:
                    Func_StateDie();
                    break;

                default:
                    Debug.Log("설정되지 않은 캐릭터 상태");
                    break;
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.30 </para>
        /// <para> 내    용 : 플레이어의 상태가 대기 상태일 때 호출하는 메서드 </para>
        /// </summary>
        private void Func_StateIdle()
        {

        }



        private void Func_StateAttack()
        {
            StartCoroutine(Co_StateAttack());
        }

        private IEnumerator Co_StateAttack()
        {
            yield return new WaitForSecondsRealtime(attackTime / 2);

            CharacterState = STATE.Idle;
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.28 </para>
        /// <para> 내    용 : 플레이어의 상태가 맞은 상태일 때 호출하는 메서드 </para>
        /// </summary>
        private void Func_StateHit()
        {
            StartCoroutine(Co_StateHit());
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.28 </para>
        /// <para> 내    용 : 플레이어의 상태가 맞은 상태일 때 호출하는 코루틴 </para>
        /// </summary>
        private IEnumerator Co_StateHit()
        {
            yield return new WaitForSecondsRealtime(time_Hit);

            CharacterState = STATE.Idle;     // 캐릭터 상태 : 대기
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.28 </para>
        /// <para> 내    용 : 플레이어의 상태가 죽음 상태일 때 호출하는 메서드 </para>
        /// </summary>
        private void Func_StateDie()
        {
            
        }

        #endregion

        #region 캐릭터의 메서드

        public void Func_SetCharacterText()
        {
            if (hp <= 0)
            {
                hp = 0;
            }
            text_HP.text = "HP : " + hp;
            text_State.text = "State : " + CharacterState;
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.30 </para>
        /// <para> 내    용 : 캐릭터의 이미지를 상태에 따라 변화시키는 메서드 </para>
        /// </summary>
        public void Func_CharacterImage(STATE _state)
        {
            switch (_state)
            {
                case STATE.Idle:
                    characterImage.sprite = image_state[0];
                    break;

                case STATE.Attack:
                    characterImage.sprite = image_state[1];
                    break;

                case STATE.Hit:
                    characterImage.sprite = image_state[2];
                    break;

                case STATE.Die:
                    characterImage.sprite = image_state[3];
                    break;

                default:
                    Debug.Log("설정되지 않은 캐릭터 이미지 상태");
                    break;
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.28 </para>
        /// <para> 내    용 : 캐릭터를 초기화 시키는 메서드 </para>
        /// </summary>
        private void Func_InitCharacter()
        {
            text_HP.text = "HP : " + hp;
            text_State.text = "State : " + CharacterState;

            if (team == MD_BattleManager.TEAM.Left)
            {
                MD_BattleManager.Instance.left_CharacterList.Add(this);
            }
            else
            {
                MD_BattleManager.Instance.right_CharacterList.Add(this);
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.30 </para>
        /// <para> 내    용 : 캐릭터가 공격 할 때 호출되는 메서드 </para>
        /// </summary>
        public void Func_Attack()
        {
            StartCoroutine(Co_Attack());
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.30 </para>
        /// <para> 내    용 : 캐릭터가 공격 할 때 호출되는 코루틴 </para>
        /// </summary>
        private IEnumerator Co_Attack()
        {
            while (!isBattleEnd)
            {
                yield return new WaitForSecondsRealtime(attackTime);

                if (isDie)
                {
                    yield break;
                }

                CharacterState = STATE.Attack;
                if (targetCharacter == null || targetCharacter.isDie)       // 공격할 캐릭터가 없거나 죽었다면 
                {
                    Func_FindCharacterToAttack();       // 공격 할 캐릭터를 선택
                }

                if (!targetCharacter.isDie)
                {
                    targetCharacter.Func_Hit(attack);
                }
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.30 </para>
        /// <para> 내    용 : 공격해야 할 캐릭터 찾는 메서드 </para>
        /// </summary>
        private void Func_FindCharacterToAttack()
        {
            // 왼쪽 팀이면 오른쪽 캐릭터를 공격 할 캐릭터로 지정
            if (team == MD_BattleManager.TEAM.Left)
            {
                for (int i = 0; i < MD_BattleManager.Instance.right_CharacterList.Count; i++)
                {
                    if (!MD_BattleManager.Instance.right_CharacterList[i].isDie)
                    {
                        targetCharacter = MD_BattleManager.Instance.right_CharacterList[i];
                        break;
                    }

                    if (i == MD_BattleManager.Instance.right_CharacterList.Count - 1)
                    {
                        isBattleEnd = true;
                    }
                }
            }
            // 오른쪽 팀이면 왼쪽 캐릭터를 공격 할 캐릭터로 지정
            else
            {
                for (int i = 0; i < MD_BattleManager.Instance.left_CharacterList.Count; i++)
                {
                    if (!MD_BattleManager.Instance.left_CharacterList[i].isDie)
                    {
                        targetCharacter = MD_BattleManager.Instance.left_CharacterList[i];
                        break;
                    }

                    if (i == MD_BattleManager.Instance.left_CharacterList.Count - 1)
                    {
                        isBattleEnd = true;
                    }
                }
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.28 </para>
        /// <para> 내    용 : 캐릭터가 맞았을 때 호출되는 메서드 </para>
        /// </summary>
        public void Func_Hit(int _attackPower)
        {
            hp -= _attackPower;             // 공격력만큼 HP 깍기
            CharacterState = STATE.Hit;     // 캐릭터 상태 : 맞음

            if (hp <= 0)
            {
                // 죽음
                Func_Die();
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.28 </para>
        /// <para> 내    용 : 플레이어의 체력이 0 이하일 때 호출되는 메서드 </para>
        /// </summary>
        private void Func_Die()
        {
            isDie = true;
            hp = 0;
            StartCoroutine(Co_Die());       //
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.28 </para>
        /// <para> 내    용 : 플레이어가 죽었을 때 호출되는 코루틴 </para>
        /// </summary>
        private IEnumerator Co_Die()
        {
            yield return new WaitForSecondsRealtime(time_Die);

            CharacterState = STATE.Die;     // 캐릭터 상태 : 죽음
        }

        #endregion

    }
}