namespace Tilia.Locomotors.Climbing
{
    using System.Collections.Generic;
    using UnityEngine;
    using Zinnia.Data.Attribute;
    using Zinnia.Data.Collection.List;
    using Zinnia.Data.Operation.Mutation;
    using Zinnia.Data.Type.Transformation.Aggregation;
    using Zinnia.Extension;
    using Zinnia.Tracking.Follow;
    using Zinnia.Tracking.Velocity;

    /// <summary>
    /// Sets up the Climbing prefab based on the provided user settings.
    /// </summary>
    public class ClimbingConfigurator : MonoBehaviour
    {
        #region Facade Settings
        [Header("Facade Settings")]
        [Tooltip("The public interface facade.")]
        [SerializeField]
        [Restricted]
        private ClimbingFacade facade;
        /// <summary>
        /// The public interface facade.
        /// </summary>
        public ClimbingFacade Facade
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
        [Tooltip("The objects defining the sources of movement.")]
        [SerializeField]
        [Restricted]
        private GameObjectObservableList interactors;
        /// <summary>
        /// The objects defining the sources of movement.
        /// </summary>
        public GameObjectObservableList Interactors
        {
            get
            {
                return interactors;
            }
            protected set
            {
                interactors = value;
            }
        }
        [Tooltip("The objects defining the offsets of movement.")]
        [SerializeField]
        [Restricted]
        private GameObjectObservableList interactables;
        /// <summary>
        /// The objects defining the offsets of movement.
        /// </summary>
        public GameObjectObservableList Interactables
        {
            get
            {
                return interactables;
            }
            protected set
            {
                interactables = value;
            }
        }
        [Tooltip("The ComponentTrackerProxy component for obtaining velocity data.")]
        [SerializeField]
        [Restricted]
        private ComponentTrackerProxy velocityProxy;
        /// <summary>
        /// The <see cref="ComponentTrackerProxy"/> component for obtaining velocity data.
        /// </summary>
        public ComponentTrackerProxy VelocityProxy
        {
            get
            {
                return velocityProxy;
            }
            protected set
            {
                velocityProxy = value;
            }
        }
        [Tooltip("The Zinnia.Tracking.Velocity.VelocityEmitter component for emitting velocity data.")]
        [SerializeField]
        [Restricted]
        private VelocityEmitter velocityEmitter;
        /// <summary>
        /// The <see cref="Zinnia.Tracking.Velocity.VelocityEmitter"/> component for emitting velocity data.
        /// </summary>
        public VelocityEmitter VelocityEmitter
        {
            get
            {
                return velocityEmitter;
            }
            protected set
            {
                velocityEmitter = value;
            }
        }
        [Tooltip("The Vector3Multiplier component for multiplying velocity data.")]
        [SerializeField]
        [Restricted]
        private Vector3Multiplier velocityMultiplier;
        /// <summary>
        /// The <see cref="Vector3Multiplier"/> component for multiplying velocity data.
        /// </summary>
        public Vector3Multiplier VelocityMultiplier
        {
            get
            {
                return velocityMultiplier;
            }
            protected set
            {
                velocityMultiplier = value;
            }
        }
        [Tooltip("The ObjectDistanceComparator component for the source.")]
        [SerializeField]
        [Restricted]
        private ObjectDistanceComparator sourceDistanceComparator;
        /// <summary>
        /// The <see cref="ObjectDistanceComparator"/> component for the source.
        /// </summary>
        public ObjectDistanceComparator SourceDistanceComparator
        {
            get
            {
                return sourceDistanceComparator;
            }
            protected set
            {
                sourceDistanceComparator = value;
            }
        }
        [Tooltip("The ObjectDistanceComparator component for the offset.")]
        [SerializeField]
        [Restricted]
        private ObjectDistanceComparator offsetDistanceComparator;
        /// <summary>
        /// The <see cref="ObjectDistanceComparator"/> component for the offset.
        /// </summary>
        public ObjectDistanceComparator OffsetDistanceComparator
        {
            get
            {
                return offsetDistanceComparator;
            }
            protected set
            {
                offsetDistanceComparator = value;
            }
        }
        [Tooltip("The TransformPositionMutator component for the offset.")]
        [SerializeField]
        [Restricted]
        private TransformPositionMutator targetPositionProperty;
        /// <summary>
        /// The <see cref="TransformPositionMutator"/> component for the offset.
        /// </summary>
        public TransformPositionMutator TargetPositionProperty
        {
            get
            {
                return targetPositionProperty;
            }
            protected set
            {
                targetPositionProperty = value;
            }
        }
        #endregion

