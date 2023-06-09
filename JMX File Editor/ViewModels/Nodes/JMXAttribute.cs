﻿namespace JMXFileEditor.ViewModels
{
    /// <summary>
    /// ViewModel representing a variable in the structure
    /// </summary>
    public class JMXAttribute : JMXProperty
    {
        #region Private Members
        private object m_Value;
        #endregion

        #region Public Properties
        /// <summary>
        /// Value handled by this node
        /// </summary>
        public object Value
        {
            get => m_Value;
            set
            {
                // Ignore sets if cannot be edited
                if (IsEditable)
                {
                    // Make sure the new value can be converted to the original value
                    var valueType = Value.GetType();
                    if (valueType.IsEnum)
                        m_Value = System.Enum.Parse(valueType, value.ToString(), true);
                    else
                        m_Value = System.Convert.ChangeType(value, valueType);
                    OnPropertyChanged(nameof(Value));
                }
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a child node view model which represents generic data object
        /// </summary>
        public JMXAttribute(string Name, object Value, bool IsEditable = true) : base(Name, IsEditable)
        {
            m_Value = Value;
        }
        #endregion
    }
}