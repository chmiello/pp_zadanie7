﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace zadanie7_pp
{
    /// <summary>
    /// Interaction logic for condInformation.xaml
    /// </summary>
    public partial class condInformation : Window
    {
        Cond cond;
        public condInformation(Cond cond, String item)
        {
            InitializeComponent();
            WriteInfoLabel.Content = item;
            this.cond = cond;

            if (cond.not.conds.Count != 0)
            {
                notGrid.ItemsSource = getDatatable().DefaultView;
            }
            else
                notGrid.Visibility = System.Windows.Visibility.Hidden;


        }

        private DataTable getDatatable()
        {

            DataTable table = new DataTable();

            table.Columns.Add("ID", typeof(Int32));
            table.Columns.Add("Symbol", typeof(String));
            table.Columns.Add("Nod Name", typeof(String));
            table.Columns.Add("Type", typeof(String));

            int i = 0; //iterator do wyszukiwania itemow na liscie
            foreach (var item in cond.getNot().conds)
            {
                table.Rows.Add(i, item.getArg("symbol"), item.getNodeName(), item.getArg("type"));
                i++;
            }
            return table;
        }
    }
}
