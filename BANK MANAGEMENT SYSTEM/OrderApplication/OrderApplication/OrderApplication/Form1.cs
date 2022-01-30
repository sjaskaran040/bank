using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace OrderApplication
{
    public partial class Form1 : Form
    {
        private readonly OrderAccessoriesEntities orderAccessoriesEntities;
        public Form1()
        {
            InitializeComponent();
            orderAccessoriesEntities = new OrderAccessoriesEntities();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Employee newEmp = new Employee();

            newEmp.EmployeeId = Convert.ToInt32(txtEmpId.Text);
            newEmp.FirstName = txtFirstName.Text;
            newEmp.LastName = txtLastName.Text;
            newEmp.PhoneNumber = txtPhoneNumber.Text;
            newEmp.Email = txtEmail.Text;

            orderAccessoriesEntities.Employees.Add(newEmp);
            orderAccessoriesEntities.SaveChanges();

            MessageBox.Show("New Employee is added successfully");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Order newOrder = new Order();

            newOrder.EmployeeId = Convert.ToInt32(txtOrderEmpId.Text);
            newOrder.ProductName = txtOrderProductName.Text;
            newOrder.DateCreated = txtDate.Value;

            orderAccessoriesEntities.Orders.Add(newOrder);
            orderAccessoriesEntities.SaveChanges();

            MessageBox.Show("Order placed successfully");
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            List<Employee> listOfEmployees = orderAccessoriesEntities.Employees.ToList();

            EmployeeList.Columns.Add("Employee Id", 100);
            EmployeeList.Columns.Add("First Name", 100);
            EmployeeList.Columns.Add("Last Name", 100);
            EmployeeList.Columns.Add("Phone Number", 100);
            EmployeeList.Columns.Add("Email", 200);

            if (listOfEmployees.Count > 0)
            {
                foreach (Employee emp in listOfEmployees)
                {
                    ListViewItem item = new ListViewItem(Convert.ToString(emp.EmployeeId));
                    item.SubItems.Add(emp.FirstName);
                    item.SubItems.Add(emp.LastName);
                    item.SubItems.Add(Convert.ToString(emp.PhoneNumber));
                    item.SubItems.Add(Convert.ToString(emp.Email));
                    EmployeeList.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Empty Table");
            }
        }

        private void btnProductList_Click(object sender, EventArgs e)
        {
            List<Product> listOfProduct = orderAccessoriesEntities.Products.ToList();

            productList.Columns.Add("Product Id", 100);
            productList.Columns.Add("Product Name", 200);

            if (listOfProduct.Count > 0)
            {
                foreach (Product aProd in listOfProduct)
                {
                    ListViewItem item = new ListViewItem(Convert.ToString(aProd.ProductId));
                    item.SubItems.Add(aProd.ProductName);

                   productList.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Empty Table");
            }
        }

        private void btnOrderList_Click(object sender, EventArgs e)
        {
            List<Order> listOfOrder = orderAccessoriesEntities.Orders.ToList();

            orderList.Columns.Add("Order Id", 100);
            orderList.Columns.Add("Product Name", 200);
            orderList.Columns.Add("Employee ID", 200);
            orderList.Columns.Add("Order Date", 200);

            if (listOfOrder.Count > 0)
            {
                foreach (Order aOrder in listOfOrder)
                {
                    ListViewItem item = new ListViewItem(Convert.ToString(aOrder.OrderId));
                    item.SubItems.Add(aOrder.ProductName);
                    item.SubItems.Add((aOrder.EmployeeId).ToString());
                    item.SubItems.Add((aOrder.DateCreated).ToString());

                    orderList.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Empty Table");
            }
        }
    }
}
