namespace Tilia.Locomotors.Climbing
{
    using Malimbe.PropertySerializationAttribute;
    using Malimbe.XmlDocumentationAttribute;
    using UnityEngine;
    using Zinnia.Data.Attribute;

    /// <summary>
    /// The public interface for the Interactions.Climbable prefab.
    /// </summary>
    public class ClimbableFacade : MonoBehaviour
    {
        #region Climb Settings
        /// <summary>
        /// The <see cref="ClimbingFacade"/> to use.
        /// </summary>
        [Serialized]
        [field: Header("Climb Settings"), DocumentedByXml]
        public ClimbingFacade ClimbingFacade { get; set; }
        /// <summary>
        /// The multiplier to apply to the velocity of the interactor when the interactable is released and climbing stops.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml]
        public Vector3 ReleaseMultiplier { get; set; } = Vector3.one;
        #endregion

        #region Reference Settings
        /// <summary>
        /// The linked <see cref="ClimbableConfigurator"/>.
        /// </summary>
        [Serialized]
        [field: Header("Reference Settings"), DocumentedByXml, Restricted]
        public ClimbableConfigurator Configuration { get; protected set; }
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