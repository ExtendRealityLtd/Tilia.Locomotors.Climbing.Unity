namespace Tilia.Locomotors.Climbing.Interactables
{
    using Tilia.Interactions.Interactables.Interactables;
    using UnityEditor;
    using UnityEngine;

    [InitializeOnLoad]
    public class ClimbableCreatorEditorWindow : EditorWindow
    {
        private const string windowPath = "Window/Tilia/Interactions/";
        private const string windowTitle = "Climbable Creator";
        private const string assetName = "Interactions.Climbable";
        private const string assetSuffix = ".prefab";
        private const string buttonText = "Convert To Climbable";
        private const string climbingFacadeLabel = "Climbing Facade";
        private static EditorWindow promptWindow;
        private Vector2 scrollPosition;
        private GameObject climbablePrefab;
        private ClimbingFacade climbingFacade;

        public void OnGUI()
        {
            using (GUILayout.ScrollViewScope scrollViewScope = new GUILayout.ScrollViewScope(scrollPosition))
            {
                scrollPosition = scrollViewScope.scrollPosition;
                GUILayout.Label(windowTitle, EditorStyles.boldLabel);
                climbingFacade = (ClimbingFacade)EditorGUILayout.ObjectField(climbingFacadeLabel, climbingFacade, typeof(ClimbingFacade), true);
                if (GUILayout.Button(buttonText))
                {
                    ProcessSelectedGameObjects();
                }
            }
        }

        protected virtual void OnEnable()
        {
            foreach (string assetGUID in AssetDatabase.FindAssets(assetName))
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(assetGUID);
                if (assetPath.Contains(assetName + assetSuffix))
                {
                    climbablePrefab = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);
                }
            }
        }

        protected virtual void ProcessSelectedGameObjects()
        {
            foreach (Transform selectedTransform in Selection.transforms)
            {
                ConvertSelectedGameObject(selectedTransform.gameObject);
            }
        }

        protected virtual void ConvertSelectedGameObject(GameObject objectToConvert)
        {
            ClimbableFacade climbable = objectToConvert.GetComponentInParent<ClimbableFacade>();
            if (climbable == null)
            {
                CreateClimbable(objectToConvert);
            }
        }

        protected virtual void CreateClimbable(GameObject objectToWrap)
        {
            int siblingIndex = objectToWrap.transform.GetSiblingIndex();
            GameObject newClimbable = (GameObject)PrefabUtility.InstantiatePrefab(climbablePrefab);
            newClimbable.name += "_" + objectToWrap.name;
            ClimbableFacade climbableFacade = newClimbable.GetComponent<ClimbableFacade>();
            InteractableFacade facade = newClimbable.GetComponentInChildren<InteractableFacade>();

            newClimbable.transform.SetParent(objectToWrap.transform.parent);
            newClimbable.transform.localPosition = objectToWrap.transform.localPosition;
            newClimbable.transform.localRotation = objectToWrap.transform.localRotation;
            newClimbable.transform.localScale = objectToWrap.transform.localScale;

            foreach (MeshRenderer defaultMeshes in facade.Configuration.MeshContainer.GetComponentsInChildren<MeshRenderer>())
            {
                defaultMeshes.gameObject.SetActive(false);
            }

            objectToWrap.transform.SetParent(facade.Configuration.MeshContainer.transform);
            objectToWrap.transform.localPosition = Vector3.zero;
            objectToWrap.transform.localRotation = Quaternion.identity;
            objectToWrap.transform.localScale = Vector3.one;

            newClimbable.transform.SetSiblingIndex(siblingIndex);
            climbableFacade.ClimbingFacade = climbingFacade;
        }

        [MenuItem(windowPath + windowTitle)]
        private static void ShowWindow()
        {
            promptWindow = EditorWindow.GetWindow(typeof(ClimbableCreatorEditorWindow));
            promptWindow.titleContent = new GUIContent(windowTitle);
        }
    }
}