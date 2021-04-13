using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniDoodles
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021.04.01 </para>
    /// <para> 내    용 : 인벤토리의 정보창 클래스 </para>
    /// </summary>
    public class MD_RandomBox : MonoBehaviour
    {
        #region 랜덤박스 데이터 구조체

        [System.Serializable]
        struct MD_RandomBoxDataPool
        {
            public string itemName;
            public MD_RandomBoxData[] itemPrizeArr;
        }

        #endregion

        [Header("- 각 등급의 확률 배열")]
        [SerializeField] private MD_RandomBoxData[] probabilityArr;     // 각 등급의 확률 배열

        [Header("- 각 등급의 랜덤 아이템 배열")]
        [SerializeField] private MD_RandomBoxDataPool[] itemDataArr;

        [Header("- 텍스트 배열")]
        [SerializeField] private Text[] testTextArr;


        [Header("- 테스트 결과 텍스트 배열")]
        [SerializeField] private Text[] testResultTextArr;

        private int[] testResultArr = new int[13];
        private int testNum = 0;

        public void Button_RandomBox()
        {
            for (int i = 0; i < testTextArr.Length; i++)
            {
                testResultArr[12]++;
                testTextArr[i].text = Func_RandomText();
            }
        }

        private string Func_RandomText()
        {
            int _ratingNum = Func_CheckRating();

            // 테스트
            switch (_ratingNum)
            {
                case 0:
                    // A
                    testResultArr[0]++;
                    testNum = 0;
                    break;

                case 1:
                    // B
                    testResultArr[4]++;
                    testNum = 4;
                    break;

                case 2:
                    // C
                    testResultArr[8]++;
                    testNum = 8;
                    break;
            }
            // 테스트 끝

            return Func_RandomBox(itemDataArr[_ratingNum].itemPrizeArr);
        }

        private int Func_CheckRating()
        {
            int _rand = UnityEngine.Random.Range(1, 101);
            float _probabilityAll = 0.0f;

            for (int i = 0; i < probabilityArr.Length; i++)
            {
                _probabilityAll += probabilityArr[i].probability;
                if (_probabilityAll >= _rand)
                {
                    return i;
                }
            }

            Debug.Log("asda11111");
            return probabilityArr.Length - 1;   // 확률의 총 합이 100 이하일 때 마지막 확률로 줌
        }

        private string Func_RandomBox(MD_RandomBoxData[] _data)
        {
            int _rand = UnityEngine.Random.Range(1, 101);
            float _probabilityAll = 0.0f;

            for (int i = 0; i < _data.Length; i++)
            {
                _probabilityAll += _data[i].probability;
                if (_probabilityAll >= _rand)
                {
                    // 테스트
                    testNum += i + 1;
                    testResultArr[testNum]++;
                    for (int j = 0; j < testResultTextArr.Length; j++)
                    {
                        testResultTextArr[j].text = testResultArr[j].ToString();
                    }
                    // 테스트 끝

                    return _data[i].itemIndex;
                }
            }

            Debug.Log("asda2222");
            return _data[_data.Length - 1].itemIndex;
        }

        private bool Func_RandomPercent(float _probability)
        {
            if (_probability < 0.0000001f)
            {
                _probability = 0.0000001f;
            }

            _probability = _probability / 100;

            bool _isSuccess = false;
            int _randAccuracy = 10000000;
            float _randHitRange = _probability * 10000000;
            int _rand = UnityEngine.Random.Range(1, _randAccuracy + 1);
            if (_rand <= _randHitRange)
            {
                _isSuccess = true;
            }

            return _isSuccess;
        }
    }
}