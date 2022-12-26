
namespace lab15
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.brn_RemoveVert = new System.Windows.Forms.Button();
            this.btn_AddVert = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_AddEdge = new System.Windows.Forms.Button();
            this.btn_RemoveEdge = new System.Windows.Forms.Button();
            this.pb_GraphCanvas = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_MinSpan = new System.Windows.Forms.Button();
            this.tb_QEdges = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Load = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tb_Value = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_GraphCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // brn_RemoveVert
            // 
            this.brn_RemoveVert.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.brn_RemoveVert.Location = new System.Drawing.Point(13, 29);
            this.brn_RemoveVert.Name = "brn_RemoveVert";
            this.brn_RemoveVert.Size = new System.Drawing.Size(40, 40);
            this.brn_RemoveVert.TabIndex = 0;
            this.brn_RemoveVert.Text = "-";
            this.brn_RemoveVert.UseVisualStyleBackColor = true;
            this.brn_RemoveVert.Click += new System.EventHandler(this.brn_RemoveVert_Click);
            // 
            // btn_AddVert
            // 
            this.btn_AddVert.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_AddVert.Location = new System.Drawing.Point(59, 29);
            this.btn_AddVert.Name = "btn_AddVert";
            this.btn_AddVert.Size = new System.Drawing.Size(40, 40);
            this.btn_AddVert.TabIndex = 1;
            this.btn_AddVert.Text = "+";
            this.btn_AddVert.UseVisualStyleBackColor = true;
            this.btn_AddVert.Click += new System.EventHandler(this.btn_AddVert_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Вершины";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ребра";
            // 
            // btn_AddEdge
            // 
            this.btn_AddEdge.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_AddEdge.Location = new System.Drawing.Point(209, 29);
            this.btn_AddEdge.Name = "btn_AddEdge";
            this.btn_AddEdge.Size = new System.Drawing.Size(40, 40);
            this.btn_AddEdge.TabIndex = 4;
            this.btn_AddEdge.Text = "+";
            this.btn_AddEdge.UseVisualStyleBackColor = true;
            this.btn_AddEdge.Click += new System.EventHandler(this.btn_AddEdge_Click);
            // 
            // btn_RemoveEdge
            // 
            this.btn_RemoveEdge.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_RemoveEdge.Location = new System.Drawing.Point(163, 29);
            this.btn_RemoveEdge.Name = "btn_RemoveEdge";
            this.btn_RemoveEdge.Size = new System.Drawing.Size(40, 40);
            this.btn_RemoveEdge.TabIndex = 3;
            this.btn_RemoveEdge.Text = "-";
            this.btn_RemoveEdge.UseVisualStyleBackColor = true;
            this.btn_RemoveEdge.Click += new System.EventHandler(this.btn_RemoveEdge_Click);
            // 
            // pb_GraphCanvas
            // 
            this.pb_GraphCanvas.Location = new System.Drawing.Point(-1, 75);
            this.pb_GraphCanvas.Name = "pb_GraphCanvas";
            this.pb_GraphCanvas.Size = new System.Drawing.Size(801, 416);
            this.pb_GraphCanvas.TabIndex = 6;
            this.pb_GraphCanvas.TabStop = false;
            this.pb_GraphCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_GraphCanvas_MouseDown);
            this.pb_GraphCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_GraphCanvas_MouseMove);
            this.pb_GraphCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pb_GraphCanvas_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_MinSpan
            // 
            this.btn_MinSpan.Location = new System.Drawing.Point(280, 13);
            this.btn_MinSpan.Name = "btn_MinSpan";
            this.btn_MinSpan.Size = new System.Drawing.Size(175, 23);
            this.btn_MinSpan.TabIndex = 7;
            this.btn_MinSpan.Text = "Цикл отрицательного веса";
            this.btn_MinSpan.UseVisualStyleBackColor = true;
            this.btn_MinSpan.Click += new System.EventHandler(this.btn_MinSpan_Click);
            // 
            // tb_QEdges
            // 
            this.tb_QEdges.Enabled = false;
            this.tb_QEdges.Location = new System.Drawing.Point(280, 43);
            this.tb_QEdges.Name = "tb_QEdges";
            this.tb_QEdges.Size = new System.Drawing.Size(175, 20);
            this.tb_QEdges.TabIndex = 8;
            this.tb_QEdges.TextChanged += new System.EventHandler(this.tb_QEdges_TextChanged);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(483, 12);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 9;
            this.btn_Save.Text = "Сохранить";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Load
            // 
            this.btn_Load.Location = new System.Drawing.Point(483, 43);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(75, 23);
            this.btn_Load.TabIndex = 10;
            this.btn_Load.Text = "Загрузить";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // tb_Value
            // 
            this.tb_Value.Location = new System.Drawing.Point(105, 43);
            this.tb_Value.Name = "tb_Value";
            this.tb_Value.Size = new System.Drawing.Size(52, 20);
            this.tb_Value.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Вес";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 491);
            this.Controls.Add(this.tb_Value);
            this.Controls.Add(this.btn_Load);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.tb_QEdges);
            this.Controls.Add(this.btn_MinSpan);
            this.Controls.Add(this.pb_GraphCanvas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_AddEdge);
            this.Controls.Add(this.btn_RemoveEdge);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_AddVert);
            this.Controls.Add(this.brn_RemoveVert);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pb_GraphCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button brn_RemoveVert;
        private System.Windows.Forms.Button btn_AddVert;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_AddEdge;
        private System.Windows.Forms.Button btn_RemoveEdge;
        private System.Windows.Forms.PictureBox pb_GraphCanvas;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_MinSpan;
        private System.Windows.Forms.TextBox tb_QEdges;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox tb_Value;
        private System.Windows.Forms.Label label3;
    }
}

