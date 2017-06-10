using System;
using System.CodeDom.Compiler;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.CSharp;
using PriceManager;
using PriceManager.Business;
using PriceManager.Business.Filters;
using PriceManager.Core;

namespace GrundFos.PriceManager.WebSite
{
    public partial class testseba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void CargarTreeView()
        {
            this.tvw.Nodes.Clear();

            for (int i = 0; i < 10; i++)
            {
                //Declaramos una instancia de un nodo para un NodoPadre

                TreeNode nodoPadre = new TreeNode();

                //Le asignamos un texto al NodoPadre mediante nuestra función DeterminarText

                nodoPadre.Text = DeterminarText("Este es el nodo Padre " + i.ToString(),
                                                        int.Parse(this.TextBox1.Text));

                //Agregamos al TreeView1 el NodoPadre

                this.tvw.Nodes.Add(nodoPadre);


                for (int j = 0; j < 10; j++)
                {
                    //Declaramos una instancia de un nodo para un NodoHijo

                    TreeNode nodoHijo = new TreeNode();

                    nodoHijo.Text = DeterminarText("Este es el nodo Hijo " + j.ToString() + " del Padre " + i.ToString(),
                                               int.Parse(this.TextBox2.Text));

                    
                    nodoPadre.ChildNodes.Add(nodoHijo);

                    for (int k = 0; k < 10; k++)
                    {
                        //Declaramos una instancia de un nodo para un NodoHijo

                        TreeNode nodoNieto = new TreeNode();

                        nodoNieto.Text = DeterminarText("Este es el nodo Hijo " + j.ToString() + " del Padre " + i.ToString(),
                                                   int.Parse(this.TextBox2.Text));


                        nodoHijo.ChildNodes.Add(nodoNieto);
                    }
                }
            }
        }

        /// Determina el acomodo del texto en renglones según un determinado número de caracteres
        /// <param name="texto">El texto a acomodar en renglones
        /// <param name="MAX">Número máximo de caracteres permitidos por renglón
        /// <returns>El texto acomodado por renglones
        public static string DeterminarText(string texto, int MAX)

        {
            const string SEPARATOR = "";

            string newStr = "";


            if (texto.Length > MAX)

            {
                string[] tokens = texto.Split(' ');

                string word = "";

                int auxLength = 0;

                int tokenLength = tokens.Length;


                //Revisar todos los tokens que se obtuvieron

                for (int i = 0; i < tokenLength; i++)

                {
                    string aux = tokens[i]; //Se extrae el token actual

                    auxLength = word.Length + aux.Length;

                    //Se obtiene la longitud de lo que seria los tokens acumulados mas el nuevo token


                    //Si los tokens acumulados mas el token actual no sobrepasan la longitud permitida se anexa

                    if (auxLength <= MAX)

                    {
                        word += " " + aux;
                    }

                    else

                    {
                        newStr = newStr + word + SEPARATOR;

                        word = aux;
                    }
                }


                newStr = newStr + word;
            }

            else

            {
                return texto;
            }


            return newStr;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Utils.ShowMessage(this, "probando", 1);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Utils.ShowMessage(this, "probando", 2);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //Utils.ShowMessage(this, "probando", 3);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //List<CodeProvView> tmplst = ControllerManager.Product.GetCodProvViewList();
            List<IDIDView> tmplst = ControllerManager.CategoryBase.GetCategoriesIds();
            List<IDIDView> tmplst2 = ControllerManager.Provider.GetProviderIds();
        }

        
    }
}