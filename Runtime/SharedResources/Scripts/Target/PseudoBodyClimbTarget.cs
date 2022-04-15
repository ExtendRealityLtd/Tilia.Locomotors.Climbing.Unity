namespace Tilia.Locomotors.Climbing.Target
{
    using Tilia.Trackers.PseudoBody;
    using UnityEngine;
    using Zinnia.Extension;

    /// <summary>
    /// Controls a <see cref="PseudoBodyFacade"/> by the <see cref="ClimbingFacade"/> operation.
    /// </summary>
    public class PseudoBodyClimbTarget : ClimbTarget
    {
        [Tooltip("The body representation to control.")]
        [SerializeField]
        private PseudoBodyFacade pseudoBodyFacade;
        /// <summary>
        /// The body representation to control.
        /// </summary>
        public PseudoBodyFacade PseudoBodyFacade
        {
            get
            {
                return pseudoBodyFacade;
            }
            set
            {
                pseudoBodyFacade = value;
            }
        }

        /// <inheritdoc />
        public override GameObject Target => PseudoBodyFacade.Offset == null ? PseudoBodyFacade.Source : PseudoBodyFacade.Offset;

        /// <summary>
        /// Clears <see cref="PseudoBodyFacade"/>.
        /// </summary>
        public virtual void ClearPseudoBodyFacade()
        {
            if (!this.IsValidState())
            {
                return;
            }

            PseudoBodyFacade = default;
        }

        /// <inheritdoc />
        public override void ApplyVelocity(Vector3 velocity)
        {
            PseudoBodyFacade.ListenToRigidbodyMovement();
            PseudoBodyFacade.PhysicsBody.velocity -= velocity;
        }

        /// <inheritdoc />
        public override void InteractorAdded()
        {
            PseudoBodyFacade.Interest = PseudoBodyProcessor.MovementInterest.CharacterController;
        }

        /// <inheritdoc />
        public override void InteractableAdded()
        {
            PseudoBodyFacade.Interest = PseudoBodyProcessor.MovementInterest.CharacterController;
        }
    }
}