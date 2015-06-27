namespace cefsharp_v2
{
  partial class FrmMainForm
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
      this.PnlControls = new System.Windows.Forms.Panel();
      this.btnPopulateForm = new System.Windows.Forms.Button();
      this.btnChangeHeader = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.PnlInfo = new System.Windows.Forms.Panel();
      this.LsbMessages = new System.Windows.Forms.ListBox();
      this.PnlHtml = new System.Windows.Forms.Panel();
      this.PnlControls.SuspendLayout();
      this.PnlInfo.SuspendLayout();
      this.SuspendLayout();
      // 
      // PnlControls
      // 
      this.PnlControls.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.PnlControls.Controls.Add(this.btnPopulateForm);
      this.PnlControls.Controls.Add(this.btnChangeHeader);
      this.PnlControls.Controls.Add(this.label1);
      this.PnlControls.Dock = System.Windows.Forms.DockStyle.Top;
      this.PnlControls.Location = new System.Drawing.Point(0, 0);
      this.PnlControls.Name = "PnlControls";
      this.PnlControls.Size = new System.Drawing.Size(878, 55);
      this.PnlControls.TabIndex = 0;
      // 
      // btnPopulateForm
      // 
      this.btnPopulateForm.Location = new System.Drawing.Point(168, 18);
      this.btnPopulateForm.Name = "btnPopulateForm";
      this.btnPopulateForm.Size = new System.Drawing.Size(150, 23);
      this.btnPopulateForm.TabIndex = 2;
      this.btnPopulateForm.Text = "Populate the form";
      this.btnPopulateForm.UseVisualStyleBackColor = true;
      this.btnPopulateForm.Click += new System.EventHandler(this.BtnPopulateFormClick);
      // 
      // btnChangeHeader
      // 
      this.btnChangeHeader.Location = new System.Drawing.Point(12, 18);
      this.btnChangeHeader.Name = "btnChangeHeader";
      this.btnChangeHeader.Size = new System.Drawing.Size(150, 23);
      this.btnChangeHeader.TabIndex = 1;
      this.btnChangeHeader.Text = "Change the page header";
      this.btnChangeHeader.UseVisualStyleBackColor = true;
      this.btnChangeHeader.Click += new System.EventHandler(this.BtnChangeHeaderClick);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(324, 23);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(399, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "The buttons in this area are regular win forms buttons to call javascript in your" +
    " page.";
      // 
      // PnlInfo
      // 
      this.PnlInfo.BackColor = System.Drawing.SystemColors.AppWorkspace;
      this.PnlInfo.Controls.Add(this.LsbMessages);
      this.PnlInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.PnlInfo.Location = new System.Drawing.Point(0, 435);
      this.PnlInfo.Name = "PnlInfo";
      this.PnlInfo.Size = new System.Drawing.Size(878, 145);
      this.PnlInfo.TabIndex = 1;
      // 
      // LsbMessages
      // 
      this.LsbMessages.Dock = System.Windows.Forms.DockStyle.Fill;
      this.LsbMessages.FormattingEnabled = true;
      this.LsbMessages.Location = new System.Drawing.Point(0, 0);
      this.LsbMessages.Name = "LsbMessages";
      this.LsbMessages.Size = new System.Drawing.Size(878, 145);
      this.LsbMessages.TabIndex = 0;
      // 
      // PnlHtml
      // 
      this.PnlHtml.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PnlHtml.Location = new System.Drawing.Point(0, 55);
      this.PnlHtml.Name = "PnlHtml";
      this.PnlHtml.Size = new System.Drawing.Size(878, 380);
      this.PnlHtml.TabIndex = 2;
      // 
      // FrmMainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(878, 580);
      this.Controls.Add(this.PnlHtml);
      this.Controls.Add(this.PnlInfo);
      this.Controls.Add(this.PnlControls);
      this.Name = "FrmMainForm";
      this.Text = "Cef Sharp Example";
      this.PnlControls.ResumeLayout(false);
      this.PnlControls.PerformLayout();
      this.PnlInfo.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel PnlControls;
    private System.Windows.Forms.Panel PnlInfo;
    private System.Windows.Forms.ListBox LsbMessages;
    private System.Windows.Forms.Panel PnlHtml;
    private System.Windows.Forms.Button btnPopulateForm;
    private System.Windows.Forms.Button btnChangeHeader;
    private System.Windows.Forms.Label label1;
  }
}

