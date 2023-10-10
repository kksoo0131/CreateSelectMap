using UnityEngine;
using UnityEngine.UI;

public class UISelect : MonoBehaviour
{
    LocationInfo info;
    private void Awake()
    {
    }
    public void InitSelect(LocationInfo infomation)
    {
        info = infomation;
        // floor의 길이를 10으로 나눴을때
        transform.localPosition = new Vector3(-380 + 20 + 720 / 9 * info.Index, transform.position.y, 0); 

        // -380 == floor의길이 / 2 * -1
        // +20 == icon의 width / 2
        // 720 == floor의 길이 - icon의 width
        // 최대 인덱스 0 ~ 9
        // info.Index 현재 인덱스

        // 놓아도 되는 범위는? -360 ~ 360 여기에 10개까지 들어간다.
    }
}