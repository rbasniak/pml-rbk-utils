using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FastColoredTextBoxNS;
using System.Text.RegularExpressions;
using System.IO;

namespace rbkUtilities.RunMacro
{
    public class SyntaxHighlightService
    {
        private const int Opacity = 200;
        private TextStyle Numbers = new TextStyle(new SolidBrush(Color.FromArgb(Opacity, Color.DimGray)), null, FontStyle.Regular);
        private TextStyle Comments = new TextStyle(new SolidBrush(Color.FromArgb(Opacity, Color.Green)), null, FontStyle.Regular);
        private TextStyle StructuralKeywords = new TextStyle(new SolidBrush(Color.FromArgb(Opacity, Color.BlueViolet)), null, FontStyle.Bold);
        private TextStyle GlobalVariables = new TextStyle(new SolidBrush(Color.FromArgb(Opacity, Color.Teal)), null, FontStyle.Bold);
        private TextStyle PrintedStrings = new TextStyle(new SolidBrush(Color.FromArgb(Opacity, Color.Maroon)), null, FontStyle.Bold);
        private TextStyle LocalVariables = new TextStyle(new SolidBrush(Color.FromArgb(Opacity, Color.RoyalBlue)), null, FontStyle.Regular);
        private TextStyle Keywords = new TextStyle(new SolidBrush(Color.FromArgb(Opacity, Color.Blue)), null, FontStyle.Bold);
        private TextStyle Methods = new TextStyle(new SolidBrush(Color.FromArgb(Opacity, Color.DarkGoldenrod)), null, FontStyle.Bold);
        private TextStyle Strings = new TextStyle(new SolidBrush(Color.FromArgb(Opacity, Color.SaddleBrown)), null, FontStyle.Bold);
        private TextStyle Queries = new TextStyle(new SolidBrush(Color.FromArgb(Opacity, Color.Firebrick)), null, FontStyle.Bold);

        private FastColoredTextBox CodeInput;

        public SyntaxHighlightService(FastColoredTextBox input)
        {
            CodeInput = input;

            CodeInput.Language = Language.Custom;
        }

        // http://regexstorm.net/tester
        // https://www.mikesdotnetting.com/article/46/c-regular-expressions-cheat-sheet
        public void ProcessSyntaxHighlight(object sender, TextChangedEventArgs e)
        {
            CodeInput.LeftBracket = '(';
            CodeInput.RightBracket = ')';
            CodeInput.LeftBracket2 = '\x0';
            CodeInput.RightBracket2 = '\x0';

            // --

            //clear folding markers
            e.ChangedRange.ClearFoldingMarkers();

            //set folding markers
            e.ChangedRange.ClearFoldingMarkers();
            e.ChangedRange.SetFoldingMarkers("define method", "endmethod");
            e.ChangedRange.SetFoldingMarkers("setup form", "exit");
            e.ChangedRange.SetFoldingMarkers("define object", "endobject");
            e.ChangedRange.SetFoldingMarkers("define function", "endfunction");

            // --

            //clear style of changed range
            e.ChangedRange.ClearStyle(Queries, Strings, Methods, Keywords, PrintedStrings, StructuralKeywords, Numbers, GlobalVariables, LocalVariables);
            
            // --

            //methods
            e.ChangedRange.SetStyle(Queries, @"^q\svar\b", RegexOptions.Multiline | RegexOptions.IgnoreCase);

            //methods
            e.ChangedRange.SetStyle(Strings, @"([""'])(?:(?=(\\?))\2.)*?\1", RegexOptions.Multiline);

            //keywords
            e.ChangedRange.SetStyle(Keywords, @"\s!this\b", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            e.ChangedRange.SetStyle(Keywords, @"\s(eq|neq|gr|ge|and|or|true|false)\s", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            e.ChangedRange.SetStyle(Keywords, @"(?<=\=\s*)object\s", RegexOptions.Multiline | RegexOptions.IgnoreCase);

            // Printed strings
            e.ChangedRange.SetStyle(PrintedStrings, @"^\s*\$[Pp]\s.*", RegexOptions.Multiline);

            //comment highlighting
            e.ChangedRange.SetStyle(Comments, @"^\s*--.*", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(Comments, @"\$\*.*", RegexOptions.Multiline);

            // global variables and function/form names
            e.ChangedRange.SetStyle(GlobalVariables, @"!![A-Za-z0-9]*\b", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(GlobalVariables, @"(?<=object)\s*[a-zA-Z0-9]*", RegexOptions.Multiline | RegexOptions.IgnoreCase);

            //number highlighting
            e.ChangedRange.SetStyle(Numbers, @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b");

            //class name highlighting
            e.ChangedRange.SetStyle(StructuralKeywords, @"^(define\s+method|define\s+function|define\s+object|setup\s+form|exit|endmethod|endfunction|endobject)", RegexOptions.Multiline | RegexOptions.IgnoreCase);

            //other important commands
            e.ChangedRange.SetStyle(StructuralKeywords, @"^\s*(pml\s+reload\s+form|call|show|return|import|handle|elsehandle|endhandle|using\s+namespace)", RegexOptions.Multiline | RegexOptions.IgnoreCase);

            //conditionals and loops
            e.ChangedRange.SetStyle(StructuralKeywords, @"\b(if|else|elseif|endif|do|enddo|var|skip)\b", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            e.ChangedRange.SetStyle(StructuralKeywords, @"\s(then|from|index)\b", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            e.ChangedRange.SetStyle(StructuralKeywords, @"(?<=do\s.*\s)to", RegexOptions.Multiline | RegexOptions.IgnoreCase);

            //variables
            e.ChangedRange.SetStyle(LocalVariables, @"\![A-Za-z0-9]*\b", RegexOptions.Multiline | RegexOptions.IgnoreCase);

            //methods
            e.ChangedRange.SetStyle(Methods, @"\.[A-Za-z0-9]*\b", RegexOptions.Multiline | RegexOptions.IgnoreCase);

        }

        public void ProcessAutoIdentation(object sender, AutoIndentEventArgs e)
        {
            if (e.LineText.Trim().StartsWith("define method") || e.LineText.Trim().StartsWith("if ") || e.LineText.Trim().StartsWith("do "))
            {
                e.ShiftNextLines = e.TabLength;
                return;
            }

            if (e.LineText.Trim().StartsWith("endmethod") || e.LineText.Trim() == "endif" || e.LineText.Trim() == "enddo")
            {
                e.Shift = -e.TabLength;
                e.ShiftNextLines = -e.TabLength;
                return;
            }

            //// if previous line contains "then" or "else", 
            //// and current line does not contain "begin"
            //// then shift current line to right
            //if (Regex.IsMatch(e.PrevLineText, @"\b(then|else)\b") &&
            //    !Regex.IsMatch(e.LineText, @"\bbegin\b"))
            //{
            //    e.Shift = e.TabLength;
            //    return;
            //}
        } 
    }
}
