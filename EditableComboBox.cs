using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace XamDataGrid.Zoomable
{

    /// <summary>
    /// Represents a ComboBox that's optimized for user text entry.
    /// </summary>
    /// <remarks></remarks>
    class EditableComboBox : ComboBox
    {

        public EditableComboBox()
        {
            this.IsEditable = true;
        }

        /// <summary>
        /// Updates the text binding source if the enter key was pressed.
        /// </summary>
        /// <param name="e">The event arguments for the key up event.</param>
        /// <remarks></remarks>
        protected override void OnKeyUp(System.Windows.Input.KeyEventArgs e)
        {
            base.OnKeyUp(e);

            if (e.Key == System.Windows.Input.Key.Enter)
                UpdateBindingSource();

        }

        /// <summary>
        /// Updates the text binding source.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        /// <remarks></remarks>
        protected override void OnDropDownClosed(System.EventArgs e)
        {
            base.OnDropDownClosed(e);
            UpdateBindingSource();
        }

        /// <summary>
        /// Updates the binding source on the ComboBox's Text property if binding has been set.
        /// </summary>
        /// <remarks></remarks>
        protected virtual void UpdateBindingSource()
        {
            var expression = GetBindingExpression(ComboBox.TextProperty);

            if (expression != null)
                expression.UpdateSource();

        }

    }
}
