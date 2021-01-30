# Class ClimbTarget

The abstract target that can be controlled by the [ClimbingFacade].

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Properties]
  * [Target]
* [Methods]
  * [ApplyVelocity(Vector3)]
  * [InteractableAdded()]
  * [InteractorAdded()]

## Details

##### Inheritance

* System.Object
* ClimbTarget
* [PseudoBodyClimbTarget]

##### Namespace

* [Tilia.Locomotors.Climbing.Target]

##### Syntax

```
public abstract class ClimbTarget : MonoBehaviour
```

### Properties

#### Target

The GameObject to move with the climbing operation.

##### Declaration

```
public abstract GameObject Target { get; }
```

### Methods

#### ApplyVelocity(Vector3)

Applies the given velocity to the [Target].

##### Declaration

```
public abstract void ApplyVelocity(Vector3 velocity)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| Vector3 | velocity | The velocity to apply. |

#### InteractableAdded()

Processed when an Interactable is added to the [ClimbingFacade].

##### Declaration

```
public abstract void InteractableAdded()
```

#### InteractorAdded()

Processed when an Interactor is added to the [ClimbingFacade].

##### Declaration

```
public abstract void InteractorAdded()
```

[ClimbingFacade]: ../ClimbingFacade.md
[PseudoBodyClimbTarget]: PseudoBodyClimbTarget.md
[Tilia.Locomotors.Climbing.Target]: README.md
[Target]: ClimbTarget.md#Target
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Properties]: #Properties
[Target]: #Target
[Methods]: #Methods
[ApplyVelocity(Vector3)]: #ApplyVelocityVector3
[InteractableAdded()]: #InteractableAdded
[InteractorAdded()]: #InteractorAdded
