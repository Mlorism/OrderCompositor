using OrderCompositor.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace OrderCompositor
{
	public partial class MainWindow : Form
	{
		private const string NAME_HEADER = "Name";
		private const string DATE_REGEX = @"^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$";
		private const string NAME_SURNAME_REGEX = @"^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$";
		private const string QUANTITY_HEADER = "Quantity";
		private const string PRICE_HEADER = "Price";
		private const string NAME_HEADER_TEXT = "Nazwa produktu";
		private const string QUANTITY_HEADER_TEXT = "Ilość";
		private const string PRICE_HEADER_TEXT = "Cena";
		private const string DATE_VALIDATION_TRUE = "Data poprawna";
		private const string DATE_VALIDATION_FALSE = "Niewłaściwa data (spróbuj dd/mm/yyyy lub dd-mm-yyyy)";
		private const string NUMBER_VALIDATION = "Niewłaściwa format liczby";
		private const string DEFAULT_FILE_EXTENSION = "xml";

		private OrderBase currentOrder;
		private bool isDateValid;
		private bool isOrderComplete = false;
		private DateTime minDate = DateTime.Now.AddYears(-110);
		private DateTime maxDate = DateTime.Now.AddYears(-18);

		private Regex dateRegex = new Regex(DATE_REGEX);
		private Regex nameSurnameRegex = new Regex(NAME_SURNAME_REGEX);
		SaveFileDialog saveDialog = new();

		OrderCompositorDbContext _context;
		private BindingList<ProductBase> bindingProductList;
		private BindingSource ProductDataGridSource;

		public int selectedIndex { get; set; } = -1;

		public MainWindow()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Prepare data and form on load
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			_context = new OrderCompositorDbContext();
			currentOrder = new();
			bindingProductList = new BindingList<ProductBase>();
			ProductDataGridSource = new BindingSource(bindingProductList, null);

			this.NameTextBox.Text = currentOrder.ClientName;
			this.ProductsDataGridView.DataSource = ProductDataGridSource;
			this.ProductsDataGridView.ReadOnly = false;
			this.ProductsDataGridView.Columns[NAME_HEADER].HeaderText = NAME_HEADER_TEXT;
			this.ProductsDataGridView.Columns[QUANTITY_HEADER].HeaderText = QUANTITY_HEADER_TEXT;
			this.ProductsDataGridView.Columns[PRICE_HEADER].HeaderText = PRICE_HEADER_TEXT;
			this.DateErrorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
			this.DeleteProductButton.Enabled = false;
			this.ChangeProductButton.Enabled = false;
			this.SaveToDbButton.Enabled = false;
			this.SaveToXMLButton.Enabled = false;
			saveDialog.DefaultExt = DEFAULT_FILE_EXTENSION;
			saveDialog.AddExtension = true;
			saveDialog.Filter = "xml (*.xml)|*.xml";
		}

		/// <summary>
		/// Clean on closing
		/// </summary>
		/// <param name="e"></param>
		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);
			this._context.Dispose();
		}

		/// <summary>
		/// Add new product to list
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AddProductButton_Click(object sender, EventArgs e)
		{
			bindingProductList.Add(new Product());
			this.ProductsDataGridView.Rows[ProductsDataGridView.RowCount - 1].Cells[0].Selected = true;
			this.ProductsDataGridView.Rows[ProductsDataGridView.RowCount - 1].ReadOnly = false;
			this.ProductsDataGridView.BeginEdit(true);
			this.DeleteProductButton.Enabled = true;
			ValidateOrder();
		}

		/// <summary>
		/// Delete selected product
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DeleteProductButton_Click(object sender, EventArgs e)
		{
			if (selectedIndex > -1 && this.ProductsDataGridView.Rows.Count > 0)
			{
				bindingProductList.RemoveAt(selectedIndex);
				ValidateOrder();
				if (this.ProductsDataGridView.Rows.Count > 0)
				{
					if (this.ProductsDataGridView.Rows.Count - 1 >= selectedIndex)
					{
						this.ProductsDataGridView.Rows[selectedIndex].Selected = true;

					}
					else
					{
						this.ProductsDataGridView.Rows[selectedIndex - 1].Selected = true;
					}
				}
				else
				{
					this.DeleteProductButton.Enabled = false;
					this.ChangeProductButton.Enabled = false;
				}
			}
		}

		/// <summary>
		/// Validate and save client name
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NameTextBox_TextChanged(object sender, EventArgs e)
		{
			string providedData = this.NameTextBox.Text;
			bool validRegex = nameSurnameRegex.IsMatch(providedData);
			if (validRegex || providedData == String.Empty)
			{
				currentOrder.ClientName = providedData;
				ValidateOrder();
			}
			else
			{
				this.NameTextBox.Text = currentOrder.ClientName;
				this.NameTextBox.SelectionStart = this.NameTextBox.Text.Length;
				this.NameTextBox.SelectionLength = 0;
			}
		}

		/// <summary>
		/// Validate and save client surname
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SurnameTextBox_TextChanged(object sender, EventArgs e)
		{
			string providedData = this.SurnameTextBox.Text;
			bool validRegex = nameSurnameRegex.IsMatch(providedData);
			if (validRegex || providedData == String.Empty)
			{
				currentOrder.ClientSurname = providedData;
				ValidateOrder();
			}
			else
			{
				this.SurnameTextBox.Text = currentOrder.ClientSurname;
				this.SurnameTextBox.SelectionStart = this.SurnameTextBox.Text.Length;
				this.SurnameTextBox.SelectionLength = 0;
			}
		}

		/// <summary>
		/// Validate and save client date of birth
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DateOfBirthTextBox_TextChanged(object sender, EventArgs e)
		{
			string providedData = this.DateOfBirthTextBox.Text.Trim();
			bool validRegex = dateRegex.IsMatch(providedData);

			DateTime date = new();

			if (validRegex)
			{
				isDateValid = DateTime.TryParse(providedData, out date);
			}
			else
			{
				isDateValid = false;
			}

			if (this.isDateValid && date > minDate && date < maxDate)
			{
				this.ValidationLabel.Text = DATE_VALIDATION_TRUE;
				this.ValidationLabel.ForeColor = Color.Green;
				this.currentOrder.ClientDateOfBirth = date;
				this.DateErrorProvider.SetError(this.DateOfBirthTextBox, null);
				ValidateOrder();
			}
			else
			{
				this.ValidationLabel.Text = DATE_VALIDATION_FALSE;
				this.ValidationLabel.ForeColor = Color.DarkRed;
				this.DateErrorProvider.SetError(this.DateOfBirthTextBox, "Data invalid");
			}
		}

		/// <summary>
		/// Make selected product editable
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ChangeProductButton_Click(object sender, EventArgs e)
		{
			if (selectedIndex > -1 && this.ProductsDataGridView.Rows.Count > 0)
			{
				this.ProductsDataGridView.Rows[selectedIndex].ReadOnly = false;

				if (this.ProductsDataGridView.SelectedCells.Count > 0)
				{
					this.ProductsDataGridView.BeginEdit(true);
				}
			}
		}

		/// <summary>
		/// Manage row state change
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ProductsDataGridView_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
		{
			if (e.StateChanged == DataGridViewElementStates.Selected)
			{
				selectedIndex = e.Row.Index;				

				if (this.ProductsDataGridView.Rows.Count > 0 &&
					this.ProductsDataGridView.Rows[selectedIndex] is DataGridViewRow selectedRow &&
					selectedRow.ReadOnly == false &&
					selectedIndex != e.Row.Index)
				{
					selectedRow.ReadOnly = true;
				}

				this.ChangeProductButton.Enabled = true;
				this.DeleteProductButton.Enabled = true;
			}
		}

		/// <summary>
		/// Manage cell state change
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ProductsDataGridView_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
		{
			if (e.StateChanged == DataGridViewElementStates.Selected)
			{
				selectedIndex = e.Cell.RowIndex;

				if (this.ProductsDataGridView.Rows.Count > 0 &&
					this.ProductsDataGridView.Rows[selectedIndex] is DataGridViewRow selectedRow &&
					selectedRow.ReadOnly == false &&
					selectedIndex != e.Cell.RowIndex)
				{
					selectedRow.ReadOnly = true;
				}
				
				this.ChangeProductButton.Enabled = true;
				this.DeleteProductButton.Enabled = true;
			}
		}

		/// <summary>
		/// Validate cell value
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ProductsDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			bool succes;
			string headerText = this.ProductsDataGridView.Columns[e.ColumnIndex].HeaderText;
			if (headerText.Equals(QUANTITY_HEADER_TEXT))
			{
				succes = int.TryParse(e.FormattedValue.ToString(), out _);
			}
			else if (headerText.Equals(PRICE_HEADER_TEXT))
			{
				succes = decimal.TryParse(e.FormattedValue.ToString(), out _);
			}
			else return;

			if (succes)
			{
				this.ProductsDataGridView.CurrentCell.ErrorText = String.Empty;
			}
			else
			{
				this.ProductsDataGridView.CurrentCell.ErrorText = NUMBER_VALIDATION;
				e.Cancel = true;
			}
		}

		/// <summary>
		/// Validate order and product data
		/// </summary>
		private void ValidateOrder()
		{
			if (bindingProductList.Count > 0 &&
				!string.IsNullOrEmpty(currentOrder.ClientName) &&
				!string.IsNullOrEmpty(currentOrder.ClientSurname) &&
				!string.IsNullOrEmpty(currentOrder.ClientDateOfBirth.ToString()))
			{
				foreach (var product in bindingProductList)
				{
					if (string.IsNullOrEmpty(product.Name) || !(product.Quantity > 0) || !(product.Price > 0))
					{
						isOrderComplete = false;
						this.SaveToDbButton.Enabled = false;
						this.SaveToXMLButton.Enabled = false;
						return;
					}
				}
				this.SaveToDbButton.Enabled = true;
				this.SaveToXMLButton.Enabled = true;
				isOrderComplete = true;
			}
			else
			{
				this.SaveToDbButton.Enabled = false;
				this.SaveToXMLButton.Enabled = false;
				isOrderComplete = false;
			}
		}

		/// <summary>
		/// Save order to database
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SaveToDbButton_Click(object sender, EventArgs e)
		{
			if (isOrderComplete)
			{
				Order order = PrepareOrder();
				_context.Orders.Add(order);
				_context.SaveChangesAsync();
				this.SaveToDbButton.Enabled = false;
			}
		}

		/// <summary>
		/// Save order to XML file
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SaveToXML_Click(object sender, EventArgs e)
		{
			if (isOrderComplete)
			{
				Order order = PrepareOrder();

				XmlSerializer serializer = new(typeof(Order));

				if (saveDialog.ShowDialog() == DialogResult.OK)
				{
					using (FileStream file = File.Create(saveDialog.FileName))
					{
						serializer.Serialize(file, order);
					}

					saveDialog.FileName = String.Empty;
					this.SaveToXMLButton.Enabled = false;
				}
			}
		}

		/// <summary>
		/// Prepare complete order object
		/// </summary>
		/// <returns></returns>
		private Order PrepareOrder()
		{
			Order order = new()
			{
				ClientName = currentOrder.ClientName,
				ClientSurname = currentOrder.ClientSurname,
				ClientDateOfBirth = currentOrder.ClientDateOfBirth
			};

			order.Products = new();

			foreach (ProductBase product in bindingProductList)
			{
				order.Products.Add(
					new Product
					{
						Name = product.Name,
						Quantity = product.Quantity,
						Price = product.Price
					});
			}
			return order;
		}

		/// <summary>
		/// Validate cell on value change
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ProductsDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			ValidateOrder();
		}
	}
}
