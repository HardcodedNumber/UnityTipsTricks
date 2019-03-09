This repository is simply useful editor and runtime tips and tricks that have helped me along the way. Hopefully you find the stuff in here useful!
# Unity Tips and Tricks

# Inspector Buttons
Generate a button in a MonoBehaviour or ScriptableObject

![Example](https://i.imgur.com/zxVGkH8.gifv)

## Usage
Simply add the following attribute to any non-parameterized method.
```csharp
using Source.Runtime.Core;

[Button]
private void CreatePlayer()
{
    
}
```

# Required Fields
Are you tired of people forgetting to set a field? Now make it obvious!

![Example](https://i.imgur.com/lFIhs59.gifv)
![Example](https://i.imgur.com/GUkXxYU.gifv)
This is the first version of Required Fields. I want to later make it a complier error so it is self evident when something isn't working. 

## Usage
Simply add the following attribute to any class member that is public or SerializeField
```csharp
using Source.Runtime.Core;

    public sealed class PlayerData : ScriptableObject
    {
        [SerializeField, RequiredField(RequiredFieldType.Mandatory)]
        private Player _player = null;
    }
```

# Copy Full Path
In the Project window, copy the full directory path to the clipboard.

## Usage
Project Window, right click any asset or folder under the Assets folder.