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
public ClimbableConfigurator Configuration { get; protected set; }
```

#### ReleaseMultiplier

The multiplier to apply to the velocity of the interactor when the interactable is released and climbing stops.

##### Declaration

```
public Vector3 ReleaseMultiplier { get; set; }
```

[Tilia.Locomotors.Climbing]: README.md
[ClimbingFacade]: ClimbableFacade.md#ClimbingFacade
[ClimbingFacade]: ClimbingFacade.md
[ClimbableConfigurator]: ClimbableConfigurator.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Properties]: #Properties
[ClimbingFacade]: #ClimbingFacade
[Configuration]: #Configuration
[ReleaseMultiplier]: #ReleaseMultiplier
