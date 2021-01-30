namespace Tilia.Locomotors.Climbing.Target
{
    using Malimbe.MemberClearanceMethod;
    using Malimbe.PropertySerializationAttribute;
    using Malimbe.XmlDocumentationAttribute;
    using Tilia.Trackers.PseudoBody;
    using UnityEngine;

    /// <summary>
    /// Controls a <see cref="PseudoBodyFacade"/> by the <see cref="ClimbingFacade"/> operation.
    /// </summary>
    public class PseudoBodyClimbTarget : ClimbTarget
    {
        /// <summary>
        /// The body representation to control.
        /// </summary>
        [Serialized, Cleared]
        [field: DocumentedByXml]
        public PseudoBodyFacade PseudoBodyFacade { get; set; }

        /// <inheritdoc />
        public override GameObject Target => PseudoBodyFacade.Offset == null ? PseudoBodyFacade.Source : PseudoBodyFacade.Offset;

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