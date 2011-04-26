namespace MOBZync
{
  partial class FolderTree
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Folder",
            "123",
            "1234"}, 0);
      System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("File", 1);
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FolderTree));
      System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node1");
      System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node2");
      System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.listView = new System.Windows.Forms.ListView();
      this.nameColumnHeader = new System.Windows.Forms.ColumnHeader();
      this.sizeColumnHeader = new System.Windows.Forms.ColumnHeader();
      this.modifiedDateColumnHeader = new System.Windows.Forms.ColumnHeader();
      this.stateColumnHeader = new System.Windows.Forms.ColumnHeader();
      this.toolStrip = new System.Windows.Forms.ToolStrip();
      this.folderTextBox = new System.Windows.Forms.ToolStripComboBox();
      this.browseButton = new System.Windows.Forms.ToolStripButton();
      this.folderUpButton = new System.Windows.Forms.ToolStripButton();
      this.splitContainer = new System.Windows.Forms.SplitContainer();
      this.treeView = new System.Windows.Forms.TreeView();
      this.treeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.excludeTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.cancelTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.statusStrip.SuspendLayout();
      this.toolStrip.SuspendLayout();
      this.splitContainer.Panel1.SuspendLayout();
      this.splitContainer.Panel2.SuspendLayout();
      this.splitContainer.SuspendLayout();
      this.treeContextMenuStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // statusStrip
      // 
      this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
      this.statusStrip.Location = new System.Drawing.Point(0, 352);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Size = new System.Drawing.Size(555, 22);
      this.statusStrip.SizingGrip = false;
      this.statusStrip.TabIndex = 2;
      this.statusStrip.Text = "statusStrip1";
      // 
      // statusLabel
      // 
      this.statusLabel.Name = "statusLabel";
      this.statusLabel.Size = new System.Drawing.Size(156, 17);
      this.statusLabel.Text = "Open a folder to view contents";
      // 
      // listView
      // 
      this.listView.AllowColumnReorder = true;
      this.listView.BackColor = System.Drawing.SystemColors.Window;
      this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.sizeColumnHeader,
            this.modifiedDateColumnHeader,
            this.stateColumnHeader});
      this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listView.FullRowSelect = true;
      this.listView.HideSelection = false;
      listViewItem1.StateImageIndex = 0;
      listViewItem2.Checked = true;
      listViewItem2.StateImageIndex = 1;
      this.listView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
      this.listView.Location = new System.Drawing.Point(0, 0);
      this.listView.Name = "listView";
      this.listView.Size = new System.Drawing.Size(555, 229);
      this.listView.TabIndex = 1;
      this.listView.UseCompatibleStateImageBehavior = false;
      this.listView.View = System.Windows.Forms.View.Details;
      this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
      this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
      this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
      // 
      // nameColumnHeader
      // 
      this.nameColumnHeader.Text = "Name";
      // 
      // sizeColumnHeader
      // 
      this.sizeColumnHeader.Text = "Size";
      this.sizeColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // modifiedDateColumnHeader
      // 
      this.modifiedDateColumnHeader.DisplayIndex = 3;
      this.modifiedDateColumnHeader.Text = "Modified";
      // 
      // stateColumnHeader
      // 
      this.stateColumnHeader.DisplayIndex = 2;
      this.stateColumnHeader.Text = "State";
      this.stateColumnHeader.Width = 120;
      // 
      // toolStrip
      // 
      this.toolStrip.CanOverflow = false;
      this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.folderTextBox,
            this.browseButton,
            this.folderUpButton});
      this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
      this.toolStrip.Location = new System.Drawing.Point(0, 0);
      this.toolStrip.Name = "toolStrip";
      this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      this.toolStrip.Size = new System.Drawing.Size(555, 25);
      this.toolStrip.TabIndex = 0;
      this.toolStrip.TabStop = true;
      this.toolStrip.SizeChanged += new System.EventHandler(this.toolStrip_SizeChanged);
      // 
      // folderTextBox
      // 
      this.folderTextBox.AutoSize = false;
      this.folderTextBox.Name = "folderTextBox";
      this.folderTextBox.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
      this.folderTextBox.Size = new System.Drawing.Size(400, 21);
      this.folderTextBox.DropDownClosed += new System.EventHandler(this.folderTextBox_DropDownClosed);
      this.folderTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.folderTextBox_KeyPress);
      // 
      // browseButton
      // 
      this.browseButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.browseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.browseButton.Image = ((System.Drawing.Image)(resources.GetObject("browseButton.Image")));
      this.browseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.browseButton.Name = "browseButton";
      this.browseButton.Size = new System.Drawing.Size(23, 22);
      this.browseButton.ToolTipText = "Open folder";
      this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
      // 
      // folderUpButton
      // 
      this.folderUpButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.folderUpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.folderUpButton.Image = ((System.Drawing.Image)(resources.GetObject("folderUpButton.Image")));
      this.folderUpButton.ImageTransparentColor = System.Drawing.Color.Transparent;
      this.folderUpButton.Name = "folderUpButton";
      this.folderUpButton.Size = new System.Drawing.Size(23, 22);
      this.folderUpButton.ToolTipText = "Up";
      this.folderUpButton.Click += new System.EventHandler(this.folderUpButton_Click);
      // 
      // splitContainer
      // 
      this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer.Location = new System.Drawing.Point(0, 25);
      this.splitContainer.Name = "splitContainer";
      this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer.Panel1
      // 
      this.splitContainer.Panel1.Controls.Add(this.treeView);
      // 
      // splitContainer.Panel2
      // 
      this.splitContainer.Panel2.Controls.Add(this.listView);
      this.splitContainer.Size = new System.Drawing.Size(555, 327);
      this.splitContainer.SplitterDistance = 94;
      this.splitContainer.TabIndex = 3;
      this.splitContainer.TabStop = false;
      // 
      // treeView
      // 
      this.treeView.ContextMenuStrip = this.treeContextMenuStrip;
      this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.treeView.FullRowSelect = true;
      this.treeView.HideSelection = false;
      this.treeView.Location = new System.Drawing.Point(0, 0);
      this.treeView.Name = "treeView";
      treeNode1.Name = "Node1";
      treeNode1.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      treeNode1.Text = "Node1";
      treeNode2.Name = "Node2";
      treeNode2.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      treeNode2.Text = "Node2";
      treeNode3.Name = "Node0";
      treeNode3.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      treeNode3.Text = "Node0";
      this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
      this.treeView.Size = new System.Drawing.Size(555, 94);
      this.treeView.TabIndex = 0;
      this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
      // 
      // treeContextMenuStrip
      // 
      this.treeContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excludeTreeToolStripMenuItem,
            this.toolStripSeparator1,
            this.cancelTreeToolStripMenuItem});
      this.treeContextMenuStrip.Name = "treeContextMenuStrip";
      this.treeContextMenuStrip.Size = new System.Drawing.Size(123, 54);
      // 
      // excludeTreeToolStripMenuItem
      // 
      this.excludeTreeToolStripMenuItem.CheckOnClick = true;
      this.excludeTreeToolStripMenuItem.Name = "excludeTreeToolStripMenuItem";
      this.excludeTreeToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
      this.excludeTreeToolStripMenuItem.Text = "&Exclude";
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(119, 6);
      // 
      // cancelTreeToolStripMenuItem
      // 
      this.cancelTreeToolStripMenuItem.Name = "cancelTreeToolStripMenuItem";
      this.cancelTreeToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
      this.cancelTreeToolStripMenuItem.Text = "Cancel";
      // 
      // FolderTree
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.splitContainer);
      this.Controls.Add(this.toolStrip);
      this.Controls.Add(this.statusStrip);
      this.Name = "FolderTree";
      this.Size = new System.Drawing.Size(555, 374);
      this.statusStrip.ResumeLayout(false);
      this.statusStrip.PerformLayout();
      this.toolStrip.ResumeLayout(false);
      this.toolStrip.PerformLayout();
      this.splitContainer.Panel1.ResumeLayout(false);
      this.splitContainer.Panel2.ResumeLayout(false);
      this.splitContainer.ResumeLayout(false);
      this.treeContextMenuStrip.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ListView listView;
    private System.Windows.Forms.ToolStrip toolStrip;
    private System.Windows.Forms.ColumnHeader nameColumnHeader;
    private System.Windows.Forms.ColumnHeader sizeColumnHeader;
    private System.Windows.Forms.ColumnHeader modifiedDateColumnHeader;
    private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    private System.Windows.Forms.ToolStripButton browseButton;
    private System.Windows.Forms.ToolStripComboBox folderTextBox;
    private System.Windows.Forms.ToolStripButton folderUpButton;
    private System.Windows.Forms.SplitContainer splitContainer;
    private System.Windows.Forms.TreeView treeView;
    private System.Windows.Forms.ContextMenuStrip treeContextMenuStrip;
    private System.Windows.Forms.ToolStripMenuItem excludeTreeToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem cancelTreeToolStripMenuItem;
    private System.Windows.Forms.ColumnHeader stateColumnHeader;
  }
}
