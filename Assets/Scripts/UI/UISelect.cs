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
        // floor�� ���̸� 10���� ��������
        transform.localPosition = new Vector3(-380 + 20 + 720 / 9 * info.Index, transform.position.y, 0); 

        // -380 == floor�Ǳ��� / 2 * -1
        // +20 == icon�� width / 2
        // 720 == floor�� ���� - icon�� width
        // �ִ� �ε��� 0 ~ 9
        // info.Index ���� �ε���

        // ���Ƶ� �Ǵ� ������? -360 ~ 360 ���⿡ 10������ ����.
    }
}