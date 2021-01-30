namespace Tilia.Locomotors.Climbing
{
    using Malimbe.BehaviourStateRequirementMethod;
    using Malimbe.MemberChangeMethod;
    using Malimbe.MemberClearanceMethod;
    using Malimbe.PropertySerializationAttribute;
    using Malimbe.XmlDocumentationAttribute;
    using System;
    using System.Collections.Generic;
    using Tilia.Locomotors.Climbing.Target;
    using Tilia.Trackers.PseudoBody;
    using UnityEngine;
    using UnityEngine.Events;
    using Zinnia.Data.Attribute;

    /// <summary>
    /// The public interface for the Climbing prefab.
    /// </summary>
    public class ClimbingFacade : MonoBehaviour
    {
        #region Control Settings
        /// <summary>
        /// The body representation to control.
        /// </summary>
        [Serialized, Cleared]
        [field: DocumentedByXml, Restricted]
        [Obsolete("Use `Target` instead.")]
        public PseudoBodyFacade PseudoBodyFacade { get; set; }
        #endregion

        #region Events
        /// <summary>
        /// Emitted when a climb starts.
        /// </summary>
        [Header("Events"), DocumentedByXml]
        public UnityEvent ClimbStarted = new UnityEvent();
        /// <summary>
        /// Emitted when the climb stops.
        /// </summary>
        [DocumentedByXml]
        public UnityEvent ClimbStopped = new UnityEvent();
        #endregion

        #region Reference Settings
        /// <summary>
        /// The target to move when climbing.
        /// </summary>
        [Serialized, Cleared]
        [field: Header("Reference Settings"), DocumentedByXml]
        public ClimbTarget Target { get; set; }
        /// <summary>
        /// The linked <see cref="ClimbingConfigurator"/>.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Restricted]
        public ClimbingConfigurator Configuration { get; protected set; }
        #endregion

        /// <summary>
        /// The current source of the movement. The body will be moved in reverse direction in case this object moves.
        /// </summary>
        public GameObject CurrentInteractor => Interactors.Count == 0 ? null : Interactors[Interactors.Count - 1];
        /// <summary>
        /// The current optional offset of the movement. The body will be moved in case this object moves.
        /// </summary>
        public GameObject CurrentInteractable => Interactables.Count == 0 ? null : Interactables[Interactors.Count - 1];
        /// <summary>
        /// Whether a climb is happening right now.
        /// </summary>
        public bool IsClimbing => Interactors.Count > 0 || Interactables.Count > 0;

        /// <summary>
        /// The objects that define the source of movement in order they should be used. The last object defines <see cref="CurrentInteractor"/>.
        /// </summary>
        public IReadOnlyList<GameObject> Interactors => Configuration.Interactors.NonSubscribableElements;
        /// <summary>
        /// The objects that define the optional offsets of movement in order they should be used. The last object defines <see cref="CurrentInteractable"/>.
        /// </summary>
        public IReadOnlyList<GameObject> Interactables => Configuration.Interactables.NonSubscribableElements;

        /// <summary>
        /// Adds a source of movement for the body.
        /// </summary>
        /// <param name="interactor">The object to use as a source of the movement.</param>
        [RequiresBehaviourState]
        public virtual void AddInteractor(GameObject interactor)
        {
            Configuration.Interactors.Add(interactor);
        }

        /// <summary>
        /// Removes a source of movement for the body.
        /// </summary>
        /// <param name="interactor">The object used as a source of the movement.</param>
        [RequiresBehaviourState]
        public virtual void RemoveInteractor(GameObject interactor)
        {
            if (!Configuration.Interactors.Contains(interactor))
            {
                return;
            }

            Configuration.Interactors.RemoveLastOccurrence(interactor);
            Configuration.ApplyVelocity();
        }

        /// <summary>
        /// Clears the sources of the movement.
        /// </summary>
        [RequiresBehaviourState]
        public virtual void ClearInteractors()
        {
            Configuration.Interactors.Clear();
        }

        /// <summary>
        /// Adds an optional offset of movement for the body.
        /// </summary>
        /// <param name="interactable">The object to use as an optional offset of the movement.</param>
        [RequiresBehaviourState]
        public virtual void AddInteractable(GameObject interactable)
        {
            Configuration.Interactables.Add(interactable);
        }

        /// <summary>
        /// Removes an optional offset of movement for the body.
        /// </summary>
        /// <param name="interactable">The object used as an optional offset of the movement.</param>
        [RequiresBehaviourState]
        public virtual void RemoveInteractable(GameObject interactable)
        {
            Configuration.Interactables.RemoveLastOccurrence(interactable);
        }

        /// <summary>
        /// Clears the optional offsets of the movement.
        /// </summary>
        [RequiresBehaviourState]
        public virtual void ClearInteractables()
        {
            Configuration.Interactables.Clear();
        }

        /// <summary>
        /// Sets a source to track the velocity from.
        /// </summary>
        /// <param name="source">The tracked velocity source.</param>
        public virtual void SetVelocitySource(GameObject source)
        {
            Configuration.VelocityProxy.ProxySource = source;
        }

        /// <summary>
        /// Sets the multiplier to apply to any tracked velocity.
        /// </summary>
        /// <param name="multiplier">The multiplier to apply to tracked velocity.</param>
        public virtual void SetVelocityMultiplier(Vector3 multiplier)
        {
            Configuration.VelocityMultiplier.Collection.SetAt(multiplier, 1);
            Configuration.VelocityMultiplier.Collection.CurrentIndex = 0;
        }

        protected virtual void Awake()
        {
#pragma warning disable 0618
            if (PseudoBodyFacade != null)
            {
                PsuedoBodyFacadeDeprecatedMessage();
                PseudoBodyClimbTarget migrateTarget = (PseudoBodyClimbTarget)Target;
                migrateTarget.PseudoBodyFacade = PseudoBodyFacade;
                Configuration.ConfigureTargetPositionProperty();
            }
#pragma warning restore 0618
        }

        /// <summary>
        /// Called after <see cref="Target"/> has been changed.
        /// </summary>
        [CalledAfterChangeOf(nameof(Target))]
        protected virtual void OnAfterTargetChange()
        {
            Configuration.ConfigureTargetPositionProperty();
        }

#pragma warning disable 0618
        /// <summary>
        /// Called after <see cref="PseudoBodyFacade"/> has been changed.
        /// </summary>
        [CalledAfterChangeOf(nameof(PseudoBodyFacade))]
        protected virtual void OnAfterPseudoBodyFacadeChange()
        {
            PsuedoBodyFacadeDeprecatedMessage();
            Configuration.ConfigureTargetPositionProperty();
        }
#pragma warning restore 0618

        private void PsuedoBodyFacadeDeprecatedMessage()
        {
#pragma warning disable 0618
            if (PseudoBodyFacade != null)
            {
                Debug.LogWarning("`ClimbingFacade.PseudoBodyFacade` has been deprecated. Use `ClimbingFacade.Target` instead.", gameObject);
            }
#pragma warning restore 0618
        }
    }
}