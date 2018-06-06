namespace bcNewLineSpec
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.NewEqTextBox = new System.Windows.Forms.TextBox();
            this.AddEqButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.eqListBox = new System.Windows.Forms.ListBox();
            this.DelEqButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.EventCheckListBox = new System.Windows.Forms.CheckedListBox();
            this.AddEventButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SelectedListBox = new System.Windows.Forms.ListBox();
            this.ProduceBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NewEqTextBox
            // 
            this.NewEqTextBox.Location = new System.Drawing.Point(41, 23);
            this.NewEqTextBox.Name = "NewEqTextBox";
            this.NewEqTextBox.Size = new System.Drawing.Size(117, 22);
            this.NewEqTextBox.TabIndex = 0;
            // 
            // AddEqButton
            // 
            this.AddEqButton.Location = new System.Drawing.Point(40, 51);
            this.AddEqButton.Name = "AddEqButton";
            this.AddEqButton.Size = new System.Drawing.Size(40, 22);
            this.AddEqButton.TabIndex = 1;
            this.AddEqButton.Text = "+";
            this.AddEqButton.UseVisualStyleBackColor = true;
            this.AddEqButton.Click += new System.EventHandler(this.AddEqButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "EQ list:";
            // 
            // eqListBox
            // 
            this.eqListBox.FormattingEnabled = true;
            this.eqListBox.ItemHeight = 12;
            this.eqListBox.Location = new System.Drawing.Point(41, 109);
            this.eqListBox.Name = "eqListBox";
            this.eqListBox.Size = new System.Drawing.Size(138, 412);
            this.eqListBox.TabIndex = 3;
            // 
            // DelEqButton
            // 
            this.DelEqButton.Location = new System.Drawing.Point(86, 51);
            this.DelEqButton.Name = "DelEqButton";
            this.DelEqButton.Size = new System.Drawing.Size(40, 22);
            this.DelEqButton.TabIndex = 4;
            this.DelEqButton.Text = "-";
            this.DelEqButton.UseVisualStyleBackColor = true;
            this.DelEqButton.Click += new System.EventHandler(this.DelEqButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Event List";
            // 
            // EventCheckListBox
            // 
            this.EventCheckListBox.FormattingEnabled = true;
            this.EventCheckListBox.HorizontalExtent = 10;
            this.EventCheckListBox.HorizontalScrollbar = true;
            this.EventCheckListBox.Location = new System.Drawing.Point(204, 53);
            this.EventCheckListBox.Name = "EventCheckListBox";
            this.EventCheckListBox.Size = new System.Drawing.Size(434, 463);
            this.EventCheckListBox.TabIndex = 6;
            this.EventCheckListBox.SelectedIndexChanged += new System.EventHandler(this.EventCheckListBox_SelectedIndexChanged);
            // 
            // AddEventButton
            // 
            this.AddEventButton.Location = new System.Drawing.Point(563, 28);
            this.AddEventButton.Name = "AddEventButton";
            this.AddEventButton.Size = new System.Drawing.Size(75, 23);
            this.AddEventButton.TabIndex = 7;
            this.AddEventButton.Text = ">>";
            this.AddEventButton.UseVisualStyleBackColor = true;
            this.AddEventButton.Click += new System.EventHandler(this.AddEventButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(663, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "All Selected Event";
            // 
            // SelectedListBox
            // 
            this.SelectedListBox.FormattingEnabled = true;
            this.SelectedListBox.ItemHeight = 12;
            this.SelectedListBox.Location = new System.Drawing.Point(665, 56);
            this.SelectedListBox.Name = "SelectedListBox";
            this.SelectedListBox.Size = new System.Drawing.Size(400, 460);
            this.SelectedListBox.TabIndex = 9;
            // 
            // ProduceBtn
            // 
            this.ProduceBtn.Location = new System.Drawing.Point(990, 27);
            this.ProduceBtn.Name = "ProduceBtn";
            this.ProduceBtn.Size = new System.Drawing.Size(75, 23);
            this.ProduceBtn.TabIndex = 10;
            this.ProduceBtn.Text = "ProduceXls";
            this.ProduceBtn.UseVisualStyleBackColor = true;
            this.ProduceBtn.Click += new System.EventHandler(this.ProduceBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 552);
            this.Controls.Add(this.ProduceBtn);
            this.Controls.Add(this.SelectedListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AddEventButton);
            this.Controls.Add(this.EventCheckListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DelEqButton);
            this.Controls.Add(this.eqListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddEqButton);
            this.Controls.Add(this.NewEqTextBox);
            this.Name = "MainForm";
            this.Text = "MplcSpecGenerator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NewEqTextBox;
        private System.Windows.Forms.Button AddEqButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox eqListBox;
        private System.Windows.Forms.Button DelEqButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox EventCheckListBox;
        private System.Windows.Forms.Button AddEventButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox SelectedListBox;
        private System.Windows.Forms.Button ProduceBtn;
    }
}

