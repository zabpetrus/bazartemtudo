using BazarTemTudo.Domain.Entities;
using BazarTemTudo.InfraData.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.CrossCutting.BuildProcess
{
    public class ResponserDatabase
    {
        private readonly ApplicationDBContext _context;

        public ResponserDatabase(ApplicationDBContext context)
        {
            _context = context;
        }

        private async Task PopularClientes()
        {
            // Exemplo de consulta complexa
            var sql = @"
            INSERT INTO [dbo].[Clientes]
            (cliente_name ,cliente_email ,cliente_cpf,cliente_phone_number)
	        SELECT DISTINCT 
	        Ca.buyer_name, Ca.buyer_email, 	Ca.cpf, Ca.buyer_phone_number 
	        FROM Carga Ca  
	        LEFT JOIN [Clientes] ON Clientes.cliente_cpf = Ca.cpf 
	        WHERE NOT EXISTS (  SELECT 1  FROM [Clientes] Cl  WHERE Cl.cliente_cpf = Ca.cpf );
            ";

            await _context.Database.ExecuteSqlRawAsync(sql);
        }

        


    }
}
