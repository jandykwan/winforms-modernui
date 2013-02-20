﻿using System.Collections;
using System.ComponentModel;
using System.Windows.Forms.Design;

namespace MetroFramework.Design
{
    internal class MetroTileDesigner : ParentControlDesigner
    {
        public override SelectionRules SelectionRules
        {
            get
            {
                return base.SelectionRules;
            }
        }

        public override bool CanParent(System.Windows.Forms.Control control)
        {
            return (control is Controls.MetroLabel || control is Controls.MetroProgressSpinner);
        }

        protected override void PreFilterProperties(IDictionary properties)
        {
            properties.Remove("ImeMode");
            properties.Remove("Padding");
            properties.Remove("FlatAppearance");
            properties.Remove("FlatStyle");
            properties.Remove("AutoEllipsis");
            properties.Remove("UseCompatibleTextRendering");

            properties.Remove("Image");
            properties.Remove("ImageAlign");
            properties.Remove("ImageIndex");
            properties.Remove("ImageKey");
            properties.Remove("ImageList");
            properties.Remove("TextImageRelation");

            properties.Remove("BackColor");
            properties.Remove("BackgroundImage");
            properties.Remove("BackgroundImageLayout");
            properties.Remove("UseVisualStyleBackColor");

            properties.Remove("Font");
            properties.Remove("ForeColor");
            properties.Remove("RightToLeft");

            base.PreFilterProperties(properties);
        }
    }
}
