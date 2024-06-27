using BazarTemTudo.Domain.Entities;
using BazarTemTudo.Domain.Interface.Repository;
using BazarTemTudo.InfraData.Context;
using BazarTemTudo.InfraData.Repository._Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.InfraData.Repository
{
    public class CargaRepository : ICargaRepository
    {
        protected readonly ApplicationDBContext _context;

        public CargaRepository(ApplicationDBContext context) 
        {
            _context = context; 
        }


        public void CreateMultiples(IEnumerable<Carga> entities)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                _context.Set<Carga>().AddRange(entities);
                _context.SaveChanges();
                transaction.Commit();

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Erro ao criar múltiplos objeto: " + ex.Message);
            }
        }

        public IEnumerable<Carga> GetAll()
        {
            var res = _context.Set<Carga>().ToList();

            if (res == null)
            {
                throw new Exception("Not Found");
            }
            return res;
        }

        public bool TruncateCarga()
        {
            try
            {
                var sql = "TRUNCATE TABLE Carga";
                var resp = _context.Database.ExecuteSqlRaw(sql);

                // ExecuteSqlRaw retorna o número de linhas afetadas
                // TRUNCATE TABLE não afeta linhas, então deve retornar 0
                // Qualquer valor diferente de 0 indicaria um problema

                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (opcional)
                // Console.WriteLine(ex.Message);
                throw new Exception("Falha em execução do procedimento!" + ex);

                // Retorna falso se ocorrer uma exceção
                
            }

        }

    }
}
