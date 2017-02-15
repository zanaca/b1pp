﻿// <copyright filename="ItemEventHandlerAttribute.cs" project="Framework">
//   This file is licensed to you under the MIT License.
//   Full license in the project root.
// </copyright>
namespace B1PP.Forms.Events.ItemEvents
{
    using System;

    using SAPbouiCOM;

    /// <summary>
    /// Used to mark a method as an item event handler.
    /// <para />
    /// Before item event signature: <b>bool OnBeforeItemEvent(ItemEvent e);</b>
    /// <para />
    /// After item event signature: <b>void OnAfterItemEvent(ItemEvent e);</b>
    /// <para />
    /// To stop Business One from processing the event return false on the before event.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class ItemEventHandlerAttribute : Attribute, IEquatable<ItemEventHandlerAttribute>
    {
        public bool BeforeAction { get; }

        public string ItemId { get; }

        public BoEventTypes EventType { get; }

        public ItemEventHandlerAttribute(BoEventTypes eventType, bool before = false)
            : this(string.Empty, eventType, before)
        {
        }

        public ItemEventHandlerAttribute(string itemId, BoEventTypes eventType, bool beforeAction = false)
        {
            BeforeAction = beforeAction;
            ItemId = itemId;
            EventType = eventType;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            string isBefore = BeforeAction ? "Before" : "After";
            return $"{isBefore} {EventType}({ItemId})";
        }

        #region Autogenerated equality members

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(ItemEventHandlerAttribute other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return base.Equals(other) && (BeforeAction == other.BeforeAction) && string.Equals(ItemId, other.ItemId) &&
                   (EventType == other.EventType);
        }

        /// <summary>Returns a value that indicates whether this instance is equal to a specified object.</summary>
        /// <returns>true if <paramref name="obj" /> equals the type and value of this instance; otherwise, false.</returns>
        /// <param name="obj">An <see cref="T:System.Object" /> to compare with this instance or null. </param>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != GetType())
            {
                return false;
            }
            return Equals((ItemEventHandlerAttribute) obj);
        }

        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ BeforeAction.GetHashCode();
                hashCode = (hashCode * 397) ^ (ItemId?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (int) EventType;
                return hashCode;
            }
        }

        public static bool operator ==(ItemEventHandlerAttribute left, ItemEventHandlerAttribute right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ItemEventHandlerAttribute left, ItemEventHandlerAttribute right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}