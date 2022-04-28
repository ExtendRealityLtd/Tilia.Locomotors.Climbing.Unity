# Class ClimbingFacade

The public interface for the Climbing prefab.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Fields]
  * [ClimbStarted]
  * [ClimbStopped]
* [Properties]
  * [Configuration]
  * [CurrentInteractable]
  * [CurrentInteractor]
  * [Interactables]
  * [Interactors]
  * [IsClimbing]
  * [PseudoBodyFacade]
  * [Target]
* [Methods]
  * [AddInteractable(GameObject)]
  * [AddInteractor(GameObject)]
  * [Awake()]
  * [ClearInteractables()]
  * [ClearInteractors()]
  * [ClearPseudoBodyFacade()]
  * [ClearTarget()]
  * [OnAfterPseudoBodyFacadeChange()]
  * [OnAfterTargetChange()]
  * [RemoveInteractable(GameObject)]
  * [RemoveInteractor(GameObject)]
  * [SetVelocityMultiplier(Vector3)]
  * [SetVelocitySource(GameObject)]

## Details

##### Inheritance

* System.Object
* ClimbingFacade

##### Namespace

* [Tilia.Locomotors.Climbing]

##### Syntax

```
public class ClimbingFacade : MonoBehaviour
```

### Fields

#### ClimbStarted

Emitted when a climb starts.

##### Declaration

```
public UnityEvent ClimbStarted
```

#### ClimbStopped

Emitted when the climb stops.

##### Declaration

```
public UnityEvent ClimbStopped
```

### Properties

#### Configuration

The linked [ClimbingConfigurator].

##### Declaration

```
public ClimbingConfigurator Configuration { get; protected set; }
```

#### CurrentInteractable

The current optional offset of the movement. The body will be moved in case this object moves.

##### Declaration

```
public virtual GameObject CurrentInteractable { get; }
```

#### CurrentInteractor

The current source of the movement. The body will be moved in reverse direction in case this object moves.

##### Declaration

```
public virtual GameObject CurrentInteractor { get; }
```

#### Interactables

The objects that define the optional offsets of movement in order they should be used. The last object defines [CurrentInteractable].

##### Declaration

```
public virtual IReadOnlyList<GameObject> Interactables { get; }
```

#### Interactors

The objects that define the source of movement in order they should be used. The last object defines [CurrentInteractor].

##### Declaration

```
public virtual IReadOnlyList<GameObject> Interactors { get; }
```

#### IsClimbing

Whether a climb is happening right now.

##### Declaration

```
public virtual bool IsClimbing { get; }
```

#### PseudoBodyFacade

The body representation to control.

##### Declaration

```
[Obsolete("Use `Target` instead.")]
public PseudoBodyFacade PseudoBodyFacade { get; set; }
```

#### Target

The target to move when climbing.

##### Declaration

```
public ClimbTarget Target { get; set; }
```

### Methods

#### AddInteractable(GameObject)

Adds an optional offset of movement for the body.

##### Declaration

```
public virtual void AddInteractable(GameObject interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactable | The object to use as an optional offset of the movement. |

#### AddInteractor(GameObject)

Adds a source of movement for the body.

##### Declaration

```
public virtual void AddInteractor(GameObject interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactor | The object to use as a source of the movement. |

#### Awake()

##### Declaration

```
protected virtual void Awake()
```

#### ClearInteractables()

Clears the optional offsets of the movement.

##### Declaration

```
public virtual void ClearInteractables()
```

#### ClearInteractors()

Clears the sources of the movement.

##### Declaration

```
public virtual void ClearInteractors()
```

#### ClearPseudoBodyFacade()

Clears [PseudoBodyFacade].

##### Declaration

```
[Obsolete("`ClimbingFacade.PseudoBodyFacade` has been deprecated. Use `ClimbingFacade.Target` instead.")]
public virtual void ClearPseudoBodyFacade()
```

#### ClearTarget()

Clears [Target].

##### Declaration

```
public virtual void ClearTarget()
```

#### OnAfterPseudoBodyFacadeChange()

Called after [PseudoBodyFacade] has been changed.

##### Declaration

```
protected virtual void OnAfterPseudoBodyFacadeChange()
```

#### OnAfterTargetChange()

Called after [Target] has been changed.

##### Declaration

```
protected virtual void OnAfterTargetChange()
```

#### RemoveInteractable(GameObject)

Removes an optional offset of movement for the body.

##### Declaration

```
public virtual void RemoveInteractable(GameObject interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactable | The object used as an optional offset of the movement. |

#### RemoveInteractor(GameObject)

Removes a source of movement for the body.

##### Declaration

```
public virtual void RemoveInteractor(GameObject interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactor | The object used as a source of the movement. |

#### SetVelocityMultiplier(Vector3)

Sets the multiplier to apply to any tracked velocity.

##### Declaration

```
public virtual void SetVelocityMultiplier(Vector3 multiplier)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| Vector3 | multiplier | The multiplier to apply to tracked velocity. |

#### SetVelocitySource(GameObject)

Sets a source to track the velocity from.

##### Declaration

```
public virtual void SetVelocitySource(GameObject source)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | source | The tracked velocity source. |

[Tilia.Locomotors.Climbing]: README.md
[ClimbingConfigurator]: ClimbingConfigurator.md
[CurrentInteractable]: ClimbingFacade.md#CurrentInteractable
[CurrentInteractor]: ClimbingFacade.md#CurrentInteractor
[ClimbTarget]: Target/ClimbTarget.md
[PseudoBodyFacade]: ClimbingFacade.md#PseudoBodyFacade
[Target]: ClimbingFacade.md#Target
[PseudoBodyFacade]: ClimbingFacade.md#PseudoBodyFacade
[Target]: ClimbingFacade.md#Target
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Fields]: #Fields
[ClimbStarted]: #ClimbStarted
[ClimbStopped]: #ClimbStopped
[Properties]: #Properties
[Configuration]: #Configuration
[CurrentInteractable]: #CurrentInteractable
[CurrentInteractor]: #CurrentInteractor
[Interactables]: #Interactables
[Interactors]: #Interactors
[IsClimbing]: #IsClimbing
[PseudoBodyFacade]: #PseudoBodyFacade
[Target]: #Target
[Methods]: #Methods
[AddInteractable(GameObject)]: #AddInteractableGameObject
[AddInteractor(GameObject)]: #AddInteractorGameObject
[Awake()]: #Awake
[ClearInteractables()]: #ClearInteractables
[ClearInteractors()]: #ClearInteractors
[ClearPseudoBodyFacade()]: #ClearPseudoBodyFacade
[ClearTarget()]: #ClearTarget
[OnAfterPseudoBodyFacadeChange()]: #OnAfterPseudoBodyFacadeChange
[OnAfterTargetChange()]: #OnAfterTargetChange
[RemoveInteractable(GameObject)]: #RemoveInteractableGameObject
[RemoveInteractor(GameObject)]: #RemoveInteractorGameObject
[SetVelocityMultiplier(Vector3)]: #SetVelocityMultiplierVector3
[SetVelocitySource(GameObject)]: #SetVelocitySourceGameObject
