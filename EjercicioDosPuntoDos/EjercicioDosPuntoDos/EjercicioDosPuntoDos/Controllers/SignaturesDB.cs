using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SQLite;
using EjercicioDosPuntoDos.Models;


namespace EjercicioDosPuntoDos.Controllers
{
    public class SignaturesDB
    {
        readonly SQLiteAsyncConnection db;

        public SignaturesDB()
        {
        }

        public SignaturesDB(String pathbasedatos)
        {
            db = new SQLiteAsyncConnection(pathbasedatos);
            db.CreateTableAsync<Signatures>();
        }

        public Task<List<Signatures>> ListaFirmas()
        {
            return db.Table<Signatures>().ToListAsync();
        }

        public Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }

       public Task<Int32> GuardarFirma(Signatures firma)
        {
            if (firma.CodigoFirma != 0)
            {
                return db.UpdateAsync(firma);
            }
            else
            {
                return db.InsertAsync(firma);
            }
        }
                
        public Task<Signatures> BuscarFirma(int bcodigo)
        {
            return db.Table<Signatures>()
                   .Where(i => i.CodigoFirma == bcodigo)
                   .FirstOrDefaultAsync();
        }



    }
}
