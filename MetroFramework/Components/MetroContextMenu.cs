﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using MetroFramework.Interfaces;
using MetroFramework.Drawing;

namespace MetroFramework.Components
{
    // !!! important hint:
    // currently under construction, do not use this in production environment!

    class MetroContextMenuRenderer : ToolStripRenderer
    {
        #region Interface

        private MetroColorStyle metroStyle = MetroColorStyle.Blue;
        [Category("Metro Appearance")]
        public MetroColorStyle Style
        {
            get
            {
                if (StyleManager != null)
                    return StyleManager.Style;

                return metroStyle;
            }
            set { metroStyle = value; }
        }

        private MetroThemeStyle metroTheme = MetroThemeStyle.Light;
        [Category("Metro Appearance")]
        public MetroThemeStyle Theme
        {
            get
            {
                if (StyleManager != null)
                    return StyleManager.Theme;

                return metroTheme;
            }
            set { metroTheme = value; }
        }

        private MetroStyleManager metroStyleManager = null;
        [Browsable(false)]
        public MetroStyleManager StyleManager
        {
            get { return metroStyleManager; }
            set { metroStyleManager = value; }
        }

        #endregion

        protected override void Initialize(ToolStrip toolStrip)
        {
            base.Initialize(toolStrip);
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            e.Graphics.Clear(MetroPaint.BackColor.Form(Theme));
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            using (Pen p = new Pen(MetroPaint.BorderColor.Button.Hover(Theme)))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(0, 0, e.AffectedBounds.Width - 1, e.AffectedBounds.Height - 1));
            }
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.Item.Font = MetroFonts.Link(MetroLinkSize.Medium, MetroLinkWeight.Regular);

            if (e.Item.Selected)
            {
                e.Item.ForeColor = MetroPaint.ForeColor.Tile.Normal(Theme);
            }
            else
            {
                e.Item.ForeColor = MetroPaint.ForeColor.Link.Normal(Theme);
            }

            base.OnRenderItemText(e);
        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Selected)
            {
                e.Graphics.Clear(MetroPaint.GetStyleColor(Style));
            }

            base.OnRenderButtonBackground(e);
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Selected)
            {
                e.Graphics.Clear(MetroPaint.GetStyleColor(Style));
            }

            base.OnRenderMenuItemBackground(e);
        }

        protected override void OnRenderItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Selected)
            {
                e.Graphics.Clear(MetroPaint.GetStyleColor(Style));
            }

            base.OnRenderItemBackground(e);
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.ArrowColor = MetroPaint.BorderColor.Button.Normal(Theme);
            base.OnRenderArrow(e);
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            if (e.Vertical)
            {
                using (Pen p = new Pen(MetroPaint.BorderColor.Button.Normal(Theme)))
                {
                    e.Graphics.DrawLine(p, new Point(e.Item.Width / 2, 0), new Point(e.Item.Width / 2, e.Item.Height - 1));
                }
            }
            else
            {
                using (Pen p = new Pen(MetroPaint.BorderColor.Button.Normal(Theme)))
                {
                    e.Graphics.DrawLine(p, new Point(3, e.Item.Height / 2), new Point(e.Item.Width - 5, e.Item.Height / 2));
                }
            }
        }
    }

    public class MetroContextMenu : ContextMenuStrip, IMetroComponent
    {
        #region Interface

        private MetroColorStyle metroStyle = MetroColorStyle.Blue;
        [Category("Metro Appearance")]
        public MetroColorStyle Style
        {
            get
            {
                if (StyleManager != null)
                    return StyleManager.Style;

                return metroStyle;
            }
            set { metroStyle = value; metroRenderer.Style = value; }
        }

        private MetroThemeStyle metroTheme = MetroThemeStyle.Light;
        [Category("Metro Appearance")]
        public MetroThemeStyle Theme
        {
            get
            {
                if (StyleManager != null)
                    return StyleManager.Theme;

                return metroTheme;
            }
            set { metroTheme = value; metroRenderer.Theme = value; }
        }

        private MetroStyleManager metroStyleManager = null;
        [Browsable(false)]
        public MetroStyleManager StyleManager
        {
            get { return metroStyleManager; }
            set { metroStyleManager = value; metroRenderer.StyleManager = value; }
        }

        #endregion

        #region Fields

        private MetroContextMenuRenderer metroRenderer = new MetroContextMenuRenderer();

        #endregion

        #region Constructor

        public MetroContextMenu()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint, true);

            if (!DesignMode)
            {
                Renderer = metroRenderer;
            }
        }

        #endregion
    }
}
