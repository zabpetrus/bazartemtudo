using BazarTemTudo.TesteConsole.Context;
using BazarTemTudo.TesteConsole.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.TesteConsole.Repository
{
    public class CargaRepository
    {
        private readonly TestContext _context;

        public CargaRepository(TestContext context)
        {
            _context = context;
        }


        public void Create(Carga entity)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Add(entity);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Erro ao criar objeto: " + ex.Message);
            }
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



    }
}
