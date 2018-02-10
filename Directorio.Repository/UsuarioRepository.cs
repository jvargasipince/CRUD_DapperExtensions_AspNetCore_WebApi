using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using DapperExtensions;
using Directorio.Entities;
using Directorio.Repository.Interfaces;
using Directorio.Repository.Mapper;
using Microsoft.Extensions.Configuration;

namespace Directorio.Repository
{
    public class UsuarioRepository : IRepository<Usuario>
    {
        IConfiguration _configuration;
        const string Active = "1";

        public UsuarioRepository(IConfiguration configuration)
        {

            _configuration = configuration;

            DapperExtensions.DapperExtensions.DefaultMapper = typeof(UsuarioMapper);

            // Tell Dapper Extension to scan this assembly for custom mappings
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new[]
            {
             typeof (UsuarioMapper).Assembly
            });

        }

        public bool Add(Usuario entity)
        {
            bool success = false;

            using (var cn = new SqlConnection(GetConnection()))
            {
                try
                {
                    int id = cn.Insert(entity);

                    if (id > 0)
                        success = true;

                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
            return success;
        }

        public bool Delete(Usuario entity)
        {
            bool success = false;

            using (var cn = new SqlConnection(GetConnection()))
            {
                try
                {
                    success = cn.Delete(entity);
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
            return success;
        }

        public Usuario Get(int id)
        {
            using (var cn = new SqlConnection(GetConnection()))
            {
                var pgMain = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
                pgMain.Predicates.Add(Predicates.Field<Usuario>(u => u.Status, Operator.Eq, Active));
                pgMain.Predicates.Add(Predicates.Field<Usuario>(u => u.Id, Operator.Eq, id));

                var user = cn.GetList<Usuario>(pgMain).SingleOrDefault();

                return user;
            }
        }

        public IEnumerable<Usuario> GetAll()
        {
            using (var cn = new SqlConnection(GetConnection()))
            {
                var pgMain = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
                pgMain.Predicates.Add(Predicates.Field<Usuario>(u => u.Status, Operator.Eq, Active));

                var userList = cn.GetList<Usuario>(pgMain).ToList();

                return userList;
            }
        }

        public bool Update(Usuario entity)
        {
            bool success = false;

            using (var cn = new SqlConnection(GetConnection()))
            {
                try
                {
                    success = cn.Update(entity);
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
            return success;
        }

        private string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DirectoryDB").Value;
            return connection;
        }
    }
}
