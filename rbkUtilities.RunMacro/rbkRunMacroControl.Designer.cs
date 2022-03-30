namespace rbkUtilities.RunMacro
{
    partial class rbkRunMacroControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rbkRunMacroControl));
            this.ClearButton = new System.Windows.Forms.Button();
            this.CodeInput = new FastColoredTextBoxNS.FastColoredTextBox();
            this.RunMacroButton = new System.Windows.Forms.Button();
            this.ClearCmdBeforeRunCheckbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.CodeInput)).BeginInit();
            this.SuspendLayout();
            // 
            // ClearButton
            // 
            this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearButton.Location = new System.Drawing.Point(347, 299);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 0;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // CodeInput
            // 
            this.CodeInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CodeInput.AutoCompleteBrackets = true;
            this.CodeInput.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.CodeInput.AutoIndentExistingLines = false;
            this.CodeInput.AutoScrollMinSize = new System.Drawing.Size(25, 13);
            this.CodeInput.BackBrush = null;
            this.CodeInput.CharHeight = 13;
            this.CodeInput.CharWidth = 7;
            this.CodeInput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CodeInput.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.CodeInput.Font = new System.Drawing.Font("Courier New", 9F);
            this.CodeInput.IsReplaceMode = false;
            this.CodeInput.LeftBracket = '(';
            this.CodeInput.LeftBracket2 = '[';
            this.CodeInput.Location = new System.Drawing.Point(0, 0);
            this.CodeInput.Name = "CodeInput";
            this.CodeInput.Paddings = new System.Windows.Forms.Padding(0);
            this.CodeInput.RightBracket = ')';
            this.CodeInput.RightBracket2 = ']';
            this.CodeInput.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.CodeInput.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("CodeInput.ServiceColors")));
            this.CodeInput.Size = new System.Drawing.Size(422, 285);
            this.CodeInput.TabIndex = 1;
            this.CodeInput.TabLength = 2;
            this.CodeInput.Zoom = 100;
            this.CodeInput.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.CodeInput_TextChanged);
            // 
            // RunMacroButton
            // 
            this.RunMacroButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RunMacroButton.Location = new System.Drawing.Point(3, 299);
            this.RunMacroButton.Name = "RunMacroButton";
            this.RunMacroButton.Size = new System.Drawing.Size(75, 23);
            this.RunMacroButton.TabIndex = 2;
            this.RunMacroButton.Text = "Run Macro";
            this.RunMacroButton.UseVisualStyleBackColor = true;
            this.RunMacroButton.Click += new System.EventHandler(this.RunMacroButton_Click);
            // 
            // ClearCmdBeforeRunCheckbox
            // 
            this.ClearCmdBeforeRunCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ClearCmdBeforeRunCheckbox.AutoSize = true;
            this.ClearCmdBeforeRunCheckbox.Location = new System.Drawing.Point(85, 304);
            this.ClearCmdBeforeRunCheckbox.Name = "ClearCmdBeforeRunCheckbox";
            this.ClearCmdBeforeRunCheckbox.Size = new System.Drawing.Size(193, 17);
            this.ClearCmdBeforeRunCheckbox.TabIndex = 3;
            this.ClearCmdBeforeRunCheckbox.Text = "Clear Command Window before run";
            this.ClearCmdBeforeRunCheckbox.UseVisualStyleBackColor = true;
            // 
            // rbkRunMacroControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ClearCmdBeforeRunCheckbox);
            this.Controls.Add(this.RunMacroButton);
            this.Controls.Add(this.CodeInput);
            this.Controls.Add(this.ClearButton);
            this.Name = "rbkRunMacroControl";
            this.Size = new System.Drawing.Size(425, 325);
            this.Enter += new System.EventHandler(this.RunMacroControl_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.CodeInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ClearButton;
        private FastColoredTextBoxNS.FastColoredTextBox CodeInput;
        private System.Windows.Forms.Button RunMacroButton;
        private System.Windows.Forms.CheckBox ClearCmdBeforeRunCheckbox;
    }
}
