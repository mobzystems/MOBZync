namespace MOBZync
{
  partial class CopyForm
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CopyForm));
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.syncRadioButton = new System.Windows.Forms.RadioButton();
      this.rightToLeftRadioButton = new System.Windows.Forms.RadioButton();
      this.leftToRightRadioButton = new System.Windows.Forms.RadioButton();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.radioButtonLeaveChangedFiles = new System.Windows.Forms.RadioButton();
      this.warningOlderOverNewerLabel = new System.Windows.Forms.Label();
      this.olderOverNewerRadioButton = new System.Windows.Forms.RadioButton();
      this.newerOverOlderRadioButton = new System.Windows.Forms.RadioButton();
      this.okButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.warningDeleteAddedLabel = new System.Windows.Forms.Label();
      this.skipAddedRadioButton = new System.Windows.Forms.RadioButton();
      this.deleteAddedRadioButton = new System.Windows.Forms.RadioButton();
      this.copyAddedRadioButton = new System.Windows.Forms.RadioButton();
      this.toolTip = new System.Windows.Forms.ToolTip(this.components);
      this.leaveUnchangedRadioButton = new System.Windows.Forms.RadioButton();
      this.deleteUnchangedRadioButton = new System.Windows.Forms.RadioButton();
      this.label1 = new System.Windows.Forms.Label();
      this.leftFolderTextBox = new System.Windows.Forms.TextBox();
      this.rightFolderTextBox = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.groupBox4 = new System.Windows.Forms.GroupBox();
      this.warningDeleteUnchangedLabel = new System.Windows.Forms.Label();
      this.previewCheckBox = new System.Windows.Forms.CheckBox();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.syncRadioButton);
      this.groupBox1.Controls.Add(this.rightToLeftRadioButton);
      this.groupBox1.Controls.Add(this.leftToRightRadioButton);
      this.groupBox1.Location = new System.Drawing.Point(4, 60);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(582, 89);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Operation";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(146, 67);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(139, 13);
      this.label5.TabIndex = 5;
      this.label5.Text = "Copy files in both directions";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(146, 44);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(259, 13);
      this.label4.TabIndex = 3;
      this.label4.Text = "Copy files from the right folder to the left folder only";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(146, 21);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(259, 13);
      this.label3.TabIndex = 1;
      this.label3.Text = "Copy files from the left folder to the right folder only";
      // 
      // syncRadioButton
      // 
      this.syncRadioButton.AutoSize = true;
      this.syncRadioButton.Checked = true;
      this.syncRadioButton.Location = new System.Drawing.Point(24, 65);
      this.syncRadioButton.Name = "syncRadioButton";
      this.syncRadioButton.Size = new System.Drawing.Size(83, 17);
      this.syncRadioButton.TabIndex = 4;
      this.syncRadioButton.TabStop = true;
      this.syncRadioButton.Text = "&Synchronize";
      this.toolTip.SetToolTip(this.syncRadioButton, "Copy files in both directions");
      this.syncRadioButton.UseVisualStyleBackColor = true;
      // 
      // rightToLeftRadioButton
      // 
      this.rightToLeftRadioButton.AutoSize = true;
      this.rightToLeftRadioButton.Location = new System.Drawing.Point(24, 42);
      this.rightToLeftRadioButton.Name = "rightToLeftRadioButton";
      this.rightToLeftRadioButton.Size = new System.Drawing.Size(107, 17);
      this.rightToLeftRadioButton.TabIndex = 2;
      this.rightToLeftRadioButton.Text = "Copy &right to left";
      this.toolTip.SetToolTip(this.rightToLeftRadioButton, "Copy files from the right folder to the left folder only");
      this.rightToLeftRadioButton.UseVisualStyleBackColor = true;
      // 
      // leftToRightRadioButton
      // 
      this.leftToRightRadioButton.AutoSize = true;
      this.leftToRightRadioButton.Location = new System.Drawing.Point(24, 19);
      this.leftToRightRadioButton.Name = "leftToRightRadioButton";
      this.leftToRightRadioButton.Size = new System.Drawing.Size(107, 17);
      this.leftToRightRadioButton.TabIndex = 0;
      this.leftToRightRadioButton.Text = "Copy &left to right";
      this.toolTip.SetToolTip(this.leftToRightRadioButton, "Copy files from the left folder to the right folder only");
      this.leftToRightRadioButton.UseVisualStyleBackColor = true;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.radioButtonLeaveChangedFiles);
      this.groupBox2.Controls.Add(this.warningOlderOverNewerLabel);
      this.groupBox2.Controls.Add(this.olderOverNewerRadioButton);
      this.groupBox2.Controls.Add(this.newerOverOlderRadioButton);
      this.groupBox2.Location = new System.Drawing.Point(4, 155);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(200, 92);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Changed files";
      // 
      // radioButtonLeaveChangedFiles
      // 
      this.radioButtonLeaveChangedFiles.AutoSize = true;
      this.radioButtonLeaveChangedFiles.Location = new System.Drawing.Point(24, 65);
      this.radioButtonLeaveChangedFiles.Name = "radioButtonLeaveChangedFiles";
      this.radioButtonLeaveChangedFiles.Size = new System.Drawing.Size(149, 17);
      this.radioButtonLeaveChangedFiles.TabIndex = 3;
      this.radioButtonLeaveChangedFiles.Text = "&Leave changed files alone";
      this.toolTip.SetToolTip(this.radioButtonLeaveChangedFiles, "Do not copy changed files");
      this.radioButtonLeaveChangedFiles.UseVisualStyleBackColor = true;
      // 
      // warningOlderOverNewerLabel
      // 
      this.warningOlderOverNewerLabel.AutoSize = true;
      this.warningOlderOverNewerLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.warningOlderOverNewerLabel.ForeColor = System.Drawing.Color.Red;
      this.warningOlderOverNewerLabel.Location = new System.Drawing.Point(8, 44);
      this.warningOlderOverNewerLabel.Name = "warningOlderOverNewerLabel";
      this.warningOlderOverNewerLabel.Size = new System.Drawing.Size(10, 13);
      this.warningOlderOverNewerLabel.TabIndex = 1;
      this.warningOlderOverNewerLabel.Text = "!";
      this.warningOlderOverNewerLabel.Visible = false;
      // 
      // olderOverNewerRadioButton
      // 
      this.olderOverNewerRadioButton.AutoSize = true;
      this.olderOverNewerRadioButton.Location = new System.Drawing.Point(24, 42);
      this.olderOverNewerRadioButton.Name = "olderOverNewerRadioButton";
      this.olderOverNewerRadioButton.Size = new System.Drawing.Size(157, 17);
      this.olderOverNewerRadioButton.TabIndex = 2;
      this.olderOverNewerRadioButton.Text = "Copy &older over newer files";
      this.toolTip.SetToolTip(this.olderOverNewerRadioButton, "Replace newer files with older files");
      this.olderOverNewerRadioButton.UseVisualStyleBackColor = true;
      // 
      // newerOverOlderRadioButton
      // 
      this.newerOverOlderRadioButton.AutoSize = true;
      this.newerOverOlderRadioButton.Checked = true;
      this.newerOverOlderRadioButton.Location = new System.Drawing.Point(24, 19);
      this.newerOverOlderRadioButton.Name = "newerOverOlderRadioButton";
      this.newerOverOlderRadioButton.Size = new System.Drawing.Size(157, 17);
      this.newerOverOlderRadioButton.TabIndex = 0;
      this.newerOverOlderRadioButton.TabStop = true;
      this.newerOverOlderRadioButton.Text = "Copy &newer over older files";
      this.toolTip.SetToolTip(this.newerOverOlderRadioButton, "Replace older files wih newer files");
      this.newerOverOlderRadioButton.UseVisualStyleBackColor = true;
      // 
      // okButton
      // 
      this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.okButton.Location = new System.Drawing.Point(405, 256);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(87, 24);
      this.okButton.TabIndex = 5;
      this.okButton.Text = "OK";
      this.toolTip.SetToolTip(this.okButton, "Perform the selected operation");
      this.okButton.UseVisualStyleBackColor = true;
      // 
      // cancelButton
      // 
      this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(498, 256);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(87, 24);
      this.cancelButton.TabIndex = 6;
      this.cancelButton.Text = "Cancel";
      this.toolTip.SetToolTip(this.cancelButton, "Close this window - no action will be performed");
      this.cancelButton.UseVisualStyleBackColor = true;
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.warningDeleteAddedLabel);
      this.groupBox3.Controls.Add(this.skipAddedRadioButton);
      this.groupBox3.Controls.Add(this.deleteAddedRadioButton);
      this.groupBox3.Controls.Add(this.copyAddedRadioButton);
      this.groupBox3.Location = new System.Drawing.Point(417, 155);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(167, 92);
      this.groupBox3.TabIndex = 3;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Added files";
      // 
      // warningDeleteAddedLabel
      // 
      this.warningDeleteAddedLabel.AutoSize = true;
      this.warningDeleteAddedLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.warningDeleteAddedLabel.ForeColor = System.Drawing.Color.Red;
      this.warningDeleteAddedLabel.Location = new System.Drawing.Point(8, 44);
      this.warningDeleteAddedLabel.Name = "warningDeleteAddedLabel";
      this.warningDeleteAddedLabel.Size = new System.Drawing.Size(10, 13);
      this.warningDeleteAddedLabel.TabIndex = 1;
      this.warningDeleteAddedLabel.Text = "!";
      this.warningDeleteAddedLabel.Visible = false;
      // 
      // skipAddedRadioButton
      // 
      this.skipAddedRadioButton.AutoSize = true;
      this.skipAddedRadioButton.Location = new System.Drawing.Point(24, 65);
      this.skipAddedRadioButton.Name = "skipAddedRadioButton";
      this.skipAddedRadioButton.Size = new System.Drawing.Size(99, 17);
      this.skipAddedRadioButton.TabIndex = 3;
      this.skipAddedRadioButton.Text = "S&kip added files";
      this.toolTip.SetToolTip(this.skipAddedRadioButton, "Skip files that were added");
      this.skipAddedRadioButton.UseVisualStyleBackColor = true;
      // 
      // deleteAddedRadioButton
      // 
      this.deleteAddedRadioButton.AutoSize = true;
      this.deleteAddedRadioButton.Location = new System.Drawing.Point(24, 42);
      this.deleteAddedRadioButton.Name = "deleteAddedRadioButton";
      this.deleteAddedRadioButton.Size = new System.Drawing.Size(111, 17);
      this.deleteAddedRadioButton.TabIndex = 2;
      this.deleteAddedRadioButton.Text = "&Delete added files";
      this.toolTip.SetToolTip(this.deleteAddedRadioButton, "Delete files that were added");
      this.deleteAddedRadioButton.UseVisualStyleBackColor = true;
      // 
      // copyAddedRadioButton
      // 
      this.copyAddedRadioButton.AutoSize = true;
      this.copyAddedRadioButton.Checked = true;
      this.copyAddedRadioButton.Location = new System.Drawing.Point(24, 19);
      this.copyAddedRadioButton.Name = "copyAddedRadioButton";
      this.copyAddedRadioButton.Size = new System.Drawing.Size(105, 17);
      this.copyAddedRadioButton.TabIndex = 0;
      this.copyAddedRadioButton.TabStop = true;
      this.copyAddedRadioButton.Text = "&Copy added files";
      this.toolTip.SetToolTip(this.copyAddedRadioButton, "Copy files that were added");
      this.copyAddedRadioButton.UseVisualStyleBackColor = true;
      // 
      // leaveUnchangedRadioButton
      // 
      this.leaveUnchangedRadioButton.AutoSize = true;
      this.leaveUnchangedRadioButton.Checked = true;
      this.leaveUnchangedRadioButton.Location = new System.Drawing.Point(24, 19);
      this.leaveUnchangedRadioButton.Name = "leaveUnchangedRadioButton";
      this.leaveUnchangedRadioButton.Size = new System.Drawing.Size(161, 17);
      this.leaveUnchangedRadioButton.TabIndex = 0;
      this.leaveUnchangedRadioButton.TabStop = true;
      this.leaveUnchangedRadioButton.Text = "&Leave unchanged files alone";
      this.toolTip.SetToolTip(this.leaveUnchangedRadioButton, "Do not copy unchanged files");
      this.leaveUnchangedRadioButton.UseVisualStyleBackColor = true;
      // 
      // deleteUnchangedRadioButton
      // 
      this.deleteUnchangedRadioButton.AutoSize = true;
      this.deleteUnchangedRadioButton.Location = new System.Drawing.Point(24, 42);
      this.deleteUnchangedRadioButton.Name = "deleteUnchangedRadioButton";
      this.deleteUnchangedRadioButton.Size = new System.Drawing.Size(134, 17);
      this.deleteUnchangedRadioButton.TabIndex = 2;
      this.deleteUnchangedRadioButton.TabStop = true;
      this.deleteUnchangedRadioButton.Text = "Delete &unchanged files";
      this.toolTip.SetToolTip(this.deleteUnchangedRadioButton, "Delete unchanged files");
      this.deleteUnchangedRadioButton.UseVisualStyleBackColor = true;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(11, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(61, 13);
      this.label1.TabIndex = 7;
      this.label1.Text = "Left folder:";
      // 
      // leftFolderTextBox
      // 
      this.leftFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.leftFolderTextBox.Location = new System.Drawing.Point(78, 6);
      this.leftFolderTextBox.Name = "leftFolderTextBox";
      this.leftFolderTextBox.ReadOnly = true;
      this.leftFolderTextBox.Size = new System.Drawing.Size(507, 21);
      this.leftFolderTextBox.TabIndex = 8;
      // 
      // rightFolderTextBox
      // 
      this.rightFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.rightFolderTextBox.Location = new System.Drawing.Point(78, 33);
      this.rightFolderTextBox.Name = "rightFolderTextBox";
      this.rightFolderTextBox.ReadOnly = true;
      this.rightFolderTextBox.Size = new System.Drawing.Size(507, 21);
      this.rightFolderTextBox.TabIndex = 10;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(11, 36);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(67, 13);
      this.label2.TabIndex = 9;
      this.label2.Text = "Right folder:";
      // 
      // groupBox4
      // 
      this.groupBox4.Controls.Add(this.warningDeleteUnchangedLabel);
      this.groupBox4.Controls.Add(this.deleteUnchangedRadioButton);
      this.groupBox4.Controls.Add(this.leaveUnchangedRadioButton);
      this.groupBox4.Location = new System.Drawing.Point(210, 155);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new System.Drawing.Size(201, 92);
      this.groupBox4.TabIndex = 2;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Unchanged files";
      // 
      // warningDeleteUnchangedLabel
      // 
      this.warningDeleteUnchangedLabel.AutoSize = true;
      this.warningDeleteUnchangedLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.warningDeleteUnchangedLabel.ForeColor = System.Drawing.Color.Red;
      this.warningDeleteUnchangedLabel.Location = new System.Drawing.Point(8, 44);
      this.warningDeleteUnchangedLabel.Name = "warningDeleteUnchangedLabel";
      this.warningDeleteUnchangedLabel.Size = new System.Drawing.Size(10, 13);
      this.warningDeleteUnchangedLabel.TabIndex = 1;
      this.warningDeleteUnchangedLabel.Text = "!";
      this.warningDeleteUnchangedLabel.Visible = false;
      // 
      // previewCheckBox
      // 
      this.previewCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.previewCheckBox.AutoSize = true;
      this.previewCheckBox.Location = new System.Drawing.Point(28, 261);
      this.previewCheckBox.Name = "previewCheckBox";
      this.previewCheckBox.Size = new System.Drawing.Size(197, 17);
      this.previewCheckBox.TabIndex = 4;
      this.previewCheckBox.Text = "&Preview only - do not copy any files";
      this.previewCheckBox.UseVisualStyleBackColor = true;
      // 
      // CopyForm
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(590, 287);
      this.Controls.Add(this.previewCheckBox);
      this.Controls.Add(this.groupBox4);
      this.Controls.Add(this.rightFolderTextBox);
      this.Controls.Add(this.leftFolderTextBox);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.groupBox1);
      this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "CopyForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Synchronize folders";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.RadioButton syncRadioButton;
    private System.Windows.Forms.RadioButton rightToLeftRadioButton;
    private System.Windows.Forms.RadioButton leftToRightRadioButton;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.RadioButton olderOverNewerRadioButton;
    private System.Windows.Forms.RadioButton newerOverOlderRadioButton;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.RadioButton skipAddedRadioButton;
    private System.Windows.Forms.RadioButton deleteAddedRadioButton;
    private System.Windows.Forms.RadioButton copyAddedRadioButton;
    private System.Windows.Forms.ToolTip toolTip;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox leftFolderTextBox;
    private System.Windows.Forms.TextBox rightFolderTextBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.RadioButton deleteUnchangedRadioButton;
    private System.Windows.Forms.RadioButton leaveUnchangedRadioButton;
    private System.Windows.Forms.Label warningOlderOverNewerLabel;
    private System.Windows.Forms.Label warningDeleteAddedLabel;
    private System.Windows.Forms.Label warningDeleteUnchangedLabel;
    private System.Windows.Forms.RadioButton radioButtonLeaveChangedFiles;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.CheckBox previewCheckBox;
  }
}