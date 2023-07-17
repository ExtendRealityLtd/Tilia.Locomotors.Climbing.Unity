# Class ClimbableFacade

The public interface for the Interactions.Climbable prefab.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Properties]
  * [ClimbingFacade]
  * [Configuration]
  * [ReleaseMultiplier]
* [Methods]
  * [SetReleaseMultiplierX(Single)]
  * [SetReleaseMultiplierY(Single)]
  * [SetReleaseMultiplierZ(Single)]

## Details

##### Inheritance

* System.Object
* ClimbableFacade

##### Namespace

* [Tilia.Locomotors.Climbing]

##### Syntax

```
public class ClimbableFacade : MonoBehaviour
```

### Properties

#### ClimbingFacade

The [ClimbingFacade] to use.

##### Declaration

```
public ClimbingFacade ClimbingFacade { get; set; }
```

#### Configuration

The linked [ClimbableConfigurator].

##### Declaration

```
public ClimbableConfigurator Configuration { get; set; }
```

#### ReleaseMultiplier

The multiplier to apply to the velocity of the interactor when the interactable is released and climbing stops.

##### Declaration

```
public Vector3 ReleaseMultiplier { get; set; }
```

### Methods

#### SetReleaseMultiplierX(Single)

Sets the [ReleaseMultiplier] x value.

##### Declaration

```
public virtual void SetReleaseMultiplierX(float value)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Single | value | The value to set to. |

#### SetReleaseMultiplierY(Single)

Sets the [ReleaseMultiplier] y value.

##### Declaration

```
public virtual void SetReleaseMultiplierY(float value)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Single | value | The value to set to. |

#### SetReleaseMultiplierZ(Single)

Sets the [ReleaseMultiplier] z value.

##### Declaration

```
public virtual void SetReleaseMultiplierZ(float value)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Single | value | The value to set to. |

[Tilia.Locomotors.Climbing]: README.md
[ClimbingFacade]: ClimbableFacade.md#ClimbingFacade
[ClimbingFacade]: ClimbingFacade.md
[ClimbableConfigurator]: ClimbableConfigurator.md
[ReleaseMultiplier]: ClimbableFacade.md#ReleaseMultiplier
[ReleaseMultiplier]: ClimbableFacade.md#ReleaseMultiplier
[ReleaseMultiplier]: ClimbableFacade.md#ReleaseMultiplier
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Properties]: #Properties
[ClimbingFacade]: #ClimbingFacade
[Configuration]: #Configuration
[ReleaseMultiplier]: #ReleaseMultiplier
[Methods]: #Methods
[SetReleaseMultiplierX(Single)]: #SetReleaseMultiplierXSingle
[SetReleaseMultiplierY(Single)]: #SetReleaseMultiplierYSingle
[SetReleaseMultiplierZ(Single)]: #SetReleaseMultiplierZSingle
