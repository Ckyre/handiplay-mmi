using UnityEngine;
using UnityEngine.UI;

public class MenuToggle : MenuButton
{
    public Animator toggle;
    public AudioClip activateClip, desactivateClip;

    private bool value;

    public override void Landing(bool playVoiceOver = true)
    {
        base.Landing();
        if (playVoiceOver) ReadVoiceOver();        
    }

    public override void Validate()
    {
        value = !value;
        Toggle(value);
    }

    public virtual void Toggle(bool _value)
    {
        toggle.SetBool("isActive", _value);
        ReadVoiceOver();
    }

    public override void ReadVoiceOver()
    {
        if (GameManager.instance.settings.hearingHelp)
        {
            if (value) VoiceOverManager.instance.Read(activateClip);
            else VoiceOverManager.instance.Read(desactivateClip);
        }
    }

    public void SetValue(bool newValue)
    {
        value = newValue;
    }
}
