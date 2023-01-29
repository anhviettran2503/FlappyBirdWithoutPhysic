using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Panel : MonoBehaviour
{
    [SerializeField] private GameObject content;
    protected PanelType type;
    public PanelType Type;
    protected virtual void Start()
    {
    }
    public virtual void Enable()
    {
        content.SetActive(true);
    }
    public virtual void Disable()
    {
        content.SetActive(false);
    }

}
