using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UIButton : UIBase
{
    public event Action OnClick;

    public void OnClicked()
    {
        OnClick?.Invoke();
    }
}
