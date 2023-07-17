namespace Tilia.Locomotors.Climbing
{
    using UnityEngine;
    using Zinnia.Data.Attribute;

    /// <summary>
    /// The public interface for the Interactions.Climbable prefab.
    /// </summary>
    public class ClimbableFacade : MonoBehaviour
    {
        #region Climb Settings
        [Header("Climb Settings")]
        [Tooltip("The ClimbingFacade to use.")]
        [SerializeField]
        private ClimbingFacade climbingFacade;
        /// <summary>
        /// The <see cref="ClimbingFacade"/> to use.
        /// </summary>
        public ClimbingFacade ClimbingFacade
        {
            get
            {
                return climbingFacade;
            }
            set
            {
                climbingFacade = value;
            }
        }
        [Tooltip("The multiplier to apply to the velocity of the interactor when the interactable is released and climbing stops.")]
        [SerializeField]
        private Vector3 releaseMultiplier = Vector3.one;
        /// <summary>
        /// The multiplier to apply to the velocity of the interactor when the interactable is released and climbing stops.
        /// </summary>
        public Vector3 ReleaseMultiplier
        {
            get
            {
                return releaseMultiplier;
            }
            set
            {
                releaseMultiplier = value;
            }
        }
        #endregion

        #region Reference Settings
        [Header("Reference Settings")]
        [Tooltip("The linked ClimbableConfigurator.")]
        [SerializeField]
        [Restricted]
        private ClimbableConfigurator configuration;
        /// <summary>
        /// The linked <see cref="ClimbableConfigurator"/>.
        /// </summary>
        public ClimbableConfigurator Configuration
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

        /// <summary>
        /// Sets the <see cref="ReleaseMultiplier"/> x value.
        /// </summary>
        /// <param name="value">The value to set to.</param>
        public virtual void SetReleaseMultiplierX(float value)
        {
            ReleaseMultiplier = new Vector3(value, ReleaseMultiplier.y, ReleaseMultiplier.z);
        }

        /// <summary>
        /// Sets the <see cref="ReleaseMultiplier"/> y value.
        /// </summary>
        /// <param name="value">The value to set to.</param>
        public virtual void SetReleaseMultiplierY(float value)
        {
            ReleaseMultiplier = new Vector3(ReleaseMultiplier.x, value, ReleaseMultiplier.z);
        }

        /// <summary>
        /// Sets the <see cref="ReleaseMultiplier"/> z value.
        /// </summary>
        /// <param name="value">The value to set to.</param>
        public virtual void SetReleaseMultiplierZ(float value)
        {
            ReleaseMultiplier = new Vector3(ReleaseMultiplier.x, ReleaseMultiplier.y, value);
        }
    }
}