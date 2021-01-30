# Class PseudoBodyClimbTarget

Controls a [PseudoBodyFacade] by the [ClimbingFacade] operation.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Properties]
  * [PseudoBodyFacade]
  * [Target]
* [Methods]
  * [ApplyVelocity(Vector3)]
  * [InteractableAdded()]
  * [InteractorAdded()]

## Details

##### Inheritance

* System.Object
* [ClimbTarget]
* PseudoBodyClimbTarget

##### Namespace

* [Tilia.Locomotors.Climbing.Target]

##### Syntax

```
public class PseudoBodyClimbTarget : ClimbTarget
```

### Properties

#### PseudoBodyFacade

The body representation to control.

##### Declaration

```
public PseudoBodyFacade PseudoBodyFacade { get; set; }
```

#### Target

The GameObject to move with the climbing operation.

##### Declaration

```
public override GameObject Target { get; }
```

##### Overrides

[ClimbTarget.Target]

### Methods

#### ApplyVelocity(Vector3)

Applies the given velocity to the [Target].

##### Declaration

```
public override void ApplyVelocity(Vector3 velocity)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| Vector3 | velocity | The velocity to apply. |

##### Overrides

[ClimbTarget.ApplyVelocity(Vector3)]

#### InteractableAdded()

Processed when an Interactable is added to the [ClimbingFacade].

##### Declaration

```
public override void InteractableAdded()
```

##### Overrides

[ClimbTarget.InteractableAdded()]

#### InteractorAdded()

Processed when an Interactor is added to the [ClimbingFacade].

##### Declaration

```
public override void InteractorAdded()
```

##### Overrides

[ClimbTarget.InteractorAdded()]

[PseudoBodyFacade]: PseudoBodyClimbTarget.md#PseudoBodyFacade
[ClimbingFacade]: ../ClimbingFacade.md
[ClimbTarget]: ClimbTarget.md
[Tilia.Locomotors.Climbing.Target]: README.md
[ClimbTarget.Target]: ClimbTarget.md#Tilia_Locomotors_Climbing_Target_ClimbTarget_Target
[Target]: ClimbTarget.md#Tilia_Locomotors_Climbing_Target_ClimbTarget_Target
[ClimbTarget.ApplyVelocity(Vector3)]: ClimbTarget.md#Tilia_Locomotors_Climbing_Target_ClimbTarget_ApplyVelocity_Vector3_
[ClimbTarget.InteractableAdded()]: ClimbTarget.md#Tilia_Locomotors_Climbing_Target_ClimbTarget_InteractableAdded
[ClimbTarget.InteractorAdded()]: ClimbTarget.md#Tilia_Locomotors_Climbing_Target_ClimbTarget_InteractorAdded
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Properties]: #Properties
[PseudoBodyFacade]: #PseudoBodyFacade
[Target]: #Target
[Methods]: #Methods
[ApplyVelocity(Vector3)]: #ApplyVelocityVector3
[InteractableAdded()]: #InteractableAdded
[InteractorAdded()]: #InteractorAdded
