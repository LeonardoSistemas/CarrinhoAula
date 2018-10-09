using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Conexao
{
    public partial class CadastroCliente : System.Web.UI.Page
    {
        NegocioCliente negCliente = new NegocioCliente();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            string sNome = "", sEndereco = "", sCPF = "", sRG = "", sCidade = "", sEstado = "";

            sNome = txtNome.Value;
            sEndereco = txtEndereco.Value;
            sCPF = txtCPF.Value;
            sRG = txtRG.Value;
            sCidade = cbbCidade.Value;
            sEstado = cbbUF.Value;
            negCliente.InseriCliente(sNome, sEndereco, sCPF, sRG, sEstado, sCidade);
        }
    }
}