using System;

[Serializable]
public class UIButton : UIBase
{
    public event Action OnClick;

    public void OnClicked()
    {
        OnClick?.Invoke();
    }
}
