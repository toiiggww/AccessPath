namespace AccessPath
{
    partial class AccessFinder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mbrBrowser = new System.Windows.Forms.Panel();
            this.mbrClosepand = new System.Windows.Forms.Panel();
            this.mbrExpand = new System.Windows.Forms.Panel();
            this.mbrType = new System.Windows.Forms.ComboBox();
            this.mbrDraw = new System.Windows.Forms.TreeView();
            this.mbrFinder = new System.Windows.Forms.TextBox();
            this.mbrCopy = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.mbrBrowser, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mbrClosepand, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.mbrExpand, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.mbrType, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.mbrDraw, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.mbrFinder, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.mbrCopy, 5, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(883, 440);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // mbrBrowser
            // 
            this.mbrBrowser.BackColor = System.Drawing.Color.Indigo;
            this.mbrBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mbrBrowser.Location = new System.Drawing.Point(0, 0);
            this.mbrBrowser.Margin = new System.Windows.Forms.Padding(0);
            this.mbrBrowser.Name = "mbrBrowser";
            this.mbrBrowser.Size = new System.Drawing.Size(20, 20);
            this.mbrBrowser.TabIndex = 0;
            this.mbrBrowser.DoubleClick += new System.EventHandler(this.mbrBrowser_DoubleClick);
            // 
            // mbrClosepand
            // 
            this.mbrClosepand.BackColor = System.Drawing.Color.Violet;
            this.mbrClosepand.Location = new System.Drawing.Point(842, 0);
            this.mbrClosepand.Margin = new System.Windows.Forms.Padding(0);
            this.mbrClosepand.Name = "mbrClosepand";
            this.mbrClosepand.Size = new System.Drawing.Size(21, 20);
            this.mbrClosepand.TabIndex = 2;
            this.mbrClosepand.DoubleClick += new System.EventHandler(this.mbrClosepand_DoubleClick);
            // 
            // mbrExpand
            // 
            this.mbrExpand.BackColor = System.Drawing.Color.Plum;
            this.mbrExpand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mbrExpand.Location = new System.Drawing.Point(822, 0);
            this.mbrExpand.Margin = new System.Windows.Forms.Padding(0);
            this.mbrExpand.Name = "mbrExpand";
            this.mbrExpand.Size = new System.Drawing.Size(20, 20);
            this.mbrExpand.TabIndex = 1;
            this.mbrExpand.DoubleClick += new System.EventHandler(this.mbrExpand_DoubleClick);
            // 
            // mbrType
            // 
            this.mbrType.BackColor = System.Drawing.Color.DarkOrchid;
            this.mbrType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mbrType.ForeColor = System.Drawing.Color.Gold;
            this.mbrType.Location = new System.Drawing.Point(20, 0);
            this.mbrType.Margin = new System.Windows.Forms.Padding(0);
            this.mbrType.Name = "mbrType";
            this.mbrType.Size = new System.Drawing.Size(401, 20);
            this.mbrType.TabIndex = 3;
            this.mbrType.SelectedValueChanged += new System.EventHandler(this.mbrType_SelectedValueChanged);
            this.mbrType.TextChanged += new System.EventHandler(this.mbrType_TextChanged);
            this.mbrType.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mbrType_MouseDoubleClick);
            // 
            // mbrDraw
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.mbrDraw, 6);
            this.mbrDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mbrDraw.Location = new System.Drawing.Point(0, 20);
            this.mbrDraw.Margin = new System.Windows.Forms.Padding(0);
            this.mbrDraw.Name = "mbrDraw";
            this.mbrDraw.Size = new System.Drawing.Size(883, 420);
            this.mbrDraw.TabIndex = 4;
            this.mbrDraw.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.mbrDraw_AfterExpand);
            this.mbrDraw.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.mbrDraw_NodeMouseDoubleClick);
            // 
            // mbrFinder
            // 
            this.mbrFinder.BackColor = System.Drawing.Color.MediumOrchid;
            this.mbrFinder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mbrFinder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mbrFinder.Location = new System.Drawing.Point(424, 3);
            this.mbrFinder.Name = "mbrFinder";
            this.mbrFinder.Size = new System.Drawing.Size(395, 14);
            this.mbrFinder.TabIndex = 5;
            this.mbrFinder.TextChanged += new System.EventHandler(this.mbrFinder_TextChanged);
            // 
            // mbrCopy
            // 
            this.mbrCopy.BackColor = System.Drawing.Color.Purple;
            this.mbrCopy.Location = new System.Drawing.Point(863, 0);
            this.mbrCopy.Margin = new System.Windows.Forms.Padding(0);
            this.mbrCopy.Name = "mbrCopy";
            this.mbrCopy.Size = new System.Drawing.Size(20, 20);
            this.mbrCopy.TabIndex = 2;
            this.mbrCopy.DoubleClick += new System.EventHandler(this.mbrCopy_DoubleClick);
            // 
            // AccessFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 464);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AccessFinder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Access Finder";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel mbrBrowser;
        private System.Windows.Forms.Panel mbrClosepand;
        private System.Windows.Forms.Panel mbrExpand;
        private System.Windows.Forms.ComboBox mbrType;
        private System.Windows.Forms.TreeView mbrDraw;
        private System.Windows.Forms.TextBox mbrFinder;
        private System.Windows.Forms.Panel mbrCopy;
    }
}

