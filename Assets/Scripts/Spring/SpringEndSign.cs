using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SpringEndSign : MonoBehaviour
{
    public GameObject result;  //결과 팝업창
    public Timer timer;        //시간 가져오기
    public TextMeshProUGUI NumOfCus;      //팝업창 손님 수
    public TextMeshProUGUI Time;          //팝업창 시간
    public Image Face;         //팝업창 만족도 이미지
    
    int comfortNum;     //만족도 1(좋음), 0(보통), -1(나쁨)

    string wheel;
    bool wheel1, wheel2, wheel3, wheel4;

    void Start()
    { 
        wheel1 = false;
        wheel2 = false;
        wheel3 = false;
        wheel4 = false;
    }

    void OnTriggerStay(Collider coll)
    {
        wheel = coll.gameObject.name;
        if (wheel == "BUS_wheelLB")
            wheel1 = true;
        else if (wheel == "BUS_wheelLF")
            wheel2 = true;
        else if (wheel == "BUS_wheelRB")
            wheel3 = true;
        else if (wheel == "BUS_wheelRF")
            wheel4 = true;

        if (wheel1 && wheel2 && wheel3 && wheel4)
        {
            NumOfCus.text = SpringTotal.SumOfCus.ToString();      //계절 스크립트별
            timer.TimerPause();         //시간 정지
            Time.text = timer.GetTime();    //시간 팝업창
            SetResultFace();
            result.SetActive(true);     //엔딩 팝업창 나타남

            //기록 업데이트
            BestScore.UpdateSpring(comfortNum, timer.GetMin(), timer.GetSec(), SpringTotal.SumOfCus);
        }
    }

    void SetResultFace()
    {
        int comfort = SpringComfort.comfort;

        if (comfort >= 80)
        {
            Face.sprite = Resources.Load<Sprite>("UI/기록_좋음");
            comfortNum = 1;
        }
        else if (comfort >= 40)
        {
            Face.sprite = Resources.Load<Sprite>("UI/기록_보통");
            comfortNum = 0;
        }
        else
        {
            Face.sprite = Resources.Load<Sprite>("UI/기록_나쁨");
            comfortNum = -1;
        }
    }
}