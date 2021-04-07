namespace Tilia.Locomotors.Climbing.Utility
{
    using System.IO;
    using UnityEditor;
    using Zinnia.Utility;

    public class PrefabCreator : BasePrefabCreator
    {
        private const string group = "Tilia/";
        private const string project = "Locomotors/Climbing/";
        private const string menuItemRoot = topLevelMenuLocation + group + subLevelMenuLocation + project;

        private const string package = "io.extendreality.tilia.locomotors.climbing.unity";
        private const string baseDirectory = "Runtime";
        private const string prefabDirectory = "Prefabs";
        private const string prefabSuffix = ".prefab";

        private const string prefabLocomotorsClimbing = "Locomotors.Climbing";
        private const string prefabInteractionsClimbable = "Interactions.Climbable";

        [MenuItem(menuItemRoot + prefabLocomotorsClimbing, false, priority)]
        private static void AddLocomotorsClimbing()
        {
            string prefab = prefabLocomotorsClimbing + prefabSuffix;
            string packageLocation = Path.Combine(packageRoot, package, baseDirectory, prefabDirectory, prefab);
            CreatePrefab(packageLocation);
        }

        [MenuItem(topLevelMenuLocation + group + subLevelMenuLocation + "Interactions/Interactables/" + prefabInteractionsClimbable, false, priority)]
        private static void AddInteractionsClimbable()
        {
            string prefab = prefabInteractionsClimbable + prefabSuffix;
            string packageLocation = Path.Combine(packageRoot, package, baseDirectory, prefabDirectory, prefab);
            CreatePrefab(packageLocation);
        }
    }
}