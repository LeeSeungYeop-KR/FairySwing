﻿using System.Collections;
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
        [Header("- A, B, C 확률 배열")]
        [SerializeField] private MD_RandomBoxData[] probabilityArr;

        [Header("- A 랜덤 아이템 배열")]
        [SerializeField] private MD_RandomBoxData[] item_A_PrizeArr;

        [Header("- B 랜덤 아이템 배열")]
        [SerializeField] private MD_RandomBoxData[] item_B_PrizeArr;

        [Header("- C 랜덤 아이템 배열")]
        [SerializeField] private MD_RandomBoxData[] item_C_PrizeArr;

        [Header("- 테스트 꽝 배열")]
        [SerializeField] private string[] test_loseArr;

        [Header("- 텍스트 배열")]
        [SerializeField] private Text[] testTextArr;


        [Header("- 테스트 결과 텍스트 배열")]
        [SerializeField] private Text[] testResultTextArr;

        private int[] testResultArr = new int[17];
        private int testNum = 0;

        public void Button_RandomBox()
        {
            for (int i = 0; i < testTextArr.Length; i++)
            {
                testResultArr[16]++;
                testTextArr[i].text = Func_RandomText();
            }

        }

        private string Func_RandomText()
        {
            switch (Func_CheckRating())
            {
                case 0:
                    // A
                    testResultArr[0]++;
                    testNum = 0;
                    return Func_RandomBox(item_A_PrizeArr);

                case 1:
                    // B
                    testResultArr[4]++;
                    testNum = 4;
                    return Func_RandomBox(item_B_PrizeArr);

                case 2:
                    // C
                    testResultArr[8]++;
                    testNum = 8;
                    return Func_RandomBox(item_C_PrizeArr);
            }

            // 꽝
            int _rand = UnityEngine.Random.Range(0, test_loseArr.Length);
            // 테스트
            testResultArr[12]++;
            testResultArr[13 + _rand]++;
            for (int j = 0; j < testResultTextArr.Length; j++)
            {
                testResultTextArr[j].text = testResultArr[j].ToString();
            }

            return test_loseArr[_rand];
        }

        private int Func_CheckRating()
        {
            int _rand = UnityEngine.Random.Range(1, 101);

            for (int i = 0; i < probabilityArr.Length; i++)
            {
                if (probabilityArr[i].probability >= _rand)
                {
                    return i;
                }
            }

            return 10;
        }

        private string Func_RandomBox(MD_RandomBoxData[] _data)
        {
            int _rand = UnityEngine.Random.Range(1, 101);
            for (int i = 0; i < _data.Length; i++)
            {
                if (_data[i].probability >= _rand)
                {
                    testNum += i + 1;
                    testResultArr[testNum]++;
                    // 테스트
                    for (int j = 0; j < testResultTextArr.Length; j++)
                    {
                        testResultTextArr[j].text = testResultArr[j].ToString();
                    }
                    return _data[i].itemIndex;
                }
            }

            // 테스트
            for (int i = 0; i < testResultTextArr.Length; i++)
            {
                testResultTextArr[i].text = testResultArr[i].ToString();
            }
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