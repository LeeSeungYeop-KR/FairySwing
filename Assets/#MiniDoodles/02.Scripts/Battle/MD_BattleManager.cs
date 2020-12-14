using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniDoodles
{


    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2020.04.30 </para>
    /// <para> 내    용 : 전투를 관리하는 메서드 </para>
    /// </summary>
    public class MD_BattleManager : MD_Singlton<MD_BattleManager>
    {
        #region 전투에서 사용되는 열거형

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.30 </para>
        /// <para> 내    용 : 어느 팀인지 확인하는 열거형 </para>
        /// </summary>
        public enum TEAM
        {
            Left, Right
        }

        #endregion

        [Header("- Team")]
        public List<MD_Character> left_CharacterList;      // 왼쪽 팀의 캐릭터 배열
        public List<MD_Character> right_CharacterList;     // 오른쪽 팀의 캐릭터 배열

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.30 </para>
        /// <para> 내    용 : 전투를 시작 하는 메서드 </para>
        /// </summary>
        public void Func_BattleStart()
        {
            for (int i = 0; i < left_CharacterList.Count; i++)
            {
                left_CharacterList[i].Func_Attack();
            }

            for (int i = 0; i < right_CharacterList.Count; i++)
            {
                right_CharacterList[i].Func_Attack();
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.05.02 </para>
        /// <para> 내    용 : 캐릭터가 죽었을 때 해당 팀이 다 죽엇는지 체크하는 메서드</para>
        /// </summary>
        public void Func_CharacterDie(TEAM _team)
        {
            List<MD_Character> _characterArr;
            bool _isLeft;

            if (_team == TEAM.Left)
            {
                _isLeft = true;
                _characterArr = left_CharacterList;
            }
            else
            {
                _isLeft = false;
                _characterArr = right_CharacterList;
            }

            for (int i = 0; i < _characterArr.Count; i++)
            {
                if (!_characterArr[i].isDie)
                {
                    // 아직 다 죽지 않음
                    return;
                }
            }
            // 다 죽었다면 

            if (_isLeft)
            {
                // 왼쪽팀이 다 죽음

            }
            else
            {
                // 오른쪽 팀이 다 죽음

            }
        }
    }
}