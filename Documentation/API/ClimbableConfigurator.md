# Class ClimbableConfigurator

Sets up the Interactions.Climbable prefab based on the provided user settings.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Properties]
  * [Facade]
  * [InteractableFacade]
  * [StartEventProxyEmitter]
  * [StopEventProxyEmitter]
* [Methods]
  * [OnDisable()]
  * [OnEnable()]
  * [OnStartEventProxyEmitted(GameObject)]
  * [OnStopEventProxyEmitted(GameObject)]

## Details

##### Inheritance

* System.Object
* ClimbableConfigurator

##### Namespace

* [Tilia.Locomotors.Climbing]

##### Syntax

```
public class ClimbableConfigurator : MonoBehaviour
```

### Properties

#### Facade

The public interface facade.

##### Declaration

```
public ClimbableFacade Facade { get; set; }
```

#### InteractableFacade

The [InteractableFacade] component acting as the interactable for climbing.

##### Declaration

```
public InteractableFacade InteractableFacade { get; set; }
```

#### StartEventProxyEmitter

The GameObjectEventProxyEmitter component handling a started climb.

##### Declaration

```
public GameObjectEventProxyEmitter StartEventProxyEmitter { get; set; }
```

#### StopEventProxyEmitter

The GameObjectEventProxyEmitter component handling a stopped climb.

##### Declaration

```
public GameObjectEventProxyEmitter StopEventProxyEmitter { get; set; }
```

### Methods

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

#### OnStartEventProxyEmitted(GameObject)

Processes the start climbing functionality.

##### Declaration

```
protected virtual void OnStartEventProxyEmitted(GameObject interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactor | The interactor initiating the climb. |

#### OnStopEventProxyEmitted(GameObject)

Processes the stop climbing functionality.

##### Declaration

```
protected virtual void OnStopEventProxyEmitted(GameObject interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactor | The interactor that is no longer climbing. |

[Tilia.Locomotors.Climbing]: README.md
[ClimbableFacade]: ClimbableFacade.md
[InteractableFacade]: ClimbableConfigurator.md#InteractableFacade
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Properties]: #Properties
[Facade]: #Facade
[InteractableFacade]: #InteractableFacade
[StartEventProxyEmitter]: #StartEventProxyEmitter
[StopEventProxyEmitter]: #StopEventProxyEmitter
[Methods]: #Methods
[OnDisable()]: #OnDisable
[OnEnable()]: #OnEnable
[OnStartEventProxyEmitted(GameObject)]: #OnStartEventProxyEmittedGameObject
[OnStopEventProxyEmitted(GameObject)]: #OnStopEventProxyEmittedGameObject
