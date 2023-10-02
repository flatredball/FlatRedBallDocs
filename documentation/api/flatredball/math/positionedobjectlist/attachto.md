# Introduction

The AttachTo method is a shortcut method for attaching all contained elements in the list to the argument. The method's contents are as follows:

```
public void AttachTo(PositionedObject newParent, bool changeRelative)
{
    for (int i = 0; i < Count; i++)
    {
        this[i].AttachTo(newParent, changeRelative);
    }
}
```

For more information on the AttachTo method, see the [IAttachable page](../../../../../frb/docs/index.php).