        /// <summary>
        /// Applies velocity to the <see cref="PseudoBody"/>.
        /// </summary>
        public virtual void ApplyVelocity()
        {
            if (!this.CheckIsActiveAndEnabled() || Interactors.NonSubscribableElements.Count > 0 || VelocityProxy.ProxySource == null)
            {
                return;
            }

            VelocityEmitter.EmitVelocity();
            Facade.Target.ApplyVelocity(VelocityMultiplier.Result);
            VelocityProxy.ProxySource = null;
        }

        /// <summary>
        /// Configures the <see cref="TargetPositionProperty"/> based on the facade settings.
        /// </summary>
        public virtual void ConfigureTargetPositionProperty()
        {
            TargetPositionProperty.Target = Facade.Target.Target;
        }

        protected virtual void OnEnable()
        {
            Interactors.Populated.AddListener(OnListBecamePopulated);
            Interactors.Added.AddListener(OnInteractorAdded);
            Interactors.Removed.AddListener(OnInteractorRemoved);
            Interactors.Emptied.AddListener(OnListBecameEmpty);

            Interactables.Added.AddListener(OnInteractableAdded);
            Interactables.Removed.AddListener(OnInteractableRemoved);

            SourceDistanceComparator.enabled = false;
            OffsetDistanceComparator.enabled = false;
            Facade.RunWhenActiveAndEnabled(() => ConfigureTargetPositionProperty());
        }

        protected virtual void OnDisable()
        {
            TargetPositionProperty.Target = null;

            OffsetDistanceComparator.enabled = false;
            SourceDistanceComparator.enabled = false;

            Interactables.Removed.RemoveListener(OnInteractableRemoved);
            Interactables.Added.RemoveListener(OnInteractableAdded);

            Interactors.Emptied.RemoveListener(OnListBecameEmpty);
            Interactors.Removed.RemoveListener(OnInteractorRemoved);
            Interactors.Added.RemoveListener(OnInteractorAdded);
            Interactors.Populated.RemoveListener(OnListBecamePopulated);
        }

        /// <summary>
        /// Emits a climb started event when the list becomes populated.
        /// </summary>
        /// <param name="addedElement">The element added.</param>
        protected virtual void OnListBecamePopulated(GameObject addedElement)
        {
            if (Interactors.NonSubscribableElements.Count > 0 || Interactables.NonSubscribableElements.Count > 0)
            {
                Facade.ClimbStarted?.Invoke();
            }
        }

        /// <summary>
        /// Emits a climb stopped event when the list becomes empty.
        /// </summary>
        /// <param name="removedElement">The element removed.</param>
        protected virtual void OnListBecameEmpty(GameObject removedElement)
        {
            if (Interactors.NonSubscribableElements.Count == 0 && Interactables.NonSubscribableElements.Count == 0)
            {
                Facade.ClimbStopped?.Invoke();
            }
        }

        /// <summary>
        /// Configures the <see cref="SourceDistanceComparator"/> when an interactor is added.
        /// </summary>
        /// <param name="interactor">The added interactor.</param>
        protected virtual void OnInteractorAdded(GameObject interactor)
        {
            SourceDistanceComparator.Source = interactor;
            SourceDistanceComparator.Target = interactor;
            SourceDistanceComparator.enabled = interactor != null;
            SourceDistanceComparator.SavePosition();

            if (interactor != null)
            {
                Facade.Target.InteractorAdded();
            }
        }

        /// <summary>
        /// Configures the <see cref="SourceDistanceComparator"/> when an interactor is removed.
        /// </summary>
        /// <param name="interactor">The removed interactor.</param>
        protected virtual void OnInteractorRemoved(GameObject interactor)
        {
            IReadOnlyList<GameObject> elements = Interactors.NonSubscribableElements;
            OnInteractorAdded(elements.Count == 0 ? null : elements[elements.Count - 1]);
        }

        /// <summary>
        /// Configures the <see cref="OffsetDistanceComparator"/> when an interactable is added.
        /// </summary>
        /// <param name="interactable">The added interactable.</param>
        protected virtual void OnInteractableAdded(GameObject interactable)
        {
            OffsetDistanceComparator.Source = interactable;
            OffsetDistanceComparator.Target = interactable;
            OffsetDistanceComparator.enabled = interactable != null;
            OffsetDistanceComparator.SavePosition();

            if (interactable != null)
            {
                Facade.Target.InteractableAdded();
            }
        }

        /// <summary>
        /// Configures the <see cref="OffsetDistanceComparator"/> when an interactable is removed.
        /// </summary>
        /// <param name="interactable">The removed interactable.</param>
        protected virtual void OnInteractableRemoved(GameObject interactable)
        {
            IReadOnlyList<GameObject> elements = Interactables.NonSubscribableElements;
            OnInteractableAdded(elements.Count == 0 ? null : elements[elements.Count - 1]);
        }
    }
}