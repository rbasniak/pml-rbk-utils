namespace rbkUtilities.Tester
{
    partial class CodeEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeEditor));
            this.CodeInput = new FastColoredTextBoxNS.FastColoredTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.CodeInput)).BeginInit();
            this.SuspendLayout();
            // 
            // CodeInput
            // 
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
            this.CodeInput.AutoScrollMinSize = new System.Drawing.Size(158, 15);
            this.CodeInput.BackBrush = null;
            this.CodeInput.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CodeInput.CharHeight = 15;
            this.CodeInput.CharWidth = 7;
            this.CodeInput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CodeInput.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.CodeInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CodeInput.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.CodeInput.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CodeInput.IndentBackColor = System.Drawing.Color.Gainsboro;
            this.CodeInput.IsReplaceMode = false;
            this.CodeInput.Location = new System.Drawing.Point(0, 0);
            this.CodeInput.Name = "CodeInput";
            this.CodeInput.Paddings = new System.Windows.Forms.Padding(0);
            this.CodeInput.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.CodeInput.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("CodeInput.ServiceColors")));
            this.CodeInput.Size = new System.Drawing.Size(800, 450);
            this.CodeInput.TabIndex = 0;
            this.CodeInput.Text = "fastColoredTextBox1";
            this.CodeInput.Zoom = 100;
            this.CodeInput.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.CodeInput_TextChanged);
            // 
            // MouseWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CodeInput);
            this.Name = "MouseWindow";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.CodeInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox CodeInput;
    }
}

