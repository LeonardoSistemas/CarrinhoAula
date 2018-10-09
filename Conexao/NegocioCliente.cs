using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Conexao
{        
    public class NegocioCliente
    {
        AcessaDados objAcessaDados = new AcessaDados();
        public void InseriCliente(string sNome, string sEndereco, string sCPF, string sRG, string sEstado, string sCidade) {
            //cria um objeto do tipo sqlparametercollection
            SqlParameterCollection parametros = new SqlCommand().Parameters;
            parametros.Add(new SqlParameter("@Nome", sNome));
            parametros.Add(new SqlParameter("@Endereco", sEndereco));
            parametros.Add(new SqlParameter("@CPF", sCPF));
            parametros.Add(new SqlParameter("@RG", sRG));
            parametros.Add(new SqlParameter("@Cidade", sCidade));
            parametros.Add(new SqlParameter("@Estado", sEstado));
            objAcessaDados.ExecuteSQL("spInserirCliente", parametros);
            
        }

        public void AlterarCliente() {

        }

        public void ExcluirCliente() {

        }
    }
}