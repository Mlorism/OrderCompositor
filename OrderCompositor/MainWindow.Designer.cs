
namespace OrderCompositor
{
	partial class MainWindow
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.NameLabel = new System.Windows.Forms.Label();
			this.SurnameLabel = new System.Windows.Forms.Label();
			this.DateOfBirthLabel = new System.Windows.Forms.Label();
			this.NameTextBox = new System.Windows.Forms.TextBox();
			this.SurnameTextBox = new System.Windows.Forms.TextBox();
			this.DateOfBirthTextBox = new System.Windows.Forms.TextBox();
			this.AddProductButton = new System.Windows.Forms.Button();
			this.DeleteProductButton = new System.Windows.Forms.Button();
			this.ChangeProductButton = new System.Windows.Forms.Button();
			this.OrderedProductsLabel = new System.Windows.Forms.Label();
			this.ProductsDataGridView = new System.Windows.Forms.DataGridView();
			this.SaveToDbButton = new System.Windows.Forms.Button();
			this.SaveToXMLButton = new System.Windows.Forms.Button();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ValidationLabel = new System.Windows.Forms.Label();
			this.DateErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			((System.ComponentModel.ISupportInitialize)(this.ProductsDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DateErrorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// NameLabel
			// 
			this.NameLabel.AutoSize = true;
			this.NameLabel.Location = new System.Drawing.Point(39, 29);
			this.NameLabel.Name = "NameLabel";
			this.NameLabel.Size = new System.Drawing.Size(30, 15);
			this.NameLabel.TabIndex = 0;
			this.NameLabel.Text = "Imię";
			// 
			// SurnameLabel
			// 
			this.SurnameLabel.AutoSize = true;
			this.SurnameLabel.Location = new System.Drawing.Point(39, 59);
			this.SurnameLabel.Name = "SurnameLabel";
			this.SurnameLabel.Size = new System.Drawing.Size(57, 15);
			this.SurnameLabel.TabIndex = 1;
			this.SurnameLabel.Text = "Nazwisko";
			// 
			// DateOfBirthLabel
			// 
			this.DateOfBirthLabel.AutoSize = true;
			this.DateOfBirthLabel.Location = new System.Drawing.Point(39, 89);
			this.DateOfBirthLabel.Name = "DateOfBirthLabel";
			this.DateOfBirthLabel.Size = new System.Drawing.Size(86, 15);
			this.DateOfBirthLabel.TabIndex = 2;
			this.DateOfBirthLabel.Text = "Data urodzenia";
			this.DateOfBirthLabel.UseMnemonic = false;
			// 
			// NameTextBox
			// 
			this.NameTextBox.Location = new System.Drawing.Point(140, 26);
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.Size = new System.Drawing.Size(100, 23);
			this.NameTextBox.TabIndex = 3;
			this.NameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
			// 
			// SurnameTextBox
			// 
			this.SurnameTextBox.Location = new System.Drawing.Point(140, 56);
			this.SurnameTextBox.Name = "SurnameTextBox";
			this.SurnameTextBox.Size = new System.Drawing.Size(100, 23);
			this.SurnameTextBox.TabIndex = 4;
			this.SurnameTextBox.TextChanged += new System.EventHandler(this.SurnameTextBox_TextChanged);
			// 
			// DateOfBirthTextBox
			// 
			this.DateOfBirthTextBox.Location = new System.Drawing.Point(140, 86);
			this.DateOfBirthTextBox.Name = "DateOfBirthTextBox";
			this.DateOfBirthTextBox.Size = new System.Drawing.Size(100, 23);
			this.DateOfBirthTextBox.TabIndex = 5;
			this.DateOfBirthTextBox.TextChanged += new System.EventHandler(this.DateOfBirthTextBox_TextChanged);
			// 
			// AddProductButton
			// 
			this.AddProductButton.Location = new System.Drawing.Point(39, 131);
			this.AddProductButton.Name = "AddProductButton";
			this.AddProductButton.Size = new System.Drawing.Size(127, 23);
			this.AddProductButton.TabIndex = 6;
			this.AddProductButton.Text = "Dodaj produkt";
			this.AddProductButton.UseVisualStyleBackColor = true;
			this.AddProductButton.Click += new System.EventHandler(this.AddProductButton_Click);
			// 
			// DeleteProductButton
			// 
			this.DeleteProductButton.Location = new System.Drawing.Point(198, 131);
			this.DeleteProductButton.Name = "DeleteProductButton";
			this.DeleteProductButton.Size = new System.Drawing.Size(129, 23);
			this.DeleteProductButton.TabIndex = 7;
			this.DeleteProductButton.Text = "Usuń produkt";
			this.DeleteProductButton.UseVisualStyleBackColor = true;
			this.DeleteProductButton.Click += new System.EventHandler(this.DeleteProductButton_Click);
			// 
			// ChangeProductButton
			// 
			this.ChangeProductButton.Location = new System.Drawing.Point(357, 131);
			this.ChangeProductButton.Name = "ChangeProductButton";
			this.ChangeProductButton.Size = new System.Drawing.Size(157, 23);
			this.ChangeProductButton.TabIndex = 8;
			this.ChangeProductButton.Text = "Zmień produkt";
			this.ChangeProductButton.UseVisualStyleBackColor = true;
			this.ChangeProductButton.Click += new System.EventHandler(this.ChangeProductButton_Click);
			// 
			// OrderedProductsLabel
			// 
			this.OrderedProductsLabel.AutoSize = true;
			this.OrderedProductsLabel.Location = new System.Drawing.Point(39, 175);
			this.OrderedProductsLabel.Name = "OrderedProductsLabel";
			this.OrderedProductsLabel.Size = new System.Drawing.Size(124, 15);
			this.OrderedProductsLabel.TabIndex = 9;
			this.OrderedProductsLabel.Text = "Zamówione produkty:";
			// 
			// ProductsDataGridView
			// 
			this.ProductsDataGridView.AllowUserToAddRows = false;
			this.ProductsDataGridView.AllowUserToDeleteRows = false;
			this.ProductsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.ProductsDataGridView.Location = new System.Drawing.Point(39, 203);
			this.ProductsDataGridView.MultiSelect = false;
			this.ProductsDataGridView.Name = "ProductsDataGridView";
			this.ProductsDataGridView.RowTemplate.Height = 25;
			this.ProductsDataGridView.Size = new System.Drawing.Size(713, 201);
			this.ProductsDataGridView.TabIndex = 10;
			this.ProductsDataGridView.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.ProductsDataGridView_CellStateChanged);
			this.ProductsDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.ProductsDataGridView_CellValidating);
			this.ProductsDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProductsDataGridView_CellValueChanged);
			this.ProductsDataGridView.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.ProductsDataGridView_RowStateChanged);
			// 
			// SaveToDbButton
			// 
			this.SaveToDbButton.Location = new System.Drawing.Point(470, 415);
			this.SaveToDbButton.Name = "SaveToDbButton";
			this.SaveToDbButton.Size = new System.Drawing.Size(152, 23);
			this.SaveToDbButton.TabIndex = 11;
			this.SaveToDbButton.Text = "Zapisz do bazy danych";
			this.SaveToDbButton.UseVisualStyleBackColor = true;
			this.SaveToDbButton.Click += new System.EventHandler(this.SaveToDbButton_Click);
			// 
			// SaveToXMLButton
			// 
			this.SaveToXMLButton.Location = new System.Drawing.Point(628, 415);
			this.SaveToXMLButton.Name = "SaveToXMLButton";
			this.SaveToXMLButton.Size = new System.Drawing.Size(124, 23);
			this.SaveToXMLButton.TabIndex = 12;
			this.SaveToXMLButton.Text = "Zapisz do XML";
			this.SaveToXMLButton.UseVisualStyleBackColor = true;
			this.SaveToXMLButton.Click += new System.EventHandler(this.SaveToXML_Click);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
			// 
			// ValidationLabel
			// 
			this.ValidationLabel.AutoSize = true;
			this.ValidationLabel.Location = new System.Drawing.Point(259, 91);
			this.ValidationLabel.Name = "ValidationLabel";
			this.ValidationLabel.Size = new System.Drawing.Size(40, 15);
			this.ValidationLabel.TabIndex = 14;
			this.ValidationLabel.Text = "           ";
			// 
			// DateErrorProvider
			// 
			this.DateErrorProvider.ContainerControl = this;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.ValidationLabel);
			this.Controls.Add(this.SaveToXMLButton);
			this.Controls.Add(this.SaveToDbButton);
			this.Controls.Add(this.ProductsDataGridView);
			this.Controls.Add(this.OrderedProductsLabel);
			this.Controls.Add(this.ChangeProductButton);
			this.Controls.Add(this.DeleteProductButton);
			this.Controls.Add(this.AddProductButton);
			this.Controls.Add(this.DateOfBirthTextBox);
			this.Controls.Add(this.SurnameTextBox);
			this.Controls.Add(this.NameTextBox);
			this.Controls.Add(this.DateOfBirthLabel);
			this.Controls.Add(this.SurnameLabel);
			this.Controls.Add(this.NameLabel);
			this.Name = "MainWindow";
			this.Text = "Order Compositor";
			((System.ComponentModel.ISupportInitialize)(this.ProductsDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DateErrorProvider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label NameLabel;
		private System.Windows.Forms.Label SurnameLabel;
		private System.Windows.Forms.Label DateOfBirthLabel;
		private System.Windows.Forms.TextBox NameTextBox;
		private System.Windows.Forms.TextBox SurnameTextBox;
		private System.Windows.Forms.TextBox DateOfBirthTextBox;
		private System.Windows.Forms.Button AddProductButton;
		private System.Windows.Forms.Button DeleteProductButton;
		private System.Windows.Forms.Button ChangeProductButton;
		private System.Windows.Forms.Label OrderedProductsLabel;
		private System.Windows.Forms.DataGridView ProductsDataGridView;
		private System.Windows.Forms.Button SaveToDbButton;
		private System.Windows.Forms.Button SaveToXMLButton;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.Label ValidationLabel;
		private System.Windows.Forms.ErrorProvider DateErrorProvider;
	}
}

