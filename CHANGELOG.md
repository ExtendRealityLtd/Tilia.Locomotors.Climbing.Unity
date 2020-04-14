# Changelog

## [1.1.0](https://github.com/ExtendRealityLtd/Tilia.Locomotors.Climbing.Unity/compare/v1.0.2...v1.1.0) (2020-04-14)

#### Features

* **Interactions:** update interactor attach point extraction ([9d3ff74](https://github.com/ExtendRealityLtd/Tilia.Locomotors.Climbing.Unity/commit/9d3ff740c93ae1f707a4aba30a4141d360d7dc28))
  > Tilia.Interactions.Interactables.Unity 1.7.0 includes a new extractor for extracting the Interactor Attach Point and the old method has been deprecated.
  > 
  > The new InteractorAttachPointExtractor is now being used in the Climbable prefab.
  > 
  > All dependencies have also been bumped to their latest version for full compatibility.

### [1.0.2](https://github.com/ExtendRealityLtd/Tilia.Locomotors.Climbing.Unity/compare/v1.0.1...v1.0.2) (2020-04-08)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.tilia.trackers.pseudobody.unity ([b4f30f6](https://github.com/ExtendRealityLtd/Tilia.Locomotors.Climbing.Unity/commit/b4f30f6c799f67255cef9ef69736aa7256fa4158))
  > Bumps [io.extendreality.tilia.trackers.pseudobody.unity](https://github.com/ExtendRealityLtd/Tilia.Trackers.PseudoBody.Unity) from 1.0.1 to 1.0.2. - [Release notes](https://github.com/ExtendRealityLtd/Tilia.Trackers.PseudoBody.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Tilia.Trackers.PseudoBody.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Tilia.Trackers.PseudoBody.Unity/compare/v1.0.1...v1.0.2)
  > 
  > Signed-off-by: dependabot-preview[bot] <support@dependabot.com>

### [1.0.1](https://github.com/ExtendRealityLtd/Tilia.Locomotors.Climbing.Unity/compare/v1.0.0...v1.0.1) (2020-04-08)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.tilia.interactions.interactables.unity ([e72e89b](https://github.com/ExtendRealityLtd/Tilia.Locomotors.Climbing.Unity/commit/e72e89b22eeded71dc68b9a793f0794cd9e5b27c))
  > Bumps [io.extendreality.tilia.interactions.interactables.unity](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity) from 1.6.0 to 1.6.1. - [Release notes](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Tilia.Interactions.Interactables.Unity/compare/v1.6.0...v1.6.1)
  > 
  > Signed-off-by: dependabot-preview[bot] <support@dependabot.com>

## 1.0.0 (2020-04-07)

#### Features

* **structure:** port climbing prefabs ([df2c50f](https://github.com/ExtendRealityLtd/Tilia.Locomotors.Climbing.Unity/commit/df2c50fae3ed1a7f517f55a83099aa167ea432de))
  > The climbing prefabs from VRTK.Prefabs have now been ported over into this newly named Tilia repo with some small reworks.

#### Bug Fixes

* **structure:** remove unrequired meta file for missing directory ([a3b003c](https://github.com/ExtendRealityLtd/Tilia.Locomotors.Climbing.Unity/commit/a3b003c993c3e8ff7f728edb78247f843b54d2da))
  > The NestedPrefabs directory isn't required so therefore was never committed, however the .meta file still was checked in which is incorrect so it has now been deleted.
