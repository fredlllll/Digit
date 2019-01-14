namespace Digit
{
    partial class VisualElementRenderer
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
            if(disposing && (components != null))
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
            this.visualElement1 = new Digit.VisualElement();
            this.SuspendLayout();
            // 
            // visualElement1
            // 
            this.visualElement1.Location = new System.Drawing.Point(68, 37);
            this.visualElement1.Name = "visualElement1";
            this.visualElement1.Size = new System.Drawing.Size(150, 150);
            this.visualElement1.TabIndex = 0;
            // 
            // VisualElementRender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.visualElement1);
            this.Name = "VisualElementRender";
            this.Size = new System.Drawing.Size(295, 284);
            this.ResumeLayout(false);

        }

        #endregion

        private VisualElement visualElement1;
    }
}
