namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DateTimePickerTime.MinDate = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxName.Text) || string.IsNullOrWhiteSpace(TextBoxPhone.Text))
            {
                MessageBox.Show("Fields are empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string orderTime = DateTimePickerTime.Value.ToString("f");
            string mainDish = comboBox1.SelectedItem?.ToString() ?? "Íå îáðàíî";
            var additionalItems = checkedListBox1.CheckedItems.Cast<string>().ToList();
            string deliveryType = GetDeliveryType();

            string summary = $"Name: {TextBoxName.Text}\n" +
                             $"Phone number: {TextBoxPhone.Text}\n" +
                             $"Order time: {orderTime}\n" +
                             $"Dish: {mainDish}\n" +
                             $"Additional Ingredients: {(additionalItems.Any() ? string.Join(", ", additionalItems) : "---")}\n" +
                             $"Self-Pickup or Delivery: {deliveryType}";

            MessageBox.Show(summary, "Your order.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string GetDeliveryType()
        {
            if (RadioButtonSelfPickup.Checked)
            {
                RadioButtonDelivery.Checked = false;
                return "Self-Pickup";
            }
            else
            {
                RadioButtonDelivery.Checked = true;
                return "Delivery";
            }
        }
    }
}
