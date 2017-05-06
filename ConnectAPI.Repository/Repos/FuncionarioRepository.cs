using ConnectAPI.Domain.Repository;
using ConnectAPI.Repository.Base;
using System.Collections.Generic;
using System.Linq;
using ConnectAPI.Domain.Base.Filter;
using ConnectAPI.Domain.Model;
using System.Data;
using Dapper;
using ConnectAPI.Repository.Helper;

namespace ConnectAPI.Repository.Repos
{
    public class FuncionarioRepository : BaseRepository, IFuncionarioRepository
    {
        public FuncionarioRepository(IDbConnection connection, IDbTransaction transaction) : base(connection, transaction)
        {
            SearchDictionary = new Dictionary<string, string>
            {
                {"Nome", "F.NOME"}
            };
        }

        public IEnumerable<Funcionario> GetAll()
        {
            var builder = new SqlBuilder();
            var sql = GetTemplateSelect(ref builder);

            return Connection.Query<Funcionario>(sql.RawSql, sql.Parameters, Transaction);
        }

        public IEnumerable<Funcionario> Search(IEnumerable<BaseFilter> filters)
        {
            var builder = new SqlBuilder();
            var sql = GetTemplateSelect(ref builder);

            var dynamicWhere = SearchHelper.GetWhereText(filters, SearchDictionary);
            foreach (var whereDapper in dynamicWhere)
            {
                builder.Where(whereDapper.Condition, whereDapper.Param);
            }

            return Connection.Query<Funcionario>(sql.RawSql, sql.Parameters);
        }

        public Funcionario GetById(int id)
        {
            var builder = new SqlBuilder();
            var sql = GetTemplateSelect(ref builder);

            builder.Where("F.Id= @ID", new { ID = id });

            return Connection.Query<Funcionario>(sql.RawSql, sql.Parameters, Transaction).FirstOrDefault();
        }

        public Funcionario Save(Funcionario entity)
        {
            const string sql =
                 @"INSERT INTO dbo.funcionario
                                       (Nome,
                                        Setor,
                                        Cargo,
                                        DataAdmissao,
                                        Salario)
                                 OUTPUT inserted.id
                                 values (@NOME,
                                         @SETOR,
                                         @CARGO,
                                         @DATAADMISSAO,
                                         @SALARIO)";

            var sqlParams = new DynamicParameters();
            sqlParams.Add("NOME", entity.Nome, DbType.String);
            sqlParams.Add("SETOR", entity.Setor, DbType.String);
            sqlParams.Add("CARGO", entity.Cargo, DbType.String);
            sqlParams.Add("DATAADMISSAO", entity.DataAdmissao, DbType.DateTime);
            sqlParams.Add("SALARIO", entity.Salario, DbType.Decimal);

            entity.Id = Connection.Query<int>(sql, sqlParams, Transaction).FirstOrDefault();

            return entity;
        }   

        public Funcionario Update(Funcionario entity)
        {
            const string sql = @"UPDATE dbo.funcionario
                                        SET Nome = @NOME, 
                                            Setor = @SETOR,
                                            Cargo = @CARGO,
                                            DataAdmissao = @DATAADMISSAO,
                                            Salario = @SALARIO
                                       WHERE Id = @ID";

            var sqlParams = new DynamicParameters();
            sqlParams.Add("NOME", entity.Nome, DbType.String);
            sqlParams.Add("SETOR", entity.Setor, DbType.String);
            sqlParams.Add("CARGO", entity.Cargo, DbType.String);
            sqlParams.Add("DATAADMISSAO", entity.DataAdmissao, DbType.DateTime);
            sqlParams.Add("SALARIO", entity.Salario, DbType.Decimal);

            sqlParams.Add("ID", entity.Id);

            Connection.Execute(sql, sqlParams, Transaction);

            return entity;
        }

        public void Delete(int id)
        {
            const string coordenadorSql = @"DELETE FROM dbo.funcionario
                                            WHERE id = @ID";

            var coordenadorParams = new DynamicParameters();
            coordenadorParams.Add("ID", id);

            Connection.Execute(coordenadorSql, coordenadorParams, Transaction);
        }

        protected override SqlBuilder.Template GetTemplateSelect(ref SqlBuilder builder)
        {
            var sql = builder.AddTemplate(@"
                                 Select /**select**/                                  
                                 FROM dbo.funcionario F
                                 /**where**/
                                 /**orderby**/");

            builder.Select("F.Id");
            builder.Select("F.Nome");
            builder.Select("F.Setor");
            builder.Select("F.Cargo");
            builder.Select("F.DataAdmissao");
            builder.Select("F.Salario");

            builder.OrderBy("F.Nome Asc");

            return sql;
        }
    }
}
