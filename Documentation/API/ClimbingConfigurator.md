# Class ClimbingConfigurator

Sets up the Climbing prefab based on the provided user settings.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Properties]
  * [Facade]
  * [Interactables]
  * [Interactors]
  * [OffsetDistanceComparator]
  * [SourceDistanceComparator]
  * [TargetPositionProperty]
  * [VelocityEmitter]
  * [VelocityMultiplier]
  * [VelocityProxy]
* [Methods]
  * [ApplyVelocity()]
  * [ConfigureTargetPositionProperty()]
  * [OnDisable()]
  * [OnEnable()]
  * [OnInteractableAdded(GameObject)]
  * [OnInteractableRemoved(GameObject)]
  * [OnInteractorAdded(GameObject)]
  * [OnInteractorRemoved(GameObject)]
  * [OnListBecameEmpty(GameObject)]
  * [OnListBecamePopulated(GameObject)]

## Details

##### Inheritance

* System.Object
* ClimbingConfigurator

##### Namespace

* [Tilia.Locomotors.Climbing]

##### Syntax

```
public class ClimbingConfigurator : MonoBehaviour
```

### Properties

#### Facade

The public interface facade.

##### Declaration

```
public ClimbingFacade Facade { get; set; }
```

#### Interactables

The objects defining the offsets of movement.

##### Declaration

```
public GameObjectObservableList Interactables { get; set; }
```

#### Interactors

The objects defining the sources of movement.

##### Declaration

```
public GameObjectObservableList Interactors { get; set; }
```

#### OffsetDistanceComparator

The ObjectDistanceComparator component for the offset.

##### Declaration

```
public ObjectDistanceComparator OffsetDistanceComparator { get; set; }
```

#### SourceDistanceComparator

The ObjectDistanceComparator component for the source.

##### Declaration

```
public ObjectDistanceComparator SourceDistanceComparator { get; set; }
```

#### TargetPositionProperty

The TransformPositionMutator component for the offset.

##### Declaration

```
public TransformPositionMutator TargetPositionProperty { get; set; }
```

#### VelocityEmitter

The Zinnia.Tracking.Velocity.VelocityEmitter component for emitting velocity data.

##### Declaration

```
public VelocityEmitter VelocityEmitter { get; set; }
```

#### VelocityMultiplier

The Vector3Multiplier component for multiplying velocity data.

##### Declaration

```
public Vector3Multiplier VelocityMultiplier { get; set; }
```

#### VelocityProxy

The ComponentTrackerProxy component for obtaining velocity data.

##### Declaration

```
public ComponentTrackerProxy VelocityProxy { get; set; }
```

### Methods

#### ApplyVelocity()

Applies velocity to the PseudoBody.

##### Declaration

```
public virtual void ApplyVelocity()
```

#### ConfigureTargetPositionProperty()

Configures the [TargetPositionProperty] based on the facade settings.

##### Declaration

```
public virtual void ConfigureTargetPositionProperty()
```

#### OnDisable()

##### Declaration

```
protected virtual void OnDisable()
```

#### OnEnable()

##### Declaration

```
protected virtual void OnEnable()
```

#### OnInteractableAdded(GameObject)

Configures the [OffsetDistanceComparator] when an interactable is added.

##### Declaration

```
protected virtual void OnInteractableAdded(GameObject interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactable | The added interactable. |

#### OnInteractableRemoved(GameObject)

Configures the [OffsetDistanceComparator] when an interactable is removed.

##### Declaration

```
protected virtual void OnInteractableRemoved(GameObject interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactable | The removed interactable. |

#### OnInteractorAdded(GameObject)

Configures the [SourceDistanceComparator] when an interactor is added.

##### Declaration

```
protected virtual void OnInteractorAdded(GameObject interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactor | The added interactor. |

#### OnInteractorRemoved(GameObject)

Configures the [SourceDistanceComparator] when an interactor is removed.

##### Declaration

```
protected virtual void OnInteractorRemoved(GameObject interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactor | The removed interactor. |

#### OnListBecameEmpty(GameObject)

Emits a climb stopped event when the list becomes empty.

##### Declaration

```
protected virtual void OnListBecameEmpty(GameObject removedElement)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | removedElement | The element removed. |

#### OnListBecamePopulated(GameObject)

Emits a climb started event when the list becomes populated.

##### Declaration

```
protected virtual void OnListBecamePopulated(GameObject addedElement)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | addedElement | The element added. |

[Tilia.Locomotors.Climbing]: README.md
[ClimbingFacade]: ClimbingFacade.md
[TargetPositionProperty]: ClimbingConfigurator.md#TargetPositionProperty
[OffsetDistanceComparator]: ClimbingConfigurator.md#OffsetDistanceComparator
[OffsetDistanceComparator]: ClimbingConfigurator.md#OffsetDistanceComparator
[SourceDistanceComparator]: ClimbingConfigurator.md#SourceDistanceComparator
[SourceDistanceComparator]: ClimbingConfigurator.md#SourceDistanceComparator
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Properties]: #Properties
[Facade]: #Facade
[Interactables]: #Interactables
[Interactors]: #Interactors
[OffsetDistanceComparator]: #OffsetDistanceComparator
[SourceDistanceComparator]: #SourceDistanceComparator
[TargetPositionProperty]: #TargetPositionProperty
[VelocityEmitter]: #VelocityEmitter
[VelocityMultiplier]: #VelocityMultiplier
[VelocityProxy]: #VelocityProxy
[Methods]: #Methods
[ApplyVelocity()]: #ApplyVelocity
[ConfigureTargetPositionProperty()]: #ConfigureTargetPositionProperty
[OnDisable()]: #OnDisable
[OnEnable()]: #OnEnable
[OnInteractableAdded(GameObject)]: #OnInteractableAddedGameObject
[OnInteractableRemoved(GameObject)]: #OnInteractableRemovedGameObject
[OnInteractorAdded(GameObject)]: #OnInteractorAddedGameObject
[OnInteractorRemoved(GameObject)]: #OnInteractorRemovedGameObject
[OnListBecameEmpty(GameObject)]: #OnListBecameEmptyGameObject
[OnListBecamePopulated(GameObject)]: #OnListBecamePopulatedGameObject
