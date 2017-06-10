using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace GrundFos.Despiece.Business
{
    public class Stock
    {
        public SqlDataReader GetStock(string productcode)
        {
            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
            
            SqlCommand comcalc2 = new SqlCommand("sp_stock", myConnection);
            comcalc2.CommandType = CommandType.StoredProcedure;
            comcalc2.Parameters.Add("@producto", SqlDbType.VarChar).Value = productcode;
            myConnection.Open();
            return comcalc2.ExecuteReader();
        
        }

        public DataSet Calculo(string producto, DateTime fechahoy, DateTime fechapedido, int cantidad, out bool ensamblado)
        {
            //if (fechapedido > fechahoy.AddDays(84))
            //    fechapedido = fechahoy.AddDays(84);

            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
            SqlConnection myConnection2 = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);

            ensamblado = false;

            //Creo el dataset que va a almacenar los datos
            DataSet dsdespiece = new DataSet();
            dsdespiece.Tables.Add("Calculo");
            dsdespiece.Tables["Calculo"].Columns.Add("Parte");
            dsdespiece.Tables["Calculo"].Columns.Add("CantidadNecesaria");
            dsdespiece.Tables["Calculo"].Columns.Add("Stock");
            dsdespiece.Tables["Calculo"].Columns.Add("CantidadDisponible");

            //Creo el dataset para las ordenes de compra del producto requerido
            DataSet dsordcompras = new DataSet();
            dsordcompras.Tables.Add("Detalle");
            dsordcompras.Tables["Detalle"].Columns.Add("Parte");
            dsordcompras.Tables["Detalle"].Columns.Add("Cantidad");
            dsordcompras.Tables["Detalle"].Columns.Add("Fecha");

            //Creo el dataset final para mostrar al usuario
            DataSet final = new DataSet();
            final.Tables.Add("Final");
            final.Tables["Final"].Columns.Add("Fecha", typeof(DateTime));
            final.Tables["Final"].Columns.Add("Cantidad");

            //Busco si hay stock del producto
            SqlCommand com_stock = new SqlCommand("sp_stock", myConnection);
            com_stock.CommandType = CommandType.StoredProcedure;
            com_stock.Parameters.Add("@producto", SqlDbType.VarChar).Value = producto;
            SqlDataReader dr_stock;
            myConnection.Open();
            dr_stock = com_stock.ExecuteReader();
            int canttemp = 0;

            while(dr_stock.Read())
            {
                if (Convert.ToInt32(dr_stock[1]) >= cantidad)
                {
                    final.Tables["Final"].Rows.Add(fechapedido.ToString("dd/MM/yyyy"), dr_stock[1]);
                    return final;
                }
                else if (Convert.ToInt32(dr_stock[1]) > 0)
                {
                    final.Tables["Final"].Rows.Add(fechapedido.ToString("dd/MM/yyyy"), dr_stock[1]);
                    canttemp = Convert.ToInt32(dr_stock[1]);
                }
            }
            dr_stock.Close();
            myConnection.Close();
            
            //Lleno el dataset de la lista de productos necesario para emsamblar
            SqlCommand com_despiece = new SqlCommand("sp_despiece", myConnection);
            com_despiece.CommandType = CommandType.StoredProcedure;
            com_despiece.Parameters.Add("@producto", SqlDbType.VarChar).Value = producto;
            com_despiece.Parameters.Add("@cantidad", SqlDbType.Int).Value = 1;
            SqlDataReader dr_despiece;
            myConnection.Open();
            dr_despiece = com_despiece.ExecuteReader();

            while (dr_despiece.Read())
            {
                int cant = Convert.ToInt32(dr_despiece[0]);
                string parte = dr_despiece[1].ToString();
                int stock = Convert.ToInt32(dr_despiece[2]);

                SqlCommand com_alternativo = new SqlCommand("sp_stockalternativo", myConnection2);
                com_alternativo.CommandType = CommandType.StoredProcedure;
                com_alternativo.Parameters.Add("@producto", SqlDbType.VarChar).Value = parte;

                SqlDataReader dr_alternativo;
                myConnection2.Open();
                dr_alternativo = com_alternativo.ExecuteReader();
                while (dr_alternativo.Read())
                {
                    if (dr_alternativo[2] != DBNull.Value)
                    {
                        if (fechapedido >= Convert.ToDateTime(dr_alternativo[2]))
                        {
                            //parte = dr_alternativo[0].ToString();
                            stock = Convert.ToInt32(dr_alternativo[1]);
                        }
                        else if (dr_alternativo[2] == DBNull.Value)
                        {
                            stock = stock + Convert.ToInt32(dr_alternativo[1]);
                        }
                    }
                }
                dr_alternativo.Close();
                myConnection2.Close();

                int cantdisp = stock / cant;

                dsdespiece.Tables["Calculo"].Rows.Add(parte, cant, stock, cantdisp);
            }
            dr_despiece.Close();
            myConnection.Close();

            if(dsdespiece.Tables["Calculo"].Rows.Count > 1)
                ensamblado = true;
            else
                ensamblado = false;
            

            //Calculo cantidad disponible en base a stock actual
            int cantactual = Disponibilidad(dsdespiece);
            if(cantactual >= cantidad)
            {
                final.Tables["Final"].Rows.Add(fechapedido.ToString("dd/MM/yyyy"), cantactual);
                return final;
            }
            else if (cantactual > 0)
            {
                if ((cantactual > canttemp)&&(cantactual < cantidad))
                    final.Tables["Final"].Rows.Add(fechapedido.ToString("dd/MM/yyyy"), cantactual);
                else if((cantactual > canttemp)&&(cantactual > cantidad))
                    final.Tables["Final"].Rows.Add(fechahoy.ToString("dd/MM/yyyy"), cantactual);
            }
            canttemp = cantactual;

            //Lleno el dataset de las ordenes de compras
            SqlCommand com_ordcompras = new SqlCommand("sp_ordenescompras", myConnection);
            com_ordcompras.CommandType = CommandType.StoredProcedure;
            com_ordcompras.Parameters.Add("@productcode", SqlDbType.VarChar).Value = producto;
            SqlDataReader dr_ordcompras;
            myConnection.Open();
            dr_ordcompras = com_ordcompras.ExecuteReader();

            while(dr_ordcompras.Read())
            {
                string part = dr_ordcompras[0].ToString();
                int cant = Convert.ToInt32(dr_ordcompras[1]);
                DateTime fecha = Convert.ToDateTime(dr_ordcompras[2]);

                //if(dr_ordcompras[4] != DBNull.Value)
                //{
                //    part = dr_ordcompras[3].ToString();
                //}
                dsordcompras.Tables["Detalle"].Rows.Add(part, cant, fecha.ToString("dd/MM/yyyy"));
            }
            dr_ordcompras.Close();
            myConnection.Close();

            DateTime fechatemp = fechahoy;
            for (; fechatemp <= fechahoy.AddDays(84); fechatemp = fechatemp.AddDays(1))
            {
                foreach (DataRow filaordcompras in dsordcompras.Tables["Detalle"].Rows)
                {
                    if (fechatemp.AddDays(-3) == Convert.ToDateTime(filaordcompras["Fecha"]))
                    {
                        DataRow drordcompras = dsdespiece.Tables["Calculo"].Select(string.Format("Parte = '{0}'", filaordcompras["Parte"]))[0];
                        drordcompras["Stock"] = Convert.ToInt32(drordcompras["Stock"]) + Convert.ToInt32(filaordcompras["Cantidad"]);
                        drordcompras["CantidadDisponible"] = Convert.ToInt32(drordcompras["Stock"]) / Convert.ToInt32(drordcompras["CantidadNecesaria"]);
                    }
                }
                DataRow datar = dsdespiece.Tables["Calculo"].Rows[0];

                int cantfutura = Disponibilidad(dsdespiece);
                if(fechatemp >= fechapedido)
                {
                    if(cantfutura > canttemp )
                    {
                        if (cantfutura > 0)
                        {
                            if (final.Tables["Final"].Select(string.Format("Fecha = '{0}'", fechatemp.ToString("dd/MM/yyyy"))).Length > 0)
                            {
                                DataRow drtemp = final.Tables["Final"].Select(string.Format("Fecha = '{0}'", fechatemp.ToString("dd/MM/yyyy")))[0];
                                drtemp["Cantidad"] = cantfutura;

                                if (cantfutura >= cantidad)
                                    return final;
                            }
                            else
                            {
                                final.Tables["Final"].Rows.Add(fechatemp.ToString("dd/MM/yyyy"), cantfutura);
                                if (cantfutura >= cantidad)
                                    return final;
                            }
                        }
                        canttemp = cantfutura;
                    }
                }
            }

            //Si termina el proceso y no encuentra disponibilidad
            if (final.Tables["Final"].Select(string.Format("Fecha >= '{0}'", fechahoy.AddDays(84))).Length > 0)
            {
                DataRow drtemp = final.Tables["Final"].Select(string.Format("Fecha >= '{0}'", fechahoy.AddDays(84)))[0];

                drtemp["Cantidad"] = cantidad;
            }
            else
            {
                if (fechapedido <= fechahoy.AddDays(84))
                {
                    final.Tables["Final"].Rows.Add(fechahoy.AddDays(84).ToString("dd/MM/yyyy"), cantidad);
                }
                else
                    final.Tables["Final"].Rows.Add(fechapedido.ToString("dd/MM/yyyy"), cantidad);
            }
            return final;     
        
        }

        private static int Disponibilidad(DataSet dsdespiece)
        {
            int cantactual = 1000;
            foreach (DataRow fila in dsdespiece.Tables["Calculo"].Rows)
            {
                if (Convert.ToInt32(fila.ItemArray[3]) < cantactual)
                    cantactual = Convert.ToInt32(fila.ItemArray[3]);
            }
            return cantactual;
        }
    }
}
