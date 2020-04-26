namespace WinFormsTetris
{
    partial class GameForm
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
            this.gameArea = new System.Windows.Forms.PictureBox();
            this.nextPieceOne = new System.Windows.Forms.PictureBox();
            this.nextPieceTwo = new System.Windows.Forms.PictureBox();
            this.startGameButton = new System.Windows.Forms.Button();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.savedPiece = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gameArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextPieceOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextPieceTwo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.savedPiece)).BeginInit();
            this.SuspendLayout();
            // 
            // gameArea
            // 
            this.gameArea.Location = new System.Drawing.Point(98, 12);
            this.gameArea.Name = "gameArea";
            this.gameArea.Size = new System.Drawing.Size(201, 401);
            this.gameArea.TabIndex = 0;
            this.gameArea.TabStop = false;
            // 
            // nextPieceOne
            // 
            this.nextPieceOne.Location = new System.Drawing.Point(305, 12);
            this.nextPieceOne.Name = "nextPieceOne";
            this.nextPieceOne.Size = new System.Drawing.Size(80, 80);
            this.nextPieceOne.TabIndex = 1;
            this.nextPieceOne.TabStop = false;
            // 
            // nextPieceTwo
            // 
            this.nextPieceTwo.Location = new System.Drawing.Point(305, 98);
            this.nextPieceTwo.Name = "nextPieceTwo";
            this.nextPieceTwo.Size = new System.Drawing.Size(80, 80);
            this.nextPieceTwo.TabIndex = 2;
            this.nextPieceTwo.TabStop = false;
            // 
            // startGameButton
            // 
            this.startGameButton.Location = new System.Drawing.Point(12, 425);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(75, 23);
            this.startGameButton.TabIndex = 3;
            this.startGameButton.Text = "Start Game";
            this.startGameButton.UseVisualStyleBackColor = true;
            this.startGameButton.Click += new System.EventHandler(this.startGameButton_Click);
            // 
            // savedPiece
            // 
            this.savedPiece.Location = new System.Drawing.Point(12, 12);
            this.savedPiece.Name = "savedPiece";
            this.savedPiece.Size = new System.Drawing.Size(80, 80);
            this.savedPiece.TabIndex = 4;
            this.savedPiece.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 460);
            this.Controls.Add(this.savedPiece);
            this.Controls.Add(this.startGameButton);
            this.Controls.Add(this.nextPieceTwo);
            this.Controls.Add(this.nextPieceOne);
            this.Controls.Add(this.gameArea);
            this.Name = "gameForm";
            this.Text = "Tetris";
            ((System.ComponentModel.ISupportInitialize)(this.gameArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextPieceOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextPieceTwo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.savedPiece)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox gameArea;
        private System.Windows.Forms.PictureBox nextPieceOne;
        private System.Windows.Forms.PictureBox nextPieceTwo;
        private System.Windows.Forms.Button startGameButton;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.PictureBox savedPiece;
    }
}

