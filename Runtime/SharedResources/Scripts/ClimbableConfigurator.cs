namespace Tilia.Locomotors.Climbing
{
    using Malimbe.PropertySerializationAttribute;
    using Malimbe.XmlDocumentationAttribute;
    using Tilia.Interactions.Interactables;
    using UnityEngine;
    using Zinnia.Data.Attribute;
    using Zinnia.Event.Proxy;

    /// <summary>
    /// Sets up the Interactions.Climbable prefab based on the provided user settings.
    /// </summary>
    public class ClimbableConfigurator : MonoBehaviour
    {
        #region Facade Settings
        /// <summary>
        /// The public interface facade.
        /// </summary>
        [Serialized]
        [field: Header("Facade Settings"), DocumentedByXml, Restricted]
        public ClimbableFacade Facade { get; protected set; }
        #endregion

        #region Reference Settings
        /// <summary>
        /// The <see cref="InteractableFacade"/> component acting as the interactable for climbing.
        /// </summary>
        [Serialized]
        [field: Header("Reference Settings"), DocumentedByXml, Restricted]
        public InteractableFacade InteractableFacade { get; protected set; }
        /// <summary>
        /// The <see cref="GameObjectEventProxyEmitter"/> component handling a started climb.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public GameObjectEventProxyEmitter StartEventProxyEmitter { get; protected set; }
        /// <summary>
        /// The <see cref="GameObjectEventProxyEmitter"/> component handling a stopped climb.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public GameObjectEventProxyEmitter StopEventProxyEmitter { get; protected set; }
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