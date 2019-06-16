using System;

namespace Source.Runtime.Core
{
    public enum RequiredFieldType
    {
        /// <summary>
        /// Field must be set in the inspector
        /// </summary>
        Mandatory,

        /// <summary>
        /// Warning that the field is missing
        /// <summary>
        Suggestion
    }

    /// <summary>
    /// Adds a warning/error message for Inspector fields
    /// </summary>
    public sealed class RequiredFieldAttribute : Attribute
    {
        public RequiredFieldType RequiredType {get; private set;}
        public string CustomMessage {get; private set;}

        public RequiredFieldAttribute(): this(RequiredFieldType.Suggestion, string.Empty) 
        {

        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">What kind of field</param>
        /// <param name="customMessage">Unique message if the field is missing. Otherwise a message will be generated"</param>
        public RequiredFieldAttribute(RequiredFieldType type, string customMessage = "") 
        {
            RequiredType = type; 
            CustomMessage = customMessage;
        }
    }
}