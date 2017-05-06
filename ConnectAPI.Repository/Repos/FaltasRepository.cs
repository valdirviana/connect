using System;
using System.Data;
using System.Linq;
using ConnectAPI.Domain.Model;
using ConnectAPI.Domain.Repository;
using ConnectAPI.Repository.Base;
using Dapper;

namespace ConnectAPI.Repository.Repos
{
    public class FaltasRepository : BaseRepository, IFaltasRepository
    {
        public FaltasRepository(IDbConnection connection, IDbTransaction transaction) : base(connection, transaction)
        {
        }

        protected override SqlBuilder.Template GetTemplateSelect(ref SqlBuilder builder)
        {
            var sql = builder.AddTemplate(@"
                                 Select /**select**/                                  
                                 FROM dbo.faltas F
                                 /**where**/
                                 /**orderby**/");

            builder.Select("F.Id");
            builder.Select("F.Data");
            builder.Select("F.Justificada");
            builder.Select("F.IdFuncionario");

            builder.OrderBy("F.Data desc");

            return sql;
        }

        public Faltas Save(Faltas entity)
        {
            const string sql =
                @"INSERT INTO dbo.faltas
                                       (Data,
                                        Justificada,
                                        IdFuncionario)
                                 OUTPUT inserted.id
                                 values (@DATA,
                                         @JUSTIFICADA,
                                         @IDFUNCIONARIO)";

            var sqlParams = new DynamicParameters();
            sqlParams.Add("DATA", entity.Data, DbType.String);
            sqlParams.Add("JUSTIFICADA", entity.Justificada, DbType.Boolean);
            sqlParams.Add("IDFUNCIONARIO", entity.IdFuncionario, DbType.Int32);

            entity.Id = Connection.Query<int>(sql, sqlParams, Transaction).FirstOrDefault();

            return entity;
        }

        public Faltas Update(Faltas entity)
        {
            const string sql = @"UPDATE dbo.faltas
                                        SET Data = @DATA, 
                                            Justificada = @JUSTIFICADA,
                                            IdFuncionario = @IDFUNCIONARIO
                                       WHERE Id = @ID";

            var sqlParams = new DynamicParameters();
            sqlParams.Add("DATA", entity.Data, DbType.String);
            sqlParams.Add("JUSTIFICADA", entity.Justificada, DbType.Boolean);
            sqlParams.Add("IDFUNCIONARIO", entity.IdFuncionario, DbType.Int32);

            sqlParams.Add("ID", entity.Id);

            Connection.Execute(sql, sqlParams, Transaction);

            return entity;
        }

        public void Delete(int id)
        {
            const string coordenadorSql = @"DELETE FROM dbo.faltas
                                            WHERE id = @ID";

            var coordenadorParams = new DynamicParameters();
            coordenadorParams.Add("ID", id);

            Connection.Execute(coordenadorSql, coordenadorParams, Transaction);
        }

        public Faltas GetByFuncionario(int id)
        {
            var builder = new SqlBuilder();
            var sql = GetTemplateSelect(ref builder);

            builder.Where("F.IdFuncionario = @ID", new { ID = id });

            return Connection.Query<Faltas>(sql.RawSql, sql.Parameters, Transaction).FirstOrDefault();
        }
    }
}
