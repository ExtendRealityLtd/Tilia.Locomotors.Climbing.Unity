namespace Tilia.Locomotors.Climbing.Target
{
    using UnityEngine;

    /// <summary>
    /// The abstract target that can be controlled by the <see cref="ClimbingFacade"/>.
    /// </summary>
    public abstract class ClimbTarget : MonoBehaviour
    {
        /// <summary>
        /// The <see cref="GameObject"/> to move with the climbing operation.
        /// </summary>
        public abstract GameObject Target { get; }
        /// <summary>
        /// Applies the given velocity to the <see cref="Target"/>.
        /// </summary>
        /// <param name="velocity">The velocity to apply.</param>
        public abstract void ApplyVelocity(Vector3 velocity);
        /// <summary>
        /// Processed when an Interactor is added to the <see cref="ClimbingFacade"/>.
        /// </summary>
        public abstract void InteractorAdded();
        /// <summary>
        /// Processed when an Interactable is added to the <see cref="ClimbingFacade"/>.
        /// </summary>
        public abstract void InteractableAdded();
    }
}