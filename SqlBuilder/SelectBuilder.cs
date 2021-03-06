﻿using BeeseChurger.SqlBuilder.Builders;
using BeeseChurger.SqlBuilder.Builders.Select;
using BeeseChurger.SqlBuilder.Misc;
using System.Text;

namespace BeeseChurger.SqlBuilder
{
    public sealed class SelectBuilder : ISelectBuilder, IFromBuilder, IWhereBuilder, IJoinBuilder, IOrderByBuilder
    {
        private StringBuilder _sql;

        private SelectBuilder()
        {
            _sql = new StringBuilder();
            _sql.Append("SELECT ");
        }
        public static ISelectBuilder Init() => new SelectBuilder();

        public ISelectBuilder Select(string select)
        {
            _sql.Append($"{select}, ");
            return this;
        }

        public IFromBuilder From(string table)
        {
            _sql.RemoveTrailingComma();
            _sql.Append($"FROM {table} ");
            return this;
        }

        public IWhereBuilder Where(string where)
        {
            _sql.Append($"WHERE {where} ");
            return this;
        }

        public IWhereBuilder Where(string field, object value)
        {
            if (value != null)
            {
                _sql.Append($"WHERE {field} = {value.ToSqlParameter()} ");
            }
            return this;
        }

        public IWhereBuilder And(string where)
        {
            if (_sql.ToString().Contains("WHERE"))
            {
                _sql.Append($"AND {where} ");
            }
            else
            {
                Where(where);
            }

            return this;
        }

        public IWhereBuilder And(string field, object value)
        {
            if (value != null)
            {
                if (_sql.ToString().Contains("WHERE"))
                {
                    _sql.Append($"AND {field} = {value.ToSqlParameter()} ");
                }
                else
                {
                    Where(field, value);
                }
            }
            return this;
        }

        public IWhereBuilder Or(string where)
        {
            if (_sql.ToString().Contains("WHERE"))
            {
                _sql.Append($"OR {where} ");
            }
            else
            {
                Where(where);
            }
            return this;
        }

        public IWhereBuilder Or(string field, object value)
        {
            if (value != null)
            {
                if (_sql.ToString().Contains("WHERE"))
                {
                    _sql.Append($"OR {field} = {value.ToSqlParameter()} ");
                }
                else
                {
                    Where(field, value);
                }
            }
            return this;
        }

        public IJoinBuilder InnerJoin(string joiningTable)
        {
            _sql.Append($"INNER JOIN {joiningTable} ");
            return this;
        }

        public IJoinBuilder RightJoin(string joiningTable)
        {
            _sql.Append($"RIGHT JOIN {joiningTable} ");
            return this;
        }

        public IJoinBuilder LeftJoin(string joiningTable)
        {
            _sql.Append($"LEFT JOIN {joiningTable} ");
            return this;
        }

        public IFromBuilder On(string on)
        {
            _sql.Append($"ON {on} ");
            return this;
        }

        public IOrderByBuilder OrderBy(string field)
        {
            _sql.Append($"ORDER BY {field} ");
            return this;
        }

        public IFromBuilder Ascending()
        {
            _sql.Append("ASC ");
            return this;
        }

        public IFromBuilder Descending()
        {
            _sql.Append("DESC ");
            return this;
        }

        public ISqlQueryBuilder Paginate(int pageNumber, int pageSize)
        {
            _sql.Append($"OFFSET {(pageNumber - 1) * pageSize} ROWS FETCH NEXT {pageSize} ROWS ONLY ");
            return this;
        }

        public string Build()
        {
            _sql.Append(";");
            return _sql.ToString();
        }
    }
}