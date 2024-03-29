﻿using Agenda.Data.Configurations;
using Agenda.Data.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Data.Repositories
{
    public class UsuarioRepository
    {
        public void Create(Usuario usuario)
        {
            var query = @"
                INSERT INTO USUARIO (
                    IDUSUARIO, NOME, EMAIL, SENHA, DATACRIACAO)
                VALUES(
                    @IdUsuario, @Nome, @Email, CONVERT(VARCHAR(32), HASHBYTES('MD5', @Senha), 2), @DataCriacao
                )
            ";

            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString))
            {
                connection.Execute(query, usuario);
            }

        }

        public void Update(Guid idUsuario, string novaSenha)
        {
            var query = @"
                UPDATE USUARIO SET SENHA = CONVERT(VARCHAR(32), HASHBYTES('MD5', @novasenha), 2)
                WHERE IDUSUARIO = @idUsuario
                ";

            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString))
            {
                connection.Execute(query, new { idUsuario, novaSenha });
            }
        }

        public Usuario? GetByEmail(string email)
        {
            var query = @"
                SELECT * FROM USUARIO WHERE EMAIL = @email
            ";

            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString))
            {
                return connection.Query<Usuario>(query, new { email }).FirstOrDefault();
            }
        }

        public Usuario? GetByEmailAndSenha(string email, string senha)
        {
            var query = @"
                SELECT * FROM USUARIO WHERE EMAIL = @email AND SENHA = CONVERT(VARCHAR(32), HASHBYTES('MD5', @senha), 2)
            ";

            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString))
            {
                return connection.Query<Usuario>(query, new { email, senha }).FirstOrDefault();
            }
        }
    }
}