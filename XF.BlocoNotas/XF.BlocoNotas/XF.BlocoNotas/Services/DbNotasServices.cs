using SQLite;
using System;
using System.Collections.Generic;
using XF.BlocoNotas.Models;
using XF.BlocoNotas.Validations;

namespace XF.BlocoNotas.Services
{
    public class DbNotasServices
    {
        private SQLiteConnection _conn;
        public string StatusMessage { get; set; }

        private readonly string _dbPath;

        public DbNotasServices()
        {
            _dbPath = App.DbPath;
            CreateTable();
        }

        private void CreateTable()
        {
            using (_conn = new SQLiteConnection(_dbPath))
            {
                _conn.CreateTable<Nota>();
            }
        }

        public void Insert(Nota nota)
        {
            using (_conn = new SQLiteConnection(_dbPath))
            {
                if(!NotaValidation.ValidaNotas(nota))
                    throw new Exception(NotaValidation.ErrorMessage);

                var result = _conn.Insert(nota);
                if (result > 0)
                    StatusMessage = $"Nota {nota.Titulo} gravada com sucesso.";
                else
                    StatusMessage = $"Ocorreu um erro ao gravar a nota {nota.Titulo}.";
            }
        }

        public List<Nota> List()
        {
            using (_conn = new SQLiteConnection(_dbPath))
            {
                return _conn.Table<Nota>().ToList();
            }
        }

        public void Update(Nota nota)
        {
            if (!NotaValidation.ValidaNotas(nota))
                throw new Exception(NotaValidation.ErrorMessage);

            using (_conn = new SQLiteConnection(_dbPath))
            {
                var result =_conn.Update(nota);

                if (result > 0)
                    StatusMessage = $"A nota {nota.Titulo} foi atualizada";
                else
                    StatusMessage = $"Ocorreu um erro ao tentar atualizar a nota {nota.Titulo}";
            }
        }

        public void Delete(int id)
        {
            if(id <= 0)
                throw  new Exception("Nota inválida");

            using (_conn = new SQLiteConnection(_dbPath))
            {
                var result = _conn.Table<Nota>().Delete(n => n.Id == id);

                if (result > 0)
                    StatusMessage = $"A nota excluída com sucesso";
                else
                    StatusMessage = $"Ocorreu um erro ao tentar excluir a nota.";
            }
        }
    }
}
