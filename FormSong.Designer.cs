namespace ArduBeats
{
    partial class FormSong
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
            this.labelName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelPerfect = new System.Windows.Forms.Label();
            this.labelGreat = new System.Windows.Forms.Label();
            this.labelBad = new System.Windows.Forms.Label();
            this.labelMiss = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.labelAccuracy = new System.Windows.Forms.Label();
            this.scoreUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.Font = new System.Drawing.Font("Consolas", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.Color.White;
            this.labelName.Location = new System.Drawing.Point(12, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(776, 74);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "NAME";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(83, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "PERFETTO:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Cyan;
            this.label3.Location = new System.Drawing.Point(83, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "BUONO:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(83, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "MANCATO:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(83, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 24);
            this.label5.TabIndex = 3;
            this.label5.Text = "SCARSO:";
            // 
            // labelPerfect
            // 
            this.labelPerfect.AutoSize = true;
            this.labelPerfect.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPerfect.ForeColor = System.Drawing.Color.White;
            this.labelPerfect.Location = new System.Drawing.Point(260, 144);
            this.labelPerfect.Name = "labelPerfect";
            this.labelPerfect.Size = new System.Drawing.Size(22, 24);
            this.labelPerfect.TabIndex = 5;
            this.labelPerfect.Text = "0";
            // 
            // labelGreat
            // 
            this.labelGreat.AutoSize = true;
            this.labelGreat.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGreat.ForeColor = System.Drawing.Color.White;
            this.labelGreat.Location = new System.Drawing.Point(260, 179);
            this.labelGreat.Name = "labelGreat";
            this.labelGreat.Size = new System.Drawing.Size(22, 24);
            this.labelGreat.TabIndex = 6;
            this.labelGreat.Text = "0";
            // 
            // labelBad
            // 
            this.labelBad.AutoSize = true;
            this.labelBad.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBad.ForeColor = System.Drawing.Color.White;
            this.labelBad.Location = new System.Drawing.Point(260, 214);
            this.labelBad.Name = "labelBad";
            this.labelBad.Size = new System.Drawing.Size(22, 24);
            this.labelBad.TabIndex = 7;
            this.labelBad.Text = "0";
            // 
            // labelMiss
            // 
            this.labelMiss.AutoSize = true;
            this.labelMiss.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMiss.ForeColor = System.Drawing.Color.Red;
            this.labelMiss.Location = new System.Drawing.Point(260, 249);
            this.labelMiss.Name = "labelMiss";
            this.labelMiss.Size = new System.Drawing.Size(22, 24);
            this.labelMiss.TabIndex = 8;
            this.labelMiss.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Yellow;
            this.label10.Location = new System.Drawing.Point(511, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(142, 24);
            this.label10.TabIndex = 9;
            this.label10.Text = "PRECISIONE:";
            // 
            // labelAccuracy
            // 
            this.labelAccuracy.AutoSize = true;
            this.labelAccuracy.BackColor = System.Drawing.Color.Transparent;
            this.labelAccuracy.Font = new System.Drawing.Font("Consolas", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAccuracy.ForeColor = System.Drawing.Color.White;
            this.labelAccuracy.Location = new System.Drawing.Point(444, 179);
            this.labelAccuracy.Name = "labelAccuracy";
            this.labelAccuracy.Size = new System.Drawing.Size(277, 75);
            this.labelAccuracy.TabIndex = 10;
            this.labelAccuracy.Text = "000.00%";
            this.labelAccuracy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scoreUpdateTimer
            // 
            this.scoreUpdateTimer.Enabled = true;
            this.scoreUpdateTimer.Interval = 1;
            this.scoreUpdateTimer.Tick += new System.EventHandler(this.ScoreUpdateTimer_Tick);
            // 
            // FormSong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 367);
            this.Controls.Add(this.labelAccuracy);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.labelMiss);
            this.Controls.Add(this.labelBad);
            this.Controls.Add(this.labelGreat);
            this.Controls.Add(this.labelPerfect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelName);
            this.Name = "FormSong";
            this.Text = "FormSong";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSong_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelPerfect;
        private System.Windows.Forms.Label labelGreat;
        private System.Windows.Forms.Label labelBad;
        private System.Windows.Forms.Label labelMiss;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelAccuracy;
        private System.Windows.Forms.Timer scoreUpdateTimer;
    }
}