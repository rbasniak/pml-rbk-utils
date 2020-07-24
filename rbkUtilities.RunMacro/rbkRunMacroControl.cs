using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aveva.Core.PMLNet;
using System.Collections;
using FastColoredTextBoxNS;
using System.Text.RegularExpressions;
using System.IO;
using Aveva.Core.Database;

namespace rbkUtilities
{
    [PMLNetCallable]
    public partial class rbkRunMacroControl : UserControl
    {
        [PMLNetCallable]
        public event PMLNetDelegate.PMLNetEventHandler RunMacro;

        private string _userFolder;

        private SyntaxHighlightService _highlightService;

        [PMLNetCallable]
        public rbkRunMacroControl()
        {
            InitializeComponent();

            _highlightService = new SyntaxHighlightService(CodeInput);

            CodeInput.AutoIndentNeeded += new EventHandler<AutoIndentEventArgs>(_highlightService.ProcessAutoIdentation);
        }

        [PMLNetCallable]
        public void Assign(rbkRunMacroControl that)
        {
        }

        [PMLNetCallable]
        public void Setup(string folder)
        {
            _userFolder = folder;

            if (!Directory.Exists(folder))
            {
                _userFolder = Path.GetTempPath();
            }

            var filename = _userFolder + "macro.rbkpml";

            CodeInput.Text = File.ReadAllText(filename);
        }

        private void RunMacroButton_Click(object sender, EventArgs e)
        {
            try
            {
                var filename = _userFolder + "macro.rbkpml";

                File.WriteAllText(filename, CodeInput.Text);
                
                RunMacro?.Invoke(new ArrayList() { filename, ClearCmdBeforeRunCheckbox.Checked });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving the temporary macro file", "Error", MessageBoxButtons.OK);
            }
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            CodeInput.Text = String.Empty; 
        }

        private void CodeInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            _highlightService?.ProcessSyntaxHighlight(sender, e);
        }

        private void RunMacroControl_Enter(object sender, EventArgs e)
        {
            CodeInput.Parent.Parent.Parent.ClientSizeChanged += Parent_SizeChanged;
        }

        private void Parent_SizeChanged(object sender, EventArgs e)
        {
            var panel = CodeInput.Parent.Parent;
            var winControl = CodeInput.Parent; 

            winControl.Width = panel.Width;
            winControl.Height = panel.Height;

        }
    }
}
