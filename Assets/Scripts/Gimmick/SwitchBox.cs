using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SwitchBox : MonoBehaviour
{
    public EventTrigger _EventTrigger;

    //StopCoroutineのためにCoroutineで宣言しておく
    Coroutine PressCorutine;
    bool isPressDown = false;
    float PressTime = 1f;

    [SerializeField] Image image;
    [SerializeField] GameObject Open;

    void Awake()
    {
        //PointerDownイベントの登録
        EventTrigger.Entry pressdown = new EventTrigger.Entry();
        pressdown.eventID = EventTriggerType.PointerDown;
        pressdown.callback.AddListener((data) => PointerDown());
        _EventTrigger.triggers.Add(pressdown);

        //PointerUpイベントの登録
        EventTrigger.Entry pressup = new EventTrigger.Entry();
        pressup.eventID = EventTriggerType.PointerUp;
        pressup.callback.AddListener((data) => PointerUp());
        _EventTrigger.triggers.Add(pressup);
    }

    //EventTriggerのPointerDownイベントに登録する処理
    void PointerDown()
    {
        Debug.Log("Press Start");
        //連続でタップした時に長押しにならないよう前のCoroutineを止める
        if (PressCorutine != null)
        {
            StopCoroutine(PressCorutine);
        }
        //StopCoroutineで止められるように予め宣言したCoroutineに代入
        PressCorutine = StartCoroutine(TimeForPointerDown());
    }

    //長押しコルーチン
    IEnumerator TimeForPointerDown()
    {
        // 3回繰り返す
        for (int i = 0; i < 5; i++)
        {
            //プレス開始
            isPressDown = true;

            //待機時間
            yield return new WaitForSeconds(PressTime);

            //押されたままなら長押しの挙動
            if (isPressDown)
            {
                switch (i)
                {
                    case 0:
                        image.color = new Color(0.8f, 0.8f, 0.8f, 1.0f);
                        break;
                    case 1:
                        image.color = new Color(0.6f, 0.6f, 0.6f, 1.0f);
                        break;
                    case 2:
                        image.color = new Color(0.4f, 0.4f, 0.4f, 1.0f);
                        break;
                    case 3:
                        image.color = new Color(0.2f, 0.2f, 0.2f, 1.0f);
                        break;
                    case 4:
                        image.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
                        Open.SetActive(true);
                        break;
                }
            }
            //プレス処理終了
            isPressDown = false;

            // もし3回生成済だったらコルーチン終了
            if (i == 5)
            {
                yield break;
            }
        }
    }

    //EventTriggerのPointerUpイベントに登録する処理
    void PointerUp()
    {
        if (isPressDown)
        {
            Debug.Log("Short Press Done");
            isPressDown = false;
        }
        Debug.Log("Press End");
    }
}
