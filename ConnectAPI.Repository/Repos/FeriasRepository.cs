using System;
using System.Data;
using System.Linq;
using ConnectAPI.Domain.Model;
using ConnectAPI.Domain.Repository;
using ConnectAPI.Repository.Base;
using Dapper;

namespace ConnectAPI.Repository.Repos
{
    public class FeriasRepository : BaseRepository, IFeriasRepository
    {
        public FeriasRepository(IDbConnection connection, IDbTransaction transaction) : base(connection, transaction)
        {
        }

        protected override SqlBuilder.Template GetTemplateSelect(ref SqlBuilder builder)
        {
            var sql = builder.AddTemplate(@"
                                 Select /**select**/                                  
                                 FROM dbo.ferias F
                                 /**where**/
                                 /**orderby**/");

            builder.Select("F.Id");
            builder.Select("F.Inicio");
            builder.Select("F.Fim");
            builder.Select("F.IdFuncionario");

            builder.OrderBy("F.Inicio desc");

            return sql;
        }

        public Ferias Save(Ferias entity)
        {
            const string sql =
                @"INSERT INTO dbo.ferias
                                       (Inicio,
                                        Fim,
                                        IdFuncionario)
                                 OUTPUT inserted.id
                                 values (@INICIO,
                                         @FIM,
                                         @IDFUNCIONARIO)";

            var sqlParams = new DynamicParameters();
            sqlParams.Add("INICIO", entity.Inicio, DbType.DateTime);
            sqlParams.Add("FIM", entity.Fim, DbType.DateTime);
            sqlParams.Add("IDFUNCIONARIO", entity.IdFuncionario, DbType.Int32);

            entity.Id = Connection.Query<int>(sql, sqlParams, Transaction).FirstOrDefault();

            return entity;
        }

        public Ferias Update(Ferias entity)
        {
            const string sql = @"UPDATE dbo.ferias
                                        SET Inicio = @INICIO, 
                                            Fim = @FIM,
                                            IdFuncionario = @IDFUNCIONARIO
                                       WHERE Id = @ID";

            var sqlParams = new DynamicParameters();
            sqlParams.Add("INICIO", entity.Inicio, DbType.DateTime);
            sqlParams.Add("FIM", entity.Fim, DbType.DateTime);
            sqlParams.Add("IDFUNCIONARIO", entity.IdFuncionario, DbType.Int32);

            sqlParams.Add("ID", entity.Id);

            Connection.Execute(sql, sqlParams, Transaction);

            return entity;
        }

        public void Delete(int id)
        {
            const string coordenadorSql = @"DELETE FROM dbo.ferias
                                            WHERE id = @ID";

            var coordenadorParams = new DynamicParameters();
            coordenadorParams.Add("ID", id);

            Connection.Execute(coordenadorSql, coordenadorParams, Transaction);
        }

        public Ferias GetByFuncionario(int id)
        {
            var builder = new SqlBuilder();
            var sql = GetTemplateSelect(ref builder);

            builder.Where("F.IdFuncionario = @ID", new { ID = id });

            return Connection.Query<Ferias>(sql.RawSql, sql.Parameters, Transaction).FirstOrDefault();
        }
    }
}
