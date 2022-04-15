namespace Tilia.Locomotors.Climbing
{
    using Tilia.Interactions.Interactables.Interactables;
    using UnityEngine;
    using Zinnia.Data.Attribute;
    using Zinnia.Event.Proxy;

    /// <summary>
    /// Sets up the Interactions.Climbable prefab based on the provided user settings.
    /// </summary>
    public class ClimbableConfigurator : MonoBehaviour
    {
        #region Facade Settings
        [Header("Facade Settings")]
        [Tooltip("The public interface facade.")]
        [SerializeField]
        [Restricted]
        private ClimbableFacade facade;
        /// <summary>
        /// The public interface facade.
        /// </summary>
        public ClimbableFacade Facade
        {
            get
            {
                return facade;
            }
            protected set
            {
                facade = value;
            }
        }
        #endregion

        #region Reference Settings
        [Header("Reference Settings")]
        [Tooltip("The InteractableFacade component acting as the interactable for climbing.")]
        [SerializeField]
        [Restricted]
        private InteractableFacade interactableFacade;
        /// <summary>
        /// The <see cref="InteractableFacade"/> component acting as the interactable for climbing.
        /// </summary>
        public InteractableFacade InteractableFacade
        {
            get
            {
                return interactableFacade;
            }
            protected set
            {
                interactableFacade = value;
            }
        }
        [Tooltip("The GameObjectEventProxyEmitter component handling a started climb.")]
        [SerializeField]
        [Restricted]
        private GameObjectEventProxyEmitter startEventProxyEmitter;
        /// <summary>
        /// The <see cref="GameObjectEventProxyEmitter"/> component handling a started climb.
        /// </summary>
        public GameObjectEventProxyEmitter StartEventProxyEmitter
        {
            get
            {
                return startEventProxyEmitter;
            }
            protected set
            {
                startEventProxyEmitter = value;
            }
        }
        [Tooltip("The GameObjectEventProxyEmitter component handling a stopped climb.")]
        [SerializeField]
        [Restricted]
        private GameObjectEventProxyEmitter stopEventProxyEmitter;
        /// <summary>
        /// The <see cref="GameObjectEventProxyEmitter"/> component handling a stopped climb.
        /// </summary>
        public GameObjectEventProxyEmitter StopEventProxyEmitter
        {
            get
            {
                return stopEventProxyEmitter;
            }
            protected set
            {
                stopEventProxyEmitter = value;
            }
        }
        #endregion

        protected virtual void OnEnable()
        {
            StartEventProxyEmitter.Emitted.AddListener(OnStartEventProxyEmitted);
            StopEventProxyEmitter.Emitted.AddListener(OnStopEventProxyEmitted);
        }

        protected virtual void OnDisable()
        {
            StopEventProxyEmitter.Emitted.RemoveListener(OnStopEventProxyEmitted);
            StartEventProxyEmitter.Emitted.RemoveListener(OnStartEventProxyEmitted);
        }

        /// <summary>
        /// Processes the start climbing functionality.
        /// </summary>
        /// <param name="interactor">The interactor initiating the climb.</param>
        protected virtual void OnStartEventProxyEmitted(GameObject interactor)
        {
            Facade.ClimbingFacade.AddInteractor(interactor);
            Facade.ClimbingFacade.AddInteractable(InteractableFacade.gameObject);
        }

        /// <summary>
        /// Processes the stop climbing functionality.
        /// </summary>
        /// <param name="interactor">The interactor that is no longer climbing.</param>
        protected virtual void OnStopEventProxyEmitted(GameObject interactor)
        {
            Facade.ClimbingFacade.SetVelocitySource(interactor);
            Facade.ClimbingFacade.SetVelocityMultiplier(Facade.ReleaseMultiplier);
            Facade.ClimbingFacade.RemoveInteractable(InteractableFacade.gameObject);
            Facade.ClimbingFacade.RemoveInteractor(interactor);
        }
    }
}