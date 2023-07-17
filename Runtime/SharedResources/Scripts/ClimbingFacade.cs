namespace Tilia.Locomotors.Climbing
{
    using System;
    using System.Collections.Generic;
    using Tilia.Locomotors.Climbing.Target;
    using Tilia.Trackers.PseudoBody;
    using UnityEngine;
    using UnityEngine.Events;
    using Zinnia.Data.Attribute;
    using Zinnia.Extension;

    /// <summary>
    /// The public interface for the Climbing prefab.
    /// </summary>
    public class ClimbingFacade : MonoBehaviour
    {
        #region Climbing Settings
        [Header("Climbing Settings")]
        [Tooltip("The target to move when climbing.")]
        [SerializeField]
        private ClimbTarget target;
        /// <summary>
        /// The target to move when climbing.
        /// </summary>
        public ClimbTarget Target
        {
            get
            {
                return target;
            }
            set
            {
                target = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterTargetChange();
                }
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// Emitted when a climb starts.
        /// </summary>
        [Header("Climbing Events")]
        public UnityEvent ClimbStarted = new UnityEvent();
        /// <summary>
        /// Emitted when the climb stops.
        /// </summary>
        public UnityEvent ClimbStopped = new UnityEvent();
        #endregion

        #region Reference Settings
        [Header("Reference Settings")]
        [Tooltip("The linked ClimbingConfigurator.")]
        [SerializeField]
        [Restricted]
        private ClimbingConfigurator configuration;
        /// <summary>
        /// The linked <see cref="ClimbingConfigurator"/>.
        /// </summary>
        public ClimbingConfigurator Configuration
        {
            get
            {
                return configuration;
            }
            set
            {
                configuration = value;
            }
        }
        #endregion

#pragma warning disable 0618
        #region Deprecated Settings
        [Tooltip("The body representation to control.")]
        [SerializeField]
        [Restricted]
        [Obsolete("Use `Target` instead.")]
        private PseudoBodyFacade pseudoBodyFacade;
        /// <summary>
        /// The body representation to control.
        /// </summary>
        [Obsolete("Use `Target` instead.")]
        public PseudoBodyFacade PseudoBodyFacade
        {
            get
            {
                return pseudoBodyFacade;
            }
            set
            {
                pseudoBodyFacade = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterPseudoBodyFacadeChange();
                }
            }
        }
        #endregion
#pragma warning restore 0618

        /// <summary>
        /// The current source of the movement. The body will be moved in reverse direction in case this object moves.
        /// </summary>
        public virtual GameObject CurrentInteractor => Interactors.Count == 0 ? null : Interactors[Interactors.Count - 1];
        /// <summary>
        /// The current optional offset of the movement. The body will be moved in case this object moves.
        /// </summary>
        public virtual GameObject CurrentInteractable => Interactables.Count == 0 ? null : Interactables[Interactors.Count - 1];
        /// <summary>
        /// Whether a climb is happening right now.
        /// </summary>
        public virtual bool IsClimbing => Interactors.Count > 0 || Interactables.Count > 0;

        /// <summary>
        /// The objects that define the source of movement in order they should be used. The last object defines <see cref="CurrentInteractor"/>.
        /// </summary>
        public virtual IReadOnlyList<GameObject> Interactors => Configuration.Interactors.NonSubscribableElements;
        /// <summary>
        /// The objects that define the optional offsets of movement in order they should be used. The last object defines <see cref="CurrentInteractable"/>.
        /// </summary>
        public virtual IReadOnlyList<GameObject> Interactables => Configuration.Interactables.NonSubscribableElements;

#pragma warning disable 0618
        /// <summary>
        /// Clears <see cref="PseudoBodyFacade"/>.
        /// </summary>
        [Obsolete("`ClimbingFacade.PseudoBodyFacade` has been deprecated. Use `ClimbingFacade.Target` instead.")]
        public virtual void ClearPseudoBodyFacade()
        {
            if (!this.IsValidState())
            {
                return;
            }

            PseudoBodyFacade = default;
        }
#pragma warning restore 0618

        /// <summary>
        /// Clears <see cref="Target"/>.
        /// </summary>
        public virtual void ClearTarget()
        {
            if (!this.IsValidState())
            {
                return;
            }

            Target = default;
        }

        /// <summary>
        /// Adds a source of movement for the body.
        /// </summary>
        /// <param name="interactor">The object to use as a source of the movement.</param>
        public virtual void AddInteractor(GameObject interactor)
        {
            if (!this.IsValidState())
            {
                return;
            }

            Configuration.Interactors.Add(interactor);
        }

        /// <summary>
        /// Removes a source of movement for the body.
        /// </summary>
        /// <param name="interactor">The object used as a source of the movement.</param>
        public virtual void RemoveInteractor(GameObject interactor)
        {
            if (!this.IsValidState() || !Configuration.Interactors.Contains(interactor))
            {
                return;
            }

            Configuration.Interactors.RemoveLastOccurrence(interactor);
            Configuration.ApplyVelocity();
        }

        /// <summary>
        /// Clears the sources of the movement.
        /// </summary>
        public virtual void ClearInteractors()
        {
            if (!this.IsValidState())
            {
                return;
            }

            Configuration.Interactors.Clear();
        }

        /// <summary>
        /// Adds an optional offset of movement for the body.
        /// </summary>
        /// <param name="interactable">The object to use as an optional offset of the movement.</param>
        public virtual void AddInteractable(GameObject interactable)
        {
            if (!this.IsValidState())
            {
                return;
            }

            Configuration.Interactables.Add(interactable);
        }

        /// <summary>
        /// Removes an optional offset of movement for the body.
        /// </summary>
        /// <param name="interactable">The object used as an optional offset of the movement.</param>
        public virtual void RemoveInteractable(GameObject interactable)
        {
            if (!this.IsValidState())
            {
                return;
            }

            Configuration.Interactables.RemoveLastOccurrence(interactable);
        }

        /// <summary>
        /// Clears the optional offsets of the movement.
        /// </summary>
        public virtual void ClearInteractables()
        {
            if (!this.IsValidState())
            {
                return;
            }

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
        protected virtual void OnAfterTargetChange()
        {
            Configuration.ConfigureTargetPositionProperty();
        }

#pragma warning disable 0618
        /// <summary>
        /// Called after <see cref="PseudoBodyFacade"/> has been changed.
        /// </summary>
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